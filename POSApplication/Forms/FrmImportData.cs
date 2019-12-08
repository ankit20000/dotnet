using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using DataAccessLayer;
using PosApplication.Interfaces;

namespace POSApplication.Forms
{
    public partial class FrmImportData : MasterForm
    {
        #region Declarations

        IImportData _IImportData = null;
        FrmImportData frmImportData;

        #endregion

        #region Cunstructor Initialization
        public FrmImportData()
        {
            InitializeComponent();
            _IImportData = new ImportData();
        }
        #endregion

        #region Form Load
        private void FrmImportData_Load(object sender, EventArgs e)
        {
            PopulateCheckBoxes();
            //_IImportData.GetMasterTables();
        }
        #endregion

        #region Events
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in CheckBoxPanel.Controls)
                {
                    CheckBox chk = item as CheckBox;

                    if (chk.Checked)
                    {
                        chk.Checked = false;
                        btnSelectAll.Text = "SELECT ALL";
                    }
                    else
                    {
                        chk.Checked = true;
                        btnSelectAll.Text = "UNCHECK ALL";
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        
        private void btnImport_Click(object sender, EventArgs e)
        {
            List<string> lstTableName = new List<string>();
            string alertMessage = string.Empty;

            try
            {
                foreach (var item in CheckBoxPanel.Controls)
                {
                    CheckBox chk = item as CheckBox;

                    if (chk.Checked)
                    {
                        lstTableName.Add(chk.Name);
                    }
                }

                if (lstTableName.Count > 0)
                {
                    alertMessage = _IImportData.ImportMasterTables(lstTableName);
                }
                else
                {
                    alertMessage = "Please Select atleast one Table!";
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }

            MessageBox.Show(alertMessage, "Message Box");
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        #endregion

        #region PopulateCheckBoxes
        private void PopulateCheckBoxes()
        {
            try
            {
                DataTable lstMasterTable = _IImportData.GetMasterTables();

                foreach (DataRow row in lstMasterTable.Rows)
                {
                    CheckBox chk = new CheckBox();
                    chk.Width = 300;
                    chk.Height = 50;
                    chk.Name = row[0].ToString();
                    chk.Text = row[1].ToString();
                    //chk.CheckedChanged += new EventHandler(CheckBox_Checked);
                    CheckBoxPanel.Controls.Add(chk);
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        #endregion
    }
}
