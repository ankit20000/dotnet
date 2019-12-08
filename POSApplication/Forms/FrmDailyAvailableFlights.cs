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
using Unity.Injection;
using Unity.Resolution;

namespace POSApplication.Forms
{    
    public partial class FrmDailyAvailableFlights : MasterForm
    {
        #region [Object Declaration]
        private IDailyAvailableFlights _IDailyAvailableFlights = null;
        private FrmFuelTransaction frmFuelTransaction = null;
        private FrmScheduledFlightOther FrmFlightOther = null;
        private FrmScheduledFlightSelf FrmFlightSelf = null;       
        #endregion [Object Declaration]

        #region [Variable Declarations] 
        bool IsRecordSelected;
        #endregion [Variable Declarations] 

        #region [Constructor]
        [InjectionConstructor]
        public FrmDailyAvailableFlights(IDailyAvailableFlights iDailyAvailableFlights) : this()
        {
            _IDailyAvailableFlights = iDailyAvailableFlights;
        }
        public FrmDailyAvailableFlights() : base("FrmDailyAvailableFlights")
        {
            InitializeComponent();
        }
        #endregion [Constructor]        

        #region [Events]
        private void FrmDailyAvailableFlights_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = DateTime.Now.ToLongDateString();
            IsRecordSelected = false;
            DataSet ds = new DataSet();
            try
            {
                int dayno = ReturnDayValue(DateTime.Now.DayOfWeek.ToString());
                GlobalVariable.Processed = false;

                if (GlobalVariable.fids_flag == true)
                {
                    ds = _IDailyAvailableFlights.GetFlightMastersData();
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        btnProcessFuelling.Enabled = false;
                        ErrorMessage.DisplayMessage("No flight data available");
                    }
                    else
                        dataGrid.DataSource = ds.Tables[0];
                }
                else
                {
                    ds = _IDailyAvailableFlights.GetFlightScheduleNews(dayno);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        btnProcessFuelling.Enabled = false;
                        ErrorMessage.DisplayMessage("No flight data available");
                    }
                    else
                        dataGrid.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        private void btnProcessFuelling_Click_1(object sender, EventArgs e)
        {
            if (IsRecordSelected == true)
            {
                this.Close();
                var container = DependencyInjector.Register();
                frmFuelTransaction = container.Resolve<FrmFuelTransaction>();                
                frmFuelTransaction.Show();
            } 
            else
                ErrorMessage.DisplayMessage("Please select record first then proceed further");
            
        }

        private void btnOperatorSchedules_Click_1(object sender, EventArgs e)
        {
            GlobalVariable.DFProcessed = false;
            this.Close();
            var container = DependencyInjector.Register();
            FrmFlightSelf = container.Resolve<FrmScheduledFlightSelf>();
            FrmFlightSelf.ShowDialog();
        }
        private void btnOtherSchedules_Click(object sender, EventArgs e)
        {
            GlobalVariable.DFProcessed = false;
            this.Close();
            var container = DependencyInjector.Register();
            FrmFlightOther = container.Resolve<FrmScheduledFlightOther>();
            FrmFlightOther.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid_Click_1(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 1)            
                btnProcessFuelling.Enabled = true;           
            else
                btnProcessFuelling.Enabled = false;
        }
        private void dataGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IsRecordSelected = true;
                DataGridViewRow selectedRow = dataGrid.Rows[e.RowIndex];
                FuelTransaction.airline_name = selectedRow.Cells[0].Value.ToString();
                FuelTransaction.BillToName = selectedRow.Cells[0].Value.ToString();
                FuelTransaction.ShipToName = selectedRow.Cells[0].Value.ToString();
                FuelTransaction.flight_id = selectedRow.Cells[1].Value.ToString();
                FuelTransaction.flight_type = selectedRow.Cells[2].Value.ToString();
                FuelTransaction.supplier_code = selectedRow.Cells[3].Value.ToString();
                FuelTransaction.eta = selectedRow.Cells[4].Value.ToString();
                FuelTransaction.etd = selectedRow.Cells[5].Value.ToString();
                FuelTransaction.flight_origin = selectedRow.Cells[6].Value.ToString();
                FuelTransaction.final_destination = selectedRow.Cells[7].Value.ToString();
                FuelTransaction.aircraft_type = selectedRow.Cells[8].Value.ToString();
                GlobalVariable.DFProcessed = true;

                if (selectedRow.Cells[2].Value.ToString().ToUpper() == "DOM")
                    FuelTransaction.AirlineFlag = "D";
                else if (selectedRow.Cells[2].Value.ToString().ToUpper() == "INT")
                    FuelTransaction.AirlineFlag = "I";

                var objResult = _IDailyAvailableFlights.GetFlightScheduleNew(FuelTransaction.flight_id);
                if (objResult != null)
                {
                    FuelTransaction.airline_code = objResult.airline_code;
                    FuelTransaction.bill_to = objResult.bill_to;
                    FuelTransaction.ship_to = objResult.ship_to;
                    FuelTransaction.product_type = objResult.product_type;
                }
                else
                {
                    ErrorMessage.DisplayMessage("In-Sufficient Airline Data can not continue...,Please continue manual Fuelling");
                    return;
                }
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void btnNewFlight_Click_1(object sender, EventArgs e)
        {
            ErrorMessage.WarningMessage("Without schedule FUELLING cannot be done");
        }
        #endregion [Events]

        #region [Private Methods]
        /// <summary>
        /// This method is used to send day number in week.
        /// </summary>
        /// <param name="day">Parameter of type string</param>
        /// <returns>Integer type Day</returns>
        public int ReturnDayValue(string day)
        {
            int dayvalue = 0;
            switch (day)
            {
                case "Monday":
                    dayvalue = (int)DayOfWeek.Monday;
                    break;
                case "Tuesday":
                    dayvalue = (int)DayOfWeek.Tuesday;
                    break;
                case "Wednesday":
                    dayvalue = (int)DayOfWeek.Wednesday;
                    break;
                case "Thursday":
                    dayvalue = (int)DayOfWeek.Thursday;
                    break;
                case "Friday":
                    dayvalue = (int)DayOfWeek.Friday;
                    break;
                case "Saturday":
                    dayvalue = (int)DayOfWeek.Saturday;
                    break;
                case "Sunday":
                    dayvalue = (int)DayOfWeek.Sunday;
                    break;
            }
            return dayvalue;
        }
        #endregion [Private Methods]        
    }
}
