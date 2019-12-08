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
    public partial class FrmConfiguration : MasterForm
    {
        #region [Object Declaration]
        IConfiguration _IConfiguration = null;
        ILogin _ILogin = null;
        ConfigurationInfo configurationinfo;
        #endregion [Object Declaration]

        #region [Constructor]

        [InjectionConstructor]
        public FrmConfiguration(IConfiguration iconfiguration, ILogin ilogin) : this()
        {
            _IConfiguration = iconfiguration;
            _ILogin = ilogin;
        }
        public FrmConfiguration()
        {
            InitializeComponent();
        }
        #endregion [Constructor]

        #region [Properties]
        public string last_no { get; set; }
        public string last_no_oth { get; set; }
        #endregion [Properties]

        #region [Events]
        private void FrmConfiguration_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = DateTime.Now.ToLongDateString();
            configurationinfo = new ConfigurationInfo();
            try
            {
                var lstRefuller = _IConfiguration.LoadRefuller();
                if (lstRefuller != null && lstRefuller.Count > 0)
                {
                    cmbRefuller.Items.AddRange(lstRefuller.ToArray());
                }
                else
                {
                    ErrorMessage.DisplayMessage("Atleast one refuller is required");
                    return;
                }

                configurationinfo = _ILogin.GetConfigurationInfo();
                if (configurationinfo != null)
                {
                    cmbRefuller.Text = (!string.IsNullOrEmpty(configurationinfo.refuller_id)) ? configurationinfo.refuller_id : "";
                    txtBOIPAddress.Text = (!string.IsNullOrEmpty(configurationinfo.bo_ip)) ? configurationinfo.bo_ip : "";
                    if (!string.IsNullOrEmpty(configurationinfo.inv_series))
                    {
                        txtADRTransaction.Text = configurationinfo.inv_series;
                        last_no = configurationinfo.inv_series;
                    }
                    else
                    {
                        txtADRTransaction.Text = "10000";
                        last_no = "10000";
                    }
                    txtDGCANumber.Text = (!string.IsNullOrEmpty(configurationinfo.remark1)) ? configurationinfo.remark1 : " ";
                    txtIATACode.Text = (!string.IsNullOrEmpty(configurationinfo.remark2)) ? configurationinfo.remark2 : " ";
                    cmbFlowMeter.Text = (!string.IsNullOrEmpty(configurationinfo.remark5)) ? configurationinfo.remark5 : "";
                    txtOtherTransaction.Text = (!string.IsNullOrEmpty(configurationinfo.oth_series)) ? configurationinfo.oth_series : " ";
                    last_no_oth = txtOtherTransaction.Text;
                }
                else
                {
                    ErrorMessage.DisplayMessage("The system is not configured...please configure first");
                    return;
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result;
            configurationinfo = new ConfigurationInfo();
            bool Flag = false;
            try
            {
                Flag = CheckFormValidations();
                if (Flag)
                {
                    result = MessageBox.Show("Are you sure want to save record?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(last_no) > Convert.ToInt32(txtADRTransaction.Text))
                        {
                            if (MessageBox.Show("Last system generated transaction no. is greater than new transaction series...", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                            if (Convert.ToInt32(txtADRTransaction.Text) == 10000)
                            {
                                if (MessageBox.Show("Transaction series is 10000. Are you sure to save?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                            }
                        }
                        if (Convert.ToInt32(last_no_oth) > Convert.ToInt32(txtOtherTransaction.Text))
                        {
                            if (MessageBox.Show("Last system generated  CS/ST transaction no. is greater than new other transaction", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                            if (Convert.ToInt32(txtOtherTransaction.Text) == 10000)
                            {
                                if (MessageBox.Show("Other transaction series is 10000. Are you sure to save?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                            }
                        }
                        configurationinfo = _ILogin.GetConfigurationInfo();

                        configurationinfo.refuller_id = cmbRefuller.Text.ToUpper() ?? string.Empty;
                        configurationinfo.bo_ip = txtBOIPAddress.Text ?? string.Empty;
                        configurationinfo.remark1 = txtDGCANumber.Text.ToUpper() ?? string.Empty;
                        configurationinfo.remark2 = txtIATACode.Text.ToUpper() ?? string.Empty;
                        configurationinfo.remark5 = cmbFlowMeter.Text.ToUpper() ?? string.Empty;
                        configurationinfo.oth_series = txtOtherTransaction.Text ?? string.Empty;

                        if (configurationinfo != null)
                        {
                            configurationinfo.inv_series = txtADRTransaction.Text ?? string.Empty;
                            _IConfiguration.UpdateConfigInfo(configurationinfo);
                        }
                        else
                        {
                            _IConfiguration.SaveConfigInfo(configurationinfo);
                        }
                        ErrorMessage.InformationMessage("System configured successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void btnImportData_Click(object sender, EventArgs e)
        {
            var container = DependencyInjector.Register();
            var form = container.Resolve<FrmImportData>();
            form.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion [Events]

        #region [Private Methods]
        /// <summary>
        /// This method is used to check form field validations.
        /// </summary>
        /// <returns>Validation Message</returns>
        private bool CheckFormValidations()
        {
            string Message = string.Empty;
            if (string.IsNullOrEmpty(cmbRefuller.Text))
            {
                cmbRefuller.Focus();
                ErrorMessage.DisplayMessage("Please enter Refuller");
                return false;
            }
            if (cmbFlowMeter.Text == "")
            {
                cmbFlowMeter.Focus();
                ErrorMessage.DisplayMessage("Please select Flow Meter Type");
                return false;
            }
            if (string.IsNullOrEmpty(txtBOIPAddress.Text))
            {
                txtBOIPAddress.Focus();
                ErrorMessage.DisplayMessage("Please enter Back-Office IP Address");
                return false;
            }
            if (string.IsNullOrEmpty(txtDGCANumber.Text))
            {
                txtDGCANumber.Focus();
                ErrorMessage.DisplayMessage("Please enter DGCA Approval Number");
                return false;
            }
            if (string.IsNullOrEmpty(txtIATACode.Text))
            {
                txtIATACode.Focus();
                ErrorMessage.DisplayMessage("Please enter Location IATA Code");
                return false;
            }
            if (string.IsNullOrEmpty(txtADRTransaction.Text))
            {
                txtADRTransaction.Focus();
                ErrorMessage.DisplayMessage("Please enter last system generated ADR transaction no. of this refuller");
                return false;
            }
            if (string.IsNullOrEmpty(txtOtherTransaction.Text))
            {
                txtOtherTransaction.Focus();
                ErrorMessage.DisplayMessage("Please enter last system generated CT/ST transaction no. of this refuller");
                return false;
            }
            return true;
        }
        #endregion [Private Methods]

    }
}
