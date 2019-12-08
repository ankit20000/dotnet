using System;
using Common;
using DataAccessLayer;
using PosApplication.Interfaces;

namespace POSApplication.Forms
{
    public partial class FrmExportData : MasterForm
    {
        #region Declarations

        IExportData _IExportData = null;

        #endregion

        #region Cunstructor Initialization
        public FrmExportData()
        {
            InitializeComponent();
            _IExportData = new ExportData();
        }
        #endregion

        #region Form Load
        private void FrmExportData_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = DateTime.Now.ToLongDateString();
            GetFormLoadData();
        }
        #endregion

        #region GetForm Load Data
        public void GetFormLoadData()
        {
            try
            {
                dataGridView1.DataSource = _IExportData.GetFormLoadData();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        #endregion

        #region Events
        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = _IExportData.GetDataByDate(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        private void rdbUncompressed_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbPreviousData_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
