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
    public partial class FrmLCFlowMeter : MasterForm
    {
        public event EventHandler ClickEvent;

        #region [Object Declaration] 

        private IFlowMeterCommunication _IFlowMeterCommunication;
        private ILogin _ILogin;
        private IFuelTransaction _IFuelTransaction;
        private Transactions transactions = null;
        private MeterFunctions meterFunctions = null;
        private IPrintReceipt _IPrintReceipt;
        #endregion [Object Declaration]

        #region [Constructor]
        [InjectionConstructor]
        public FrmLCFlowMeter(IFlowMeterCommunication iFlowMeterCommunication, ILogin iLogin, IFuelTransaction iFuelTransaction, IPrintReceipt iPrintReceipt) :this()
        {
            _IFlowMeterCommunication = iFlowMeterCommunication;
            _ILogin = iLogin;
            _IFuelTransaction = iFuelTransaction;
            _IPrintReceipt = iPrintReceipt;
        }
        public FrmLCFlowMeter() : base("FrmLCFlowMeter")
        {
            InitializeComponent();
        }
        #endregion [Constructor]

        #region [Variable Declaration]

        bool flowstatus;
        string invseries, FuelStartTime, FuelEndTime,CurrentStartTime, CurrentEndTime,FinalClearanceTime, InvoiceNo;
        long lval;
        byte result;
        
        #endregion [Variable Declaration]

        #region [Properties]

        private string invoice_no { get; set; }
        private string airline_name { get; set; }
        private string bill_to { get; set; }
        private string ship_to { get; set; }
        private string flight_id { get; set; }
        private string arriving_from { get; set; }
        private string proceeding_to { get; set; }
        private string aircraft_reg_no { get; set; }
        private string aircraft_type { get; set; }
        private string turbo_prop { get; set; }
        private string flight_type { get; set; }
        private string duty_paid { get; set; }
        private string bonded { get; set; }
        private string bay_no { get; set; }
        private string hydrant_pit_no { get; set; }
        private string customer_name { get; set; }
        private string above40T { get; set; }
        private string Bill_to_Code { get; set; }
        private string Ship_to_Code { get; set; }
        private string Readytofuel { get; set; }
        private string RefullerId { get; set; }
        private string Operators { get; set; }
        private string ShiftNo { get; set; }
        private DateTime? BusinessDay { get; set; }
        private string FlightType { get; set; }
        #endregion [Properties]

        #region [Events]
        private void FrmLCFlowMeter_Load(object sender, EventArgs e)
        {
            SetControlVisibility(true);
            GlobalVariable.EXITSTAT = 0;
            lblCurrentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FuelStartTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");            
            CurrentStartTime = DateTime.Now.ToString("HH:mm:ss");            
            meterFunctions = new MeterFunctions();

            try
            {
                if (GlobalVariable.Meter_Type == Constants.LCMeterType)
                {
                    LoadFormData();

                    txtEquipementNo.Text = meterFunctions.GetEquipementNumber() ?? string.Empty;

                    txtMeterStartReading.Text = meterFunctions.GetMeterStartReading() ?? string.Empty;

                    result = LCMeterLibrary.LCP02IssueCommand(Constants.device, LCMeterLibrary.LCRC_RUN, LCMeterLibrary.LCRM_WAIT);
                    timer1.Interval = 1000;
                    return;
                }
                else if (GlobalVariable.Meter_Type == Constants.ISOILMeterType)
                {
                    LoadFormData();

                    if (GlobalVariable.LCFInit != 1)
                    {                        
                        meterFunctions.getMeterStart();
                        txtMeterStartReading.Text = GlobalVariable.MeterStart.ToString() ?? string.Empty; 
                        lval = ISOILLibrary.switching(1);
                        if (lval != 1)
                        {
                            this.Close();
                            ErrorMessage.DisplayMessage("ISOIL meter Error");
                            return;
                        }
                    }
                    else
                    {
                        txtMeterStartReading.Text = GlobalVariable.MeterStart.ToString() ?? string.Empty;
                        lval = ISOILLibrary.switching(3);
                        if (lval != 3)
                        {
                            this.Close();
                            ErrorMessage.DisplayMessage("ISOIL meter Error");
                            return;
                        }
                    }
                    timer1.Interval = 1000;
                    return;
                }
                else
                {
                    MessageBox.Show("Please configure meter type");                    
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            SetControlVisibility(false);
            try
            {
                if (GlobalVariable.Meter_Type == Constants.LCMeterType)
                {
                    if (!flowstatus)
                    {
                        result = LCMeterLibrary.LCP02IssueCommand(Constants.device, LCMeterLibrary.LCRC_STOP, LCMeterLibrary.LCRM_WAIT);
                        if (MessageBox.Show("Are You Sure for Final Clearance", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        {
                            SetControlVisibility(true);
                            result = LCMeterLibrary.LCP02IssueCommand(Constants.device, LCMeterLibrary.LCRC_RUN, LCMeterLibrary.LCRM_WAIT);
                            return;
                        }

                        if (GlobalVariable.EXITSTAT != 2)
                        {
                            string message = CheckFormValidations();
                            if (!string.IsNullOrEmpty(message))
                            {
                                SetControlVisibility(true);
                                ErrorMessage.DisplayMessage(message);
                                return;
                            }

                            if ((Convert.ToDecimal(txtDensity.Text) > 850) || (Convert.ToDecimal(txtDensity.Text) < 750))
                            {
                                SetControlVisibility(true);
                                ErrorMessage.DisplayMessage("Please enter density between 750 to 850");
                                txtDensity.Text = "";
                                txtDensity.Focus();
                                return;
                            }
                            if (Convert.ToDecimal(txtTemperature.Text) > 60)
                            {
                                SetControlVisibility(true);
                                ErrorMessage.DisplayMessage("Please enter Temperature less than 60 Degree");
                                txtTemperature.Text = "";
                                txtTemperature.Focus();
                                return;
                            }
                        }
                        result = LCMeterLibrary.LCP02IssueCommand(Constants.device, LCMeterLibrary.LCRC_END_DELIVERY, LCMeterLibrary.LCRM_WAIT);
                        GlobalVariable.LCFInit = 0;
                        FuelEndTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        CurrentEndTime = DateTime.Now.ToString("HH:mm:ss");
                        flowstatus = true;
                        timer1.Interval = 1;
                    }

                    GetData();
                    int res = _IFlowMeterCommunication.SaveTransaction(GetTransactionObject());
                    if (res > 0)
                    {
                        _IFlowMeterCommunication.updateFlightProcessedStatus(flight_id);
                        _IFlowMeterCommunication.UpdateConfigurationInfo(invseries, txtMeterEndReading.Text);
                    }
                    flowstatus = false;
                    MessageBox.Show("Invoice No: " + invoice_no + " Generated and  saved in database", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (MessageBox.Show("Do You want to take print?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _IPrintReceipt.PrintOutLC(GetTransactionObject());
                    }
                    result = LCMeterLibrary.LCP02Close();

                    GlobalVariable.OProcessed = false;
                    GlobalVariable.Processed = false;
                    this.Close();
                }
                else if (GlobalVariable.Meter_Type == Constants.ISOILMeterType)
                {
                    SetControlVisibility(false);
                    if (!flowstatus)
                    {
                        lval = ISOILLibrary.switching(2);
                        if (lval != 2)
                        {
                            this.Close();
                            ErrorMessage.DisplayMessage("ISOIL meter Error");
                            return;
                        }
                        getQtyMeter();

                        if (MessageBox.Show("Are You Sure for Final Clearance", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            SetControlVisibility(true);
                            lval = ISOILLibrary.switching(3);
                            if (lval != 3)
                            {
                                this.Close();
                                ErrorMessage.DisplayMessage("ISOIL meter Error");
                                return;
                            }
                            return;
                        }
                        if (GlobalVariable.EXITSTAT != 2)
                        {
                            string message = CheckFormValidations();
                            if (!string.IsNullOrEmpty(message))
                            {
                                SetControlVisibility(true);
                                ErrorMessage.DisplayMessage(message);
                                return;
                            }
                        }
                        lval = ISOILLibrary.switching(4);
                        if (lval != 4)
                        {
                            ErrorMessage.DisplayMessage("ISOIL meter Error");
                            this.Close();
                            return;
                        }
                        GlobalVariable.LCFInit = 0;
                        FuelEndTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        txtFuellingEndTime.Text = FuelEndTime;
                        flowstatus = true;
                        timer1.Interval = 0;
                    }

                    getQtyMeter();
                    GlobalVariable.LCFInit = 0;

                    int res = _IFlowMeterCommunication.SaveTransaction(GetTransactionObject());
                    if (res > 0)
                    {
                        _IFlowMeterCommunication.updateFlightProcessedStatus(flight_id);
                        _IFlowMeterCommunication.UpdateConfigurationInfo(invseries, txtMeterEndReading.Text);
                    }
                    flowstatus = false;
                    MessageBox.Show("Invoice No: " + invoice_no + " Generated and  saved in database", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (MessageBox.Show("Do You want to take print?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _IPrintReceipt.PrintOutISOIL(GetTransactionObject());
                    }                   

                    GlobalVariable.OProcessed = false;
                    GlobalVariable.Processed = false;
                    this.Close();
                }
                else
                {
                    SetControlVisibility(true);
                    ErrorMessage.DisplayMessage("No meter type is configured");
                    return;
                }
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }            
        }

        private void FrmLCFlowMeter_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (flowstatus == true)
            {
                GlobalVariable.EXITSTAT = 2;
                this.ClickEvent += new EventHandler(btnYes_Click);               
            }
            else            
                GlobalVariable.EXITSTAT = 1;            
        }

        private void FrmLCFlowMeter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.ToString() == "UserClosing")
            {
                MessageBox.Show("Cannot close...Please click yes button");
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        #endregion[Events]

        #region [Timer Event]
        /// <summary>
        /// This event is used to refresh LC flow meter reading for every second.
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
                Logging.ErrorLog(ex);
            }
        }
        #endregion [Timer Event]

        #region [Methods]
        /// <summary>
        /// This method is used to load initial form data.
        /// </summary>
        private void LoadFormData()
        {
            try
            {
                flowstatus = false;
                invseries = _ILogin.GetConfigurationInfo().inv_series;
                if (string.IsNullOrEmpty(invseries) || invseries == "0")
                    invseries = "10000";
                invseries = (Convert.ToInt32(invseries) + 1).ToString();

                if (GlobalVariable.fuel_trans_type == "FT")
                    invseries = GlobalVariable.Location + "FT" + GlobalVariable.Refuller + invseries;
                else if (GlobalVariable.fuel_trans_type == "DF")
                    invseries = GlobalVariable.Location + "DF" + GlobalVariable.Refuller + invseries;
                txtCurrentTranNo.Text = invseries;
                txtFuellingStartTime.Text = FuelStartTime;

                var ObjList = _IFlowMeterCommunication.GetInvoiceList();
                if (ObjList == null && ObjList.Count == 0)
                {
                    InvoiceNo = GlobalVariable.Refuller + "10001";
                }
                else
                {
                    InvoiceNo = ObjList.LastOrDefault();
                    int id = Convert.ToInt32(InvoiceNo.Substring(InvoiceNo.Length - 5)) + 1;
                    InvoiceNo = GlobalVariable.Refuller + id.ToString();
                }
                var ObjResult = _IFlowMeterCommunication.GetDensityReference(GlobalVariable.Refuller);
                if (ObjResult != null)
                {
                    txtDensity.Text = ObjResult.density > 0 ? ObjResult.density.ToString() : "";
                    txtTemperature.Text = ObjResult.temp > 0 ? ObjResult.temp.ToString() : "";
                    cmbFuelBatchNo.Text = !string.IsNullOrEmpty(ObjResult.fuel_batch_no) ? ObjResult.fuel_batch_no : "";
                }
                else
                {
                    txtDensity.Text = "";
                    txtTemperature.Text = "";
                    cmbFuelBatchNo.Text = "";
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        /// <summary>
        /// This method is used to initialize transaction object properties to save record using fuel transaction form.
        /// </summary>
        /// <returns>Object of type Transaction</returns>
        private Transactions GetTransactionObject()
        {
            try
            {
                transactions = new Transactions();
                transactions.invoice_no = invoice_no;
                transactions.airline_name = airline_name;
                transactions.bill_to = bill_to;
                transactions.ship_to = ship_to;
                transactions.flight_id = flight_id.ToUpper();
                transactions.arriving_from = arriving_from;
                transactions.proceeding_to = proceeding_to;
                transactions.aircraft_reg_no = aircraft_reg_no;
                transactions.aircraft_type = aircraft_type;
                transactions.turbo_prop = turbo_prop;
                transactions.duty_paid = duty_paid;
                transactions.bonded = bonded;
                transactions.flight_type = flight_type;
                transactions.equipment_no = txtEquipementNo.Text;
                transactions.qty = Convert.ToDecimal(txtQtyDispensed.Text);
                transactions.meter_start = Convert.ToDecimal(txtMeterStartReading.Text);
                transactions.meter_end = Convert.ToDecimal(txtMeterEndReading.Text);
                transactions.fuel_start =LCString.TimeFormatConversion(CurrentStartTime);               
                transactions.fuel_end = LCString.TimeFormatConversion(CurrentEndTime);
                transactions.density = Convert.ToDecimal(txtDensity.Text);
                transactions.temprature = Convert.ToDecimal(txtTemperature.Text);
                transactions.batch_no = cmbFuelBatchNo.Text.ToUpper();
                transactions.bay_no = bay_no;
                transactions.hydrant_pit_no = hydrant_pit_no;
                transactions.Ready_to_fuel = Readytofuel;                
                FinalClearanceTime= DateTime.Now.ToString("HH:mm:ss");
                transactions.final_clearance = LCString.TimeFormatConversion(FinalClearanceTime);
                transactions.refueller_id = RefullerId;
                transactions.operators = Operators;
                if (GlobalVariable.fuel_trans_type == "DF")
                {
                    transactions.operation = "De-Fuelling";
                    transactions.offloading_rcpt = "Y";
                }
                else
                {
                    transactions.operation = "Fuelling";
                    transactions.offloading_rcpt = "N";
                }
                transactions.shift = ShiftNo;
                transactions.business_day = BusinessDay;
                transactions.trans_date = DateTime.Now;
                transactions.customer_name = customer_name;
                transactions.above40T = above40T;
                transactions.flight_type = FlightType;
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return transactions;
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
                Logging.ErrorLog(ex);
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
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        
        /// <summary>
        /// This Method is used to assign transaction object properties.
        /// </summary>
        /// <param name="transactions">Object of class type </param>
        public void AssignTransactionInfo(Transactions transactions)
        {
            if (transactions != null)
            {
                invoice_no = transactions.invoice_no;
                airline_name = transactions.airline_name;
                bill_to = transactions.bill_to;
                ship_to = transactions.ship_to;
                flight_id = transactions.flight_id;
                arriving_from = transactions.arriving_from;
                proceeding_to = transactions.proceeding_to;
                aircraft_reg_no = transactions.aircraft_reg_no;
                aircraft_type = transactions.aircraft_type;
                turbo_prop = transactions.turbo_prop;
                flight_type = transactions.flight_type;
                duty_paid = transactions.duty_paid;
                bonded = transactions.bonded;
                bay_no = transactions.bay_no;
                hydrant_pit_no = transactions.hydrant_pit_no;
                customer_name = transactions.customer_name;
                above40T = transactions.above40T;
                Readytofuel = transactions.Ready_to_fuel;
                RefullerId = transactions.refueller_id;
                Operators = transactions.operators;
                ShiftNo = transactions.shift;
                BusinessDay = transactions.business_day;
                above40T = transactions.above40T;
                FlightType = transactions.flight_type;
            }
        }
        /// <summary>
        /// This method used to perform form field validations.
        /// </summary>
        /// <returns>string type message</returns>
        private string CheckFormValidations()
        {
            string Message = string.Empty;
            if (string.IsNullOrEmpty(txtDensity.Text))
            {
                txtDensity.Focus();
                Message = "Please Enter Density";                
                return Message;
            }
            if (string.IsNullOrEmpty(txtTemperature.Text))
            {
                txtTemperature.Focus();
                Message = "Please Enter Temperature";                
                return Message;
            }
            if (string.IsNullOrEmpty(cmbFuelBatchNo.Text))
            {
                cmbFuelBatchNo.Focus();
                Message = "Please Enter Fuel Batch No.";
                return Message;
            }
            return Message;
        }
        /// <summary>
        /// This method is used to set visibility of control.
        /// </summary>
        /// <param name="flag">boolean value for visibility</param>
        private void SetControlVisibility(bool flag)
        {
            if(flag==false)
            {
                lblFinalClearance.Visible = false;
                btnYes.Visible = false;
                lblPleaseWait.Visible = true;
            }
            else
            {
                lblFinalClearance.Visible = true;
                btnYes.Visible = true;
                lblPleaseWait.Visible = false;
            }
        }
        #endregion [Methods]
    }
}
