using BusinessEntityLayer;
using DataAccessLayer;
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
    public partial class FrmAircraftRegNo : MasterForm
    {
        #region [Object Declaration]

        private FuelTransactionConcrete objFuelTransactionConcrete = null;        
        private FrmFuelTransaction frmFuelTransaction = null;
        
        #endregion [Object Declaration]

        #region [Constructor]
        public FrmAircraftRegNo() : base("FrmAircraftRegNo")
        {            
            InitializeComponent();            
        }
        #endregion [Constructor]

        #region [Properties]
        public string AirlineCode { get; set; }
        public bool notfound { get; set; }
        public bool IsRecordSelected { get; set; }

        #endregion [Properties]

        #region [Events]
        private void FrmAircraftRegNo_Load(object sender, EventArgs e)
        {
            try
            {
                objFuelTransactionConcrete = new FuelTransactionConcrete();                
                DataSet ds = objFuelTransactionConcrete.GetAirlineRegMaster(AirlineCode);
                if (ds.Tables[0].Rows.Count == 0)
                {                   
                    MessageBox.Show("airline code not found in airline_regno_master table");
                    return;
                }
                else
                {                    
                    dataGrid.DataSource = ds.Tables["airline_regno_master"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if(IsRecordSelected==true)
                {                   
                    var container = DependencyInjector.Register();
                    frmFuelTransaction = container.Resolve<FrmFuelTransaction>();                    
                    frmFuelTransaction.Flag = true;
                    frmFuelTransaction.Focus();
                    frmFuelTransaction.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select record to proceed further...");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IsRecordSelected = true;
            DataGridViewRow selectedRow = dataGrid.Rows[e.RowIndex];           
            FuelTransaction.airline_code = selectedRow.Cells[0].Value.ToString();
            FuelTransaction.RegistrationNo = selectedRow.Cells[1].Value.ToString();
            FuelTransaction.TurboProp = selectedRow.Cells[2].Value.ToString();
            FuelTransaction.offtakeweight = selectedRow.Cells[3].Value.ToString();
            FuelTransaction.wide_body = selectedRow.Cells[4].Value.ToString();
            FuelTransaction.aircraft_type = selectedRow.Cells[5].Value.ToString();           
        }

        #endregion [Events]

        private void btnClose_Click(object sender, EventArgs e)
        {            
            var container = DependencyInjector.Register();
            frmFuelTransaction = container.Resolve<FrmFuelTransaction>();
            frmFuelTransaction.Flag = false;
            frmFuelTransaction.Show();
            this.Close();
        }
    }
}
