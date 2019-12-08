﻿using BusinessEntityLayer;
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
    public partial class FrmStockTransferLCMeter : MasterForm
    {
        #region [Object Declaration]
        private IStockTransfer _StockTransfer;
        private ICirculationTest _ICirculationTest;
        private StockTransfer stockTransfer = null;
        private MeterFunctions meterFunctions = null;
        private ILogin _ILogin;
        private IPrintReceipt _IPrintReceipt;
        #endregion [Object Declaration]

        #region [Constructor]
        public FrmStockTransferLCMeter() : base("FrmStockTransferLCMeter")
        {
            InitializeComponent();
        }
        [InjectionConstructor]
        public FrmStockTransferLCMeter(IStockTransfer iStockTransfer, ICirculationTest iCirculationTest, ILogin iLogin, IPrintReceipt iPrintReceipt) : this()
        {
            _StockTransfer = iStockTransfer;
            _ICirculationTest = iCirculationTest;
            _ILogin = iLogin;
            _IPrintReceipt = iPrintReceipt;
        }
        #endregion [Constructor]

        #region [Variable Declaration]
        byte result = 0;
        string FuelStartTime, FuelEndTime, ReadyToFuel, FinalClearance, OtherSeries, InvoiceNo;
        long lval;
        #endregion [Variable Declaration]

        #region [Properties]
        private string destination { get; set; }
        private decimal? density { get; set; }
        public decimal? temp { get; set; }
        public string fuelbatchno { get; set; }
        #endregion [Properties]

        #region [Events]
        private void FrmStockTransferLCMeter_Load(object sender, EventArgs e)
        {
            SetControlVisibility(false);
            meterFunctions = new MeterFunctions();
            lblCurrentDate.Text = DateTime.Now.ToLongDateString();
            FuelStartTime = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
            ReadyToFuel = FuelStartTime;
            try
            {
                if (GlobalVariable.Meter_Type == Constants.LCMeterType)
                {
                    txtEquipementNo.Text = meterFunctions.GetEquipementNumber() ?? string.Empty;

                    txtMeterStartReading.Text = meterFunctions.GetMeterStartReading() ?? string.Empty;

                    txtFuellingStartTime.Text = FuelStartTime;

                    result = LCMeterLibrary.LCP02IssueCommand(Constants.device, LCMeterLibrary.LCRC_RUN, LCMeterLibrary.LCRM_WAIT);
                    timer1.Interval = 1000;
                    return;
                }
                else if (GlobalVariable.Meter_Type == Constants.ISOILMeterType)
                {
                    if (GlobalVariable.LCFInit != 1)
                    {
                        meterFunctions = new MeterFunctions();
                        meterFunctions.getMeterStart();
                        txtFuellingStartTime.Text = FuelStartTime;
                        txtMeterStartReading.Text = GlobalVariable.MeterStart.ToString();

                        lval = ISOILLibrary.switching(1);
                        if (lval != 1)
                        {
                            ErrorMessage.DisplayMessage("ISOIL meter Error");
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        txtFuellingStartTime.Text = FuelStartTime;
                        txtMeterStartReading.Text = GlobalVariable.MeterStart.ToString();

                        lval = ISOILLibrary.switching(1);
                        if (lval != 3)
                        {
                            ErrorMessage.DisplayMessage("ISOIL meter Error");
                            this.Close();
                            return;
                        }
                    }
                    timer1.Interval = 1000;
                }
                else
                {
                    ErrorMessage.DisplayMessage("Please configure meter type");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            FinalClearance = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
            try
            {
                if (GlobalVariable.Meter_Type == Constants.LCMeterType)
                {
                    result = LCMeterLibrary.LCP02IssueCommand(Constants.device, LCMeterLibrary.LCRC_STOP, LCMeterLibrary.LCRM_WAIT);

                    if (MessageBox.Show("Are You Sure for Final Clearance?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        result = LCMeterLibrary.LCP02IssueCommand(Constants.device, LCMeterLibrary.LCRC_RUN, LCMeterLibrary.LCRM_WAIT);
                        return;
                    }
                    result = LCMeterLibrary.LCP02IssueCommand(Constants.device, LCMeterLibrary.LCRC_END_DELIVERY, LCMeterLibrary.LCRM_WAIT);
                    GlobalVariable.LCFInit = 0;
                    timer1.Interval = 1;
                    FuelEndTime = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
                    SetControlVisibility(true);

                    GetData();

                    OtherSeries = GetOtherSeries();
                    InvoiceNo = GlobalVariable.Location + "ST" + GlobalVariable.Refuller + OtherSeries;

                    stockTransfer = new StockTransfer();
                    stockTransfer = GetStockTransferObject();
                    _StockTransfer.SaveStockTransfer(stockTransfer);
                    _ICirculationTest.UpdateConfigurationDetails(OtherSeries, txtMeterEndReading.Text);

                    MessageBox.Show("Invoice No: " + InvoiceNo + " Generated and  saved in database", "SuccessMessage", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Do You want to take print?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _IPrintReceipt.PrintStockTransferLC(stockTransfer);
                    }
                    result = LCMeterLibrary.LCP02Close();
                }
                else if (GlobalVariable.Meter_Type == Constants.LCMeterType)
                {
                    lval = ISOILLibrary.switching(2);
                    if (lval != 2)
                    {
                        ErrorMessage.DisplayMessage("ISOIL meter Error");
                        this.Close();
                        return;
                    }
                    getQtyMeter();
                    if (MessageBox.Show("Are You Sure for Final Clearance?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        SetControlVisibility(false);

                        lval = ISOILLibrary.switching(3);
                        if (lval != 3)
                        {
                            ErrorMessage.DisplayMessage("ISOIL meter Error");
                            this.Close();
                            return;
                        }
                        return;
                    }
                    lval = ISOILLibrary.switching(4);
                    if (lval != 4)
                    {
                        ErrorMessage.DisplayMessage("ISOIL meter Error");
                        this.Close();
                        return;
                    }
                    GlobalVariable.LCFInit = 0;
                    timer1.Interval = 1;
                    FuelEndTime = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
                    txtFuellingEndTime.Text = FuelEndTime;

                    getQtyMeter();

                    OtherSeries = GetOtherSeries();
                    InvoiceNo = GlobalVariable.Location + "CT" + GlobalVariable.Refuller + OtherSeries;

                    stockTransfer = new StockTransfer();
                    stockTransfer = GetStockTransferObject();
                    _ICirculationTest.SaveStockTransfer(stockTransfer);
                    _ICirculationTest.UpdateConfigurationDetails(OtherSeries, txtMeterEndReading.Text);

                    MessageBox.Show("Invoice No: " + InvoiceNo + " Generated and  saved in database", "SuccessMessage", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Do You want to take print?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _IPrintReceipt.PrintStockTransferISOIL(stockTransfer);
                    }
                }
                else
                {
                    MessageBox.Show("No Flow meter is configured");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        #endregion [Events]

        #region [Timer Event]
        /// <summary>
        /// Timer event are used to refresh flow meter reading for every seconds.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (GlobalVariable.Meter_Type == Constants.LCMeterType)
                {
                    meterFunctions = new MeterFunctions();
                    txtQtyDispensed.Text = meterFunctions.QtyDispensedRefreshLC();
                }
                else if (GlobalVariable.Meter_Type == Constants.ISOILMeterType)
                {
                    getQtyMeter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion [Timer Event]

        #region [Private Methods]
        /// <summary>
        /// This method is used to calculate other series value in configuration table. 
        /// </summary>
        /// <returns></returns>
        private string GetOtherSeries()
        {
            string oth_series;
            oth_series = _ILogin.GetConfigurationInfo().oth_series;
            if (string.IsNullOrEmpty(oth_series) || oth_series == "0")
                oth_series = "10000";
            oth_series = (Convert.ToInt32(oth_series) + 1).ToString();
            return oth_series;
        }

        private void FrmStockTransferLCMeter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.ToString() == "UserClosing")
            {
                MessageBox.Show("Cannot close...Please click yes button");
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        /// <summary>
        /// This method is used to initialize and assign stock transfer object.
        /// </summary>
        /// <returns>Stock Transfer Object</returns>
        private StockTransfer GetStockTransferObject()
        {
            StockTransfer ObjStockTransfer = null;
            try
            {
                ObjStockTransfer = new StockTransfer();
                ObjStockTransfer.bill_no = InvoiceNo;
                ObjStockTransfer.trans_date = DateTime.Now.Date;
                ObjStockTransfer.trans_time = LCString.TimeFormatConversion(DateTime.Now.ToString("HH:mm:ss"));
                ObjStockTransfer.tran_type = "ST";
                ObjStockTransfer.source = GlobalVariable.Refuller;
                ObjStockTransfer.destination = destination;
                ObjStockTransfer.Qty = Convert.ToDecimal(txtQtyDispensed.Text);
                ObjStockTransfer.temperature = temp;
                ObjStockTransfer.density = density;
                ObjStockTransfer.fuel_batch_no = fuelbatchno;
                ObjStockTransfer.equipment_no = txtEquipementNo.Text;
                ObjStockTransfer.meter_start = Convert.ToDecimal(txtMeterStartReading.Text);
                ObjStockTransfer.meter_end = Convert.ToDecimal(txtMeterEndReading.Text);
                ObjStockTransfer.operators = GlobalVariable.LoginUser;
                ObjStockTransfer.shift = GlobalVariable.shiftno;
                ObjStockTransfer.business_day = Convert.ToDateTime(GlobalVariable.BusinessDay);
                ObjStockTransfer.tmStamp = DateTime.Now;
                ObjStockTransfer.MeterStartTime = txtFuellingStartTime.Text;
                ObjStockTransfer.MeterEndTime = txtFuellingEndTime.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return ObjStockTransfer;
        }
        /// <summary>
        /// This method is used to initialize Stock Transfer object properties.
        /// </summary>
        /// <param name="stockTransfer">Object of type Stock Transfer</param>
        public void AssignStockTransfer(StockTransfer stockTransfer)
        {
            try
            {
                destination = stockTransfer.destination;
                density = stockTransfer.density;
                temp = stockTransfer.temperature;
                fuelbatchno = stockTransfer.fuel_batch_no;
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        /// <summary>
        /// This function is to get LC Flow Meter quantity dispensed, start and end meter readings 
        /// </summary>
        private void GetData()
        {
            try
            {
                meterFunctions = new MeterFunctions();
                txtQtyDispensed.Text = meterFunctions.QtyDispensedRefreshLC();

                txtMeterEndReading.Text = meterFunctions.GetMeterEndReading();

                txtMeterStartReading.Text = (double.Parse(txtMeterEndReading.Text) - double.Parse(txtQtyDispensed.Text)).ToString();  //calculate start reading
                txtFuellingStartTime.Text = FuelStartTime;
                txtFuellingEndTime.Text = FuelEndTime;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// This function is to get ISOIL meter quantity and readings. 
        /// </summary>
        private void getQtyMeter()
        {
            long[] MyArr = new long[2];
            int ArrSize = 2;
            long lval = 0;
            try
            {
                lval = ISOILLibrary.FillArr(MyArr, ArrSize);
                if (lval == 0)
                {
                    this.Close();
                    ErrorMessage.DisplayMessage("ISOIL meter Error");
                    return;
                }
                txtQtyDispensed.Text = MyArr[0].ToString();
                txtMeterEndReading.Text = MyArr[1].ToString();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        /// <summary>
        /// This method is used to set control visibility.
        /// </summary>
        private void SetControlVisibility(bool Flag)
        {
            if (Flag == true)
            {
                lblPleaseWait.Visible = true;
                lblFinalClearance.Visible = false;
                btnYes.Visible = false;
            }
            else
            {
                lblPleaseWait.Visible = false;
                lblFinalClearance.Visible = true;
                btnYes.Visible = true;
            }
        }
        #endregion [Private Methods]
    }
}
