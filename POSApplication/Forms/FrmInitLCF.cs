using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace POSApplication.Forms
{
    public partial class FrmInitLCF : MasterForm
    {
        #region [Object Declaration]
        FrmTransactions frmTransaction;
        private MeterFunctions meterFunctions = null;
        #endregion [Object Declaration]

        #region [Variable Declaration] 
        int count = 0;
        byte result;
        long lval = 0;
        #endregion [Variable Declaration]

        #region [Constructor]
        public FrmInitLCF() : base("FrmInitLCF")
        {
            InitializeComponent();
        }
        #endregion [Constructor]

        #region [Events]
        private void FrmInitLCF_Load(object sender, EventArgs e)
        {
            lblRetry.Visible = false;
            lblMeterType.Text = GlobalVariable.Meter_Type;
            timer1.Interval = 1;
            timer2.Interval = 5000;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            byte Data = 0;
            byte[] devices = new byte[1];

            try
            {
                if (GlobalVariable.Meter_Type == Constants.LCMeterType)
                {
                    result = LCMeterLibrary.LCP02Open(Constants.minDevice, Constants.maxDevice, ref Data, devices);
                    if (result != 0 && result != LCMeterLibrary.LCP02Ra_ALREADYOPENED)
                    {
                        count = count + 1;
                        if (count != 7)
                        {
                            lblRetry.Visible = true;
                            lblRetry.Text = "Retry=" + (count + 1);
                            result = LCMeterLibrary.LCP02Close();
                        }
                        else
                        {
                            this.Close();
                            ErrorMessage.DisplayMessage("Unable to Control on LCF Meter");
                        }
                        return;
                    }
                    result = LCMeterLibrary.LCP02IssueCommand(Constants.minDevice, LCMeterLibrary.LCRC_RUN, LCMeterLibrary.LCRM_WAIT);
                    timer1.Interval = 1;
                    timer2.Interval = 5000;
                }
                else if (GlobalVariable.Meter_Type == Constants.ISOILMeterType)
                {
                    meterFunctions = new MeterFunctions();
                    lval = ISOILLibrary.checkStatus(1);
                    if (lval == 0)
                    {
                        ErrorMessage.DisplayMessage("Unable to get control on ISOIL Flow Meter");
                        return;
                    }
                    long res = meterFunctions.getMeterStart();
                    if (res == 0)
                    {
                        ErrorMessage.DisplayMessage("ISOIL meter error!");
                        return;
                    }

                    lval = ISOILLibrary.switching(1);
                    if (lval != 1)
                    {
                        ErrorMessage.DisplayMessage("ISOIL meter error!");
                        return;
                    }
                    timer1.Interval = 1;
                    timer2.Interval = 5000;
                }
                else
                {
                    ErrorMessage.DisplayMessage("No Flow Meter is configured");
                    return;
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            byte result;
            try
            {
                if (GlobalVariable.Meter_Type == Constants.LCMeterType)
                {
                    result = LCMeterLibrary.LCP02IssueCommand(Constants.minDevice, LCMeterLibrary.LCRC_RUN, LCMeterLibrary.LCRM_WAIT);
                    GlobalVariable.LCFInit = 1;
                    frmTransaction = new FrmTransactions();
                    frmTransaction.Show();
                    this.Close();
                }
                else if (GlobalVariable.Meter_Type == Constants.ISOILMeterType)
                {
                    lval = ISOILLibrary.switching(2);
                    if (lval != 2)
                    {
                        ErrorMessage.DisplayMessage("ISOIL meter error!");
                        return;
                    }
                    else
                    {
                        GlobalVariable.LCFInit = 1;
                        frmTransaction = new FrmTransactions();
                        frmTransaction.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No Flow Meter is configured");
                    return;
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }            
        }
        #endregion [Events]       
    }
}

