using BusinessEntityLayer;
using Common;
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

namespace POSApplication.Forms
{
    public partial class FrmRefuellerToTank : MasterForm
    {
        #region [Object Declaration]

        private IFuelEntryParameter _IFuelEntryParameter;
        private IStockTransfer _IStockTransfer;
        private FrmStockTransferStart frmStockTransferStart;
        private StockTransfer objStockTransfer;
        #endregion [Object Declaration]

        #region [Constructor]
        public FrmRefuellerToTank()
        {
            InitializeComponent();
            _IStockTransfer = new StockTransferConcrete();
            _IFuelEntryParameter = new FuelEntryParameterConcrete();
        }
        #endregion [Constructor]

        #region [Events]
        private void FrmRefuellerToTank_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = DateTime.Now.ToLongDateString();
            string refueller = GlobalVariable.Refuller ?? string.Empty;
            try
            {
                var objResult = _IFuelEntryParameter.GetDensityReference(refueller);
                if (objResult != null)
                {
                    txtDensity.Text = objResult.density.ToString();
                    txtTemperature.Text = objResult.temp.ToString();
                    CmbFuelBatchNo.Items.Add(objResult.fuel_batch_no);
                    CmbFuelBatchNo.Text = objResult.fuel_batch_no;
                }
                var lstTankNos = _IStockTransfer.GetTankMaster();
                if (lstTankNos != null && lstTankNos.Count > 0)
                {
                    cmbDestination.Items.AddRange(lstTankNos.ToArray());
                    cmbDestination.Text = lstTankNos.FirstOrDefault().ToString();
                }
                else
                {
                    ErrorMessage.DisplayMessage("No Tanks is Available");
                    return;
                }
                cmbDestination.Focus();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            byte result = 0, devStatus = 0;
            byte[] deviceList = new byte[1];
            bool flag = false;
            try
            {
                flag = CheckFormValidations();
                if (flag)
                {
                    if (GlobalVariable.Meter_Type == Constants.LCMeterType)
                    {
                        if (GlobalVariable.LCFInit != 1)
                        {
                            result = LCMeterLibrary.LCP02Open(Constants.minDevice, Constants.maxDevice, ref devStatus, deviceList);
                            if (result == 0 || result != LCMeterLibrary.LCP02Ra_ALREADYOPENED)
                            {
                                ErrorMessage.DisplayMessage("LCR Open Error");
                                result = LCMeterLibrary.LCP02Close();
                                return;
                            }
                        }
                    }
                    frmStockTransferStart = new FrmStockTransferStart();
                    frmStockTransferStart.stockTransfer = GetStockTransfer();
                    frmStockTransferStart.Show();
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        private void btnKeypad_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO You want to Cancel ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion [Events]

        #region [Private Methods]
        /// <summary>
        /// This method is used to check form field validations.
        /// </summary>
        /// <returns>Validation Message</returns>
        private bool CheckFormValidations()
        {
            decimal temperature;
            bool flag = false;

            if (string.IsNullOrEmpty(cmbDestination.Text))
            {
                ErrorMessage.DisplayMessage("Please select destination tank");
                cmbDestination.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDensity.Text))
            {
                ErrorMessage.DisplayMessage("Please enter Density");
                txtDensity.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTemperature.Text))
            {
                ErrorMessage.DisplayMessage("Please enter Temperature");
                txtTemperature.Focus();
                return false;
            }
            flag = decimal.TryParse(txtTemperature.Text, out temperature);
            if (flag)
            {
                if (temperature < 5 || temperature > 60)
                {
                    ErrorMessage.DisplayMessage("Please enter Temperature between 5 to 60 degree");
                    txtTemperature.Text = "";
                    txtTemperature.Focus();
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// This method is used to initialise form controls values with stock transfer object properties.
        /// </summary>
        /// <returns>Stock Transfer Object</returns>
        private StockTransfer GetStockTransfer()
        {
            objStockTransfer = new StockTransfer();
            objStockTransfer = new StockTransfer();
            objStockTransfer.destination = cmbDestination.Text;
            objStockTransfer.density = Convert.ToDecimal(txtDensity.Text);
            objStockTransfer.temperature = Convert.ToDecimal(txtTemperature.Text);
            objStockTransfer.fuel_batch_no = CmbFuelBatchNo.Text;
            return objStockTransfer;
        }
        #endregion [Private Methods]
    }
}
