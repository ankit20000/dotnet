using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntityLayer;
using Common;
using System.Diagnostics;
using PosApplication.Interfaces;
using Unity;
using POSApplication.Forms;

namespace POSApplication.Forms
{
    public partial class FrmLogin : MasterForm
    {
        #region [Object Declaration]
        private ILogin _ILogin = null;
        private ConfigurationInfo configurationinfo = null;
        private FrmInitLCF frmInitLCF;
        private FrmTransactions frmTransactions;
        private FrmConfiguration frmConfiguration;
        #endregion [Object Declaration]

        #region [Properties]
        private string CurrentDateTime { get; set; }
        #endregion [Properties]

        #region [Constructor]

        [InjectionConstructor]
        public FrmLogin(ILogin iLogin) : this()
        {
            _ILogin = iLogin;
        }
        public FrmLogin() : base("FrmLogin")  // call base class constructor and pass FormID as name  
        {
            InitializeComponent();
        }

        #endregion [Constructor]

        #region [Events]

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag;
            try
            {
                flag = CheckFormValidations();
                if (flag)
                {
                    GlobalVariable.LoginUser = txtUserName.Text;
                    GlobalVariable.shiftno = CmbShift.Text;
                    GlobalVariable.BusinessDay = dtBusinessDay.Value.ToString("dd/MM/yyyy");
                    CurrentDateTime = DateTime.Now.ToString("dd/MM/yyyy");
                    if (!string.IsNullOrEmpty(txtUserName.Text) && txtUserName.Text == "ADMIN")
                    {
                        if (!string.IsNullOrEmpty(txtPassword.Text) && txtPassword.Text == "afs.1234")
                        {
                            this.Hide();
                            var container = DependencyInjector.Register();
                            frmConfiguration = container.Resolve<FrmConfiguration>();
                            frmConfiguration.Show();                            
                        }
                        else
                        {
                            ErrorMessage.DisplayMessage("You have entered Wrong Password!");
                            txtPassword.Focus();
                            return;
                        }
                    }
                    else
                    {
                        if (DateTime.Compare(Convert.ToDateTime(GlobalVariable.BusinessDay), Convert.ToDateTime(CurrentDateTime)) > 0)
                        {
                            ErrorMessage.DisplayMessage("Future date is not allowed as future Day");
                            dtBusinessDay.Focus();
                            return;
                        }
                        if(CmbShift.Items.Count==0)
                        {
                            ErrorMessage.DisplayMessage("Configuration details are not available");
                            CmbShift.Focus();
                            return;
                        }
                        if (CmbShift.SelectedIndex == -1)
                        {
                            ErrorMessage.DisplayMessage("Please select Shift!");
                            CmbShift.Focus();
                            return;
                        }
                        configurationinfo = new ConfigurationInfo();
                        configurationinfo = _ILogin.GetConfigurationInfo();

                        flag = checkValidations(configurationinfo);
                        if (flag)
                        {
                            GlobalVariable.fids_flag = (string.IsNullOrEmpty(configurationinfo.remark3) || configurationinfo.remark3 == "N") ? false : true;
                            GlobalVariable.Meter_Type = configurationinfo.remark5;
                            GlobalVariable.BOServerIP = configurationinfo.bo_ip;
                            GlobalVariable.Refuller = configurationinfo.refuller_id;

                            bool UserExists = _ILogin.GetUserInfo(txtUserName.Text, txtPassword.Text);
                            if (UserExists)
                            {
                                GlobalVariable.Location = _ILogin.CheckLocation();
                                GlobalVariable.Refuller = _ILogin.CheckRefuller();
                                if (!string.IsNullOrEmpty(GlobalVariable.Location) && !string.IsNullOrEmpty(GlobalVariable.Refuller))
                                {
                                    this.Hide();                                  
                                    frmInitLCF = new FrmInitLCF();
                                    frmInitLCF.ShowDialog();
                                }
                                else
                                {
                                    ErrorMessage.DisplayMessage("No location details available, Please update location details!");
                                    return;
                                }
                            }
                            else
                            {                                
                                ErrorMessage.DisplayMessage("Invalid Username/password; Please enter valid username and password!");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtUserName.Focus();
                var lstShift = _ILogin.LoadShiftInfo();
                if (lstShift != null && lstShift.Count > 0)
                {
                    CmbShift.Items.AddRange(lstShift.ToArray());                    
                }                
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            frmTransactions = new FrmTransactions();
            frmTransactions.ShowDialog();
            this.Close();
        }
        #endregion [Events]

        #region [Private Methods]
        /// <summary>
        /// This method is used to check form field validations.
        /// </summary>
        /// <returns>bool flag</returns>
        private bool CheckFormValidations()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                txtUserName.Focus();
                ErrorMessage.DisplayMessage("Please enter UserName");
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                ErrorMessage.DisplayMessage("Please enter Password");
                return false;
            }
            return true;
        }
        /// <summary>
        /// This method is used to check validation regarding configuration settings
        /// </summary>
        /// <param name="configurationInfo">Pass Configuration Object</param>
        /// <returns>bool flag</returns>
        private bool checkValidations(ConfigurationInfo configurationInfo)
        {
            if (configurationInfo == null)
            {
                ErrorMessage.DisplayMessage("Please configure the refuller PC first");
                return false;
            }
            if (string.IsNullOrEmpty(configurationinfo.remark5))
            {
                ErrorMessage.DisplayMessage("Please configure the Meter Type first");
                return false;
            }
            if (string.IsNullOrEmpty(configurationinfo.bo_ip))
            {
                ErrorMessage.DisplayMessage("Please configure the BO IP address first");
                return false;
            }
            if (string.IsNullOrEmpty(configurationinfo.refuller_id))
            {
                ErrorMessage.DisplayMessage("Please configure the Refueller first");
                return false;
            }
            return true;
        }
        #endregion [Private Methods]
    }
}
