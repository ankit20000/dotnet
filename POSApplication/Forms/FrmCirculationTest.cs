using Common;
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
    public partial class FrmCirculationTest : MasterForm
    {
        FrmCirculationTestStart frmCirculationTestStart;        
        byte result, devStatus = 0;
        byte[] deviceList = new byte[1];
        public FrmCirculationTest()
        {
            InitializeComponent();
        }

        private void FrmCirculationTest_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = DateTime.Now.ToLongDateString();
            CmbCirculationType.Focus();
            CmbCirculationType.Items.Add("Circulation");
            CmbCirculationType.Items.Add("Nozzle Calibration");
            CmbCirculationType.Text = "Circulation";
        }
        private void btnCirculationTest_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(CmbCirculationType.Text))
            {
                ErrorMessage.DisplayMessage("Please Select Test Type");
                CmbCirculationType.Focus();
                return;
            }
            if(string.IsNullOrEmpty(CmbReason.Text))
            {
                ErrorMessage.DisplayMessage("Please Select Reason");
                CmbReason.Focus();
                return;
            }
            GlobalVariable.CirculationType = CmbCirculationType.Text;
            GlobalVariable.Reason = CmbReason.Text;
            if(GlobalVariable.Meter_Type==Constants.LCMeterType)
            {
                if(GlobalVariable.LCFInit !=1)
                {
                    result = LCMeterLibrary.LCP02Open(Constants.minDevice, Constants.maxDevice, ref devStatus,deviceList);
                    if(result !=0 && result != LCMeterLibrary.LCP02Ra_ALREADYOPENED)
                    {
                        ErrorMessage.DisplayMessage("LCR Open Error");
                        result = LCMeterLibrary.LCP02Close();
                        return;
                    }
                }
            }
            this.Close();
            frmCirculationTestStart = new FrmCirculationTestStart();
            frmCirculationTestStart.Show();            
        }
        private void CmbCirculationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCirculationType.Text.ToUpper() == Constants.CirculationType)
            {
                CmbReason.Items.Clear();
                CmbReason.Items.Add("Hose Flushing");
                CmbReason.Items.Add("After Maintenance");
                CmbReason.Items.Add("After Defuelling");
                CmbReason.Items.Add("QC Check");
                CmbReason.Items.Add("Other");
            }
            if(CmbCirculationType.Text.ToUpper() == Constants.NozzelType)
            {
                CmbReason.Items.Clear();
                CmbReason.Items.Add("Meter Calibration");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do You want to Cancel ?","Information",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Close();
            }
        }       
    }
}
