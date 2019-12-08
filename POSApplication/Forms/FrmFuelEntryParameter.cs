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
    public partial class FrmFuelEntryParameter : MasterForm
    {
        #region [Object Declaration] 

        private IFuelEntryParameter _IFuelEntryParameter;

        #endregion [Object Declaration]

        #region [Constructor]
        [InjectionConstructor]
        public FrmFuelEntryParameter(IFuelEntryParameter iFuelEntryParameter) : this()
        {
            _IFuelEntryParameter = iFuelEntryParameter;            
        }
        public FrmFuelEntryParameter():base("FrmFuelEntryParameter")
        {
            InitializeComponent();
        }
        #endregion [Constructor]

        #region [Variable Declaration]
        string Refuller;
        #endregion [Variable Declaration]

        #region [Events]
        private void FrmFuelEntryParameter_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = DateTime.Now.ToLongDateString();
            try
            {
                Refuller = GlobalVariable.Refuller;
                var ObjResult = _IFuelEntryParameter.GetDensityReference(Refuller);
                if(ObjResult!=null)
                {
                    txtDensity.Text = ObjResult.density > 0 ? ObjResult.density.ToString() : "";
                    txtTemperature.Text = ObjResult.temp > 0 ? ObjResult.temp.ToString() : "";
                    txtFuelBatchNo.Text =ObjResult.fuel_batch_no ?? "";
                }
                else
                {
                    var Result = _IFuelEntryParameter.GetDensityReference();
                    if(Result !=null)
                    {
                        Refuller = Result.storage_id;
                        txtDensity.Text = Result.density > 0 ? Result.density.ToString() : "";
                        txtTemperature.Text = Result.temp > 0 ? Result.temp.ToString() : "";
                        txtFuelBatchNo.Text = Result.fuel_batch_no ?? "";
                    }
                }
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool Flag = false;
            try
            {
                Flag = CheckValidations();
                if (Flag)
                {
                    if (MessageBox.Show("This Density / Temp./ Batch No.will be printed on ADR...Are you sure ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int res = _IFuelEntryParameter.UpdateDensityReference(Convert.ToDecimal(txtDensity.Text),Convert.ToDecimal(txtTemperature.Text), txtFuelBatchNo.Text, Refuller);
                        if (res > 0)
                        {
                            ErrorMessage.InformationMessage("Data saved successfully");
                            this.Close();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void btnKeypad_Click(object sender, EventArgs e)
        {

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDensity.Text = "";
            txtTemperature.Text = "";
            txtFuelBatchNo.Text = "";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion [Events]

        #region [Private Methods]
        /// <summary>
        /// This method is used to check form field validations.
        /// </summary>
        /// <returns>bool Flag</returns>
        private bool CheckValidations()
        {
            decimal density, temperature;
            bool flag = false;

            if (string.IsNullOrEmpty(txtDensity.Text))
            {
                ErrorMessage.DisplayMessage("Density should not be blank....Please enter observed Density");
                txtDensity.Focus();
                return false;
            }
            flag = decimal.TryParse(txtDensity.Text, out density);
            if (!flag)
            {
                ErrorMessage.DisplayMessage("Density should be in numeric format");
                txtDensity.Text = "";
                txtDensity.Focus();
                return false;
            }
            if (density < 740 || density > 850)
            {
                ErrorMessage.DisplayMessage("Density range is 740 to 850 kg/m3");                
                txtDensity.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTemperature.Text))
            {
                ErrorMessage.DisplayMessage("Tempereture should not be blank....Please enter observed Tempereture");
                txtTemperature.Focus();
                return false;
            }
            flag = decimal.TryParse(txtTemperature.Text, out temperature);
            if (!flag)
            {
                ErrorMessage.DisplayMessage("Temperature should be in numeric format");
                txtTemperature.Text = "";
                txtTemperature.Focus();
                return false;
            }
            if (temperature < 5 || temperature > 50)
            {
                ErrorMessage.DisplayMessage("Please enter tempereture between 5 Degree to 50 Degree");
                txtTemperature.Text = "";
                txtTemperature.Focus();
                return false;
            }
            if ((temperature * 100) % 25 != 0)
            {
                ErrorMessage.DisplayMessage("Decimal value should be multiple of .25");
                txtTemperature.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtFuelBatchNo.Text))
            {
                ErrorMessage.DisplayMessage("Batch no. should not be blank....Please enter fuel batch no.");
                txtFuelBatchNo.Focus();
                return false;
            }
            else if (txtFuelBatchNo.Text.Length > 75)
            {
                ErrorMessage.DisplayMessage("Fuel batch no. should be less than 75 characters");
                txtFuelBatchNo.Focus();
                return false;
            }
            return true;
        }
        #endregion [Private Methods]

    }
}
