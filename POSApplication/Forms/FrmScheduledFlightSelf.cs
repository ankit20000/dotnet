using BusinessEntityLayer;
using Common;
using PosApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace POSApplication.Forms
{    
    public partial class FrmScheduledFlightSelf : MasterForm
    {
        #region [Object Declaration]

        private IScheduledFlightsSelf _IScheduledFlightsSelf = null;
        private FrmFuelTransaction frmFuelTransaction = null;
        private FrmScheduledFlightOther FrmFlightOther = null;
        private FrmDailyAvailableFlights FrmDailyFlights = null;        
        private AirlineMaster airlinemaster = null;
        private DataTable dataTable = null;

        #endregion [Object Declaration]

        #region [Variable Declarations] 

        string loginUser;
        bool IsRecordSelected;

        #endregion [Variable Declarations] 

        #region [Constructor]

        [InjectionConstructor]
        public FrmScheduledFlightSelf(IScheduledFlightsSelf iScheduledFlightsSelf) : this()
        {
            _IScheduledFlightsSelf = iScheduledFlightsSelf;
        }

        public FrmScheduledFlightSelf() : base("FrmScheduledFlightSelf")
        {
            InitializeComponent();
        }

        #endregion [Constructor]

        #region [Events]

        private void FrmScheduledFlightSelf_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = DateTime.Now.ToLongDateString();
            btnNewFlight.Enabled = false;
            GlobalVariable.Processed = false;
            loginUser = GlobalVariable.LoginUser;
            IsRecordSelected = false;            
            try
            {
                if (GlobalVariable.fids_flag == true)
                {
                    dataTable = new DataTable();
                    dataTable = _IScheduledFlightsSelf.GetFlightScheduleData(loginUser);
                    if (dataTable.Rows.Count == 0)
                    {
                        dataGrid.DataSource = dataTable;
                        btnProcessFuelling.Enabled = false;
                        ErrorMessage.DisplayMessage("No flight data available");
                    }
                    else
                        dataGrid.DataSource = dataTable;
                }
                else
                {
                    dataTable = new DataTable();
                    dataTable = _IScheduledFlightsSelf.GetFlightRescheduleData(loginUser);
                    if (dataTable.Rows.Count == 0)
                    {
                        dataGrid.DataSource = dataTable;
                        btnProcessFuelling.Enabled = false;
                        ErrorMessage.DisplayMessage("No flight data available");
                    }
                    else
                        dataGrid.DataSource =dataTable;
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        private void btnProcessFuelling_Click(object sender, EventArgs e)
        {
            if(IsRecordSelected==true)
            {
                this.Close();
                GlobalVariable.Processed = true;
                var container = DependencyInjector.Register();
                frmFuelTransaction = container.Resolve<FrmFuelTransaction>();               
                frmFuelTransaction.Show();
            }
            else
            {
                ErrorMessage.DisplayMessage("Please select record first then proceed further");
                return;
            }            
        }

        private void btnOtherSchedules_Click(object sender, EventArgs e)
        {
            GlobalVariable.Processed = false;
            this.Close();
            var container = DependencyInjector.Register();
            FrmFlightOther = container.Resolve<FrmScheduledFlightOther>();
            FrmFlightOther.ShowDialog();
        }

        private void btnDailyFlights_Click(object sender, EventArgs e)
        {
            GlobalVariable.Processed = false;
            this.Close();
            var container = DependencyInjector.Register();
            FrmDailyFlights = container.Resolve<FrmDailyAvailableFlights>();
            FrmDailyFlights.ShowDialog();
        }
        private void btnNewFlight_Click(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 1)
            {
                btnProcessFuelling.Enabled = true;
            }
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IsRecordSelected = true;
                DataGridViewRow selectedRow = dataGrid.Rows[e.RowIndex];
                FuelTransaction.airline_name = selectedRow.Cells[0].Value.ToString();
                FuelTransaction.flight_id = selectedRow.Cells[1].Value.ToString();
                FuelTransaction.flight_type = selectedRow.Cells[2].Value.ToString();
                FuelTransaction.supplier_code = selectedRow.Cells[3].Value.ToString();
                FuelTransaction.eta = selectedRow.Cells[4].Value.ToString();
                FuelTransaction.etd = selectedRow.Cells[5].Value.ToString();
                FuelTransaction.flight_origin = selectedRow.Cells[6].Value.ToString();
                FuelTransaction.final_destination = selectedRow.Cells[7].Value.ToString();

                var objResult = _IScheduledFlightsSelf.GetAirlineMasterData(FuelTransaction.airline_name).ToList<AirlineMaster>();
                if (objResult != null && objResult.Count > 0)
                {
                    if (!string.IsNullOrEmpty(FuelTransaction.flight_type) && FuelTransaction.flight_type == "DOMESTIC")
                    {
                        airlinemaster = new AirlineMaster();
                        airlinemaster = objResult.Where(x => x.airline_flag == "D").FirstOrDefault();
                    }
                    else
                    {
                        airlinemaster = new AirlineMaster();
                        airlinemaster = objResult.Where(x => x.airline_flag != "D").FirstOrDefault();
                    }
                    if (airlinemaster != null)
                    {
                        FuelTransaction.airline_code = airlinemaster.airline_code;
                        FuelTransaction.bill_to = airlinemaster.bill_to;
                        FuelTransaction.ship_to = airlinemaster.ship_to;
                        FuelTransaction.BillToName = airlinemaster.bill_to_name;
                        FuelTransaction.ShipToName = airlinemaster.ship_to_name;
                        FuelTransaction.AirlineFlag = airlinemaster.airline_flag;
                    }
                    else
                    {
                        MessageBox.Show("In - Sufficient Airline Data can not continue.... Please use New flight option for Fuelling ");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("In - Sufficient Airline Data can not continue.... Please use New flight option for Fuelling ");
                    return;
                }
                var lstResult = _IScheduledFlightsSelf.GetFlightScheduleData(FuelTransaction.flight_id, FuelTransaction.bill_to, FuelTransaction.supplier_code, FuelTransaction.AirlineFlag);
                if (lstResult != null)
                {
                    FuelTransaction.aircraft_type = lstResult[0];
                    FuelTransaction.TurboFlag = lstResult[1];
                }
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }                        
        }
        #endregion [Events]                
    }
}
