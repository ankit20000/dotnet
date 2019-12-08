using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntityLayer;
using Common;
using PosApplication.Interfaces;
using Unity;

namespace POSApplication.Forms
{
    public delegate void PassTransactionInfo(Transactions transactions);
    public partial class FrmFuelTransaction : MasterForm
    {
        #region [Object Declaration]

        private IFuelTransaction _IFuelTransaction = null;
        private IScheduledFlightsSelf _IScheduledFlightsSelf = null;
        private ILogin _ILogin = null;
        private Transactions transactions = null;
        private FrmStart frmStart = null;
        private FrmLCFlowMeter frmLCFlowMeter = null;
        private AirlineMaster airlineMaster = null;

        #endregion [Object Declaration]

        #region [Variable Declarations] 

        string Bill_to_Code, Ship_to_Code,invseries;
        int fuelType;

        #endregion [Variable Declarations] 

        #region [Constructor]

        [InjectionConstructor]
        public FrmFuelTransaction(IFuelTransaction iFuelTransaction, ILogin iLogin, IScheduledFlightsSelf iScheduledFlightsSelf) : this()
        {
            _IFuelTransaction = iFuelTransaction;
            _ILogin = iLogin;
            _IScheduledFlightsSelf = iScheduledFlightsSelf;
        }
        public FrmFuelTransaction() : base("FrmFuelTransaction")
        {
            InitializeComponent();
        }

        #endregion [Constructor]

        #region [Properties]

        public bool Flag { get; set; }

        #endregion [Properties]

        #region [Events]

        private void FrmFuelTransaction_Load(object sender, EventArgs e)
        {
            dynamic objresult;
            try
            {
                fuelType = 0;
                GlobalVariable.EXITSTAT = 0;
                cmbActivity.Items.Add("Fuelling");
                cmbActivity.Items.Add("Defuelling");
                cmbActivity.Items.Add("No Uplift");

                if (GlobalVariable.DFProcessed == true)
                {
                    cmbSupplierCode.Items.Clear();
                    cmbSupplierCode.Items.Add(FuelTransaction.supplier_code);
                    cmbSupplierCode.Text = FuelTransaction.supplier_code;
                    cmbSupplierCode.Enabled = false;

                    cmbAirlineCode.Text = FuelTransaction.airline_code;
                    cmbAirlineCode.Enabled = false;

                    cmbCustomerName.Text = FuelTransaction.airline_name;
                    cmbCustomerName.Enabled = false;

                    cmbFlightNo.Items.Add(FuelTransaction.flight_id);
                    cmbFlightNo.Text = FuelTransaction.flight_id;
                    cmbFlightNo.Enabled = false;

                    Bill_to_Code = FuelTransaction.bill_to;
                    Ship_to_Code = FuelTransaction.ship_to;

                    txtBillTo.Text = FuelTransaction.BillToName;
                    txtBillTo.Enabled = false;
                    txtShipTo.Text = FuelTransaction.ShipToName;
                    txtShipTo.Enabled = false;

                    txtArrivingFrom.Text = "";
                    txtProceedingTo.Text = "";
                    txtAircraftType.Text = FuelTransaction.aircraft_type;

                    if (FuelTransaction.flight_type.ToUpper() == "DOM")
                    {
                        rdoDomestic.Checked = true;
                        rdoDomestic.Enabled = false;
                        rdoInternational.Enabled = false;
                    }
                    else
                    {
                        rdoInternational.Checked = true;
                        rdoInternational.Enabled = false;
                        rdoDomestic.Enabled = false;
                    }
                    if (FuelTransaction.product_type.ToUpper() == "BONDED")
                    {
                        rdoBonded.Checked = true;
                        rdoBonded.Enabled = false;
                        rdoDutyPaid.Enabled = false;
                    }
                    else if (FuelTransaction.product_type.ToUpper() == "DUTYPAID")
                    {
                        rdoDutyPaid.Checked = true;
                        rdoBonded.Enabled = false;
                        rdoDutyPaid.Enabled = false;
                    }
                }
                if (GlobalVariable.OProcessed == true)
                {
                    cmbCustomerName.Items.Clear();
                    if (string.IsNullOrEmpty(FuelTransaction.airline_name))
                    {
                        cmbCustomerName.Enabled = true;
                        cmbAirlineCode.Enabled = true;
                        cmbFlightNo.Enabled = true;
                        txtArrivingFrom.Enabled = true;
                        txtProceedingTo.Enabled = true;
                        ErrorMessage.DisplayMessage("No airline code exists for this airline");
                        return;
                    }
                    else
                    {
                        cmbCustomerName.Text = FuelTransaction.airline_name;
                        cmbCustomerName.Items.Add(FuelTransaction.airline_name);
                        cmbCustomerName.Enabled = false;
                        cmbAirlineCode.Text = FuelTransaction.airline_code;
                        cmbAirlineCode.Items.Add(FuelTransaction.airline_code);
                        cmbAirlineCode.Enabled = false;
                    }

                    cmbFlightNo.Items.Add(FuelTransaction.flight_id);
                    cmbFlightNo.Text = FuelTransaction.flight_id;
                    txtArrivingFrom.Text = "";
                    txtProceedingTo.Text = "";
                    cmbFlightNo.Enabled = false;

                    Bill_to_Code = FuelTransaction.bill_to;
                    Ship_to_Code = FuelTransaction.ship_to;

                    txtBillTo.Text = FuelTransaction.BillToName;
                    txtShipTo.Text = FuelTransaction.ShipToName;

                    if (GlobalVariable.fids_flag == false)
                        objresult = _IFuelTransaction.GetFlightMasterInfo(FuelTransaction.flight_id);
                    else
                        objresult = _IFuelTransaction.GetFlightScheduleInfo(FuelTransaction.flight_id);

                    if (objresult == null)
                    {
                        txtAircraftType.Text = "";
                        rdoBonded.Checked = false;
                        rdoDutyPaid.Checked = false;
                        rdoInternational.Checked = false;
                        rdoDomestic.Checked = false;
                        chkTurboProp.Checked = false;
                        cmbSupplierCode.Text = "";
                    }
                    else
                    {
                        txtAircraftType.Text = (!string.IsNullOrEmpty(objresult.aircraft_type)) ? objresult.aircraft_type : string.Empty;
                        if (objresult.bonded.ToUpper() == "Y")
                        {
                            rdoBonded.Checked = true;
                            rdoInternational.Checked = true;
                        }
                        else
                        {
                            rdoBonded.Checked = false;
                            rdoInternational.Checked = false;
                        }
                        if (objresult.duty_paid.ToUpper() == "Y")
                        {
                            rdoDutyPaid.Checked = true;
                            rdoDomestic.Checked = true;
                        }
                        else
                        {
                            rdoDutyPaid.Checked = false;
                            rdoDomestic.Checked = false;
                        }
                        if (objresult.turbo_prop.ToUpper() == "Y")
                            chkTurboProp.Checked = true;
                        else
                            chkTurboProp.Checked = false;
                        if (!string.IsNullOrEmpty(objresult.supplier_code))
                        {
                            cmbSupplierCode.Items.Add(objresult.supplier_code);
                            cmbSupplierCode.Text = objresult.supplier_code;
                        }
                    }
                }
                if (GlobalVariable.Processed == true)
                {
                    cmbSupplierCode.Items.Clear();
                    cmbSupplierCode.Items.Add(FuelTransaction.supplier_code);
                    cmbSupplierCode.Text = FuelTransaction.supplier_code;
                    cmbSupplierCode.Enabled = false;

                    cmbCustomerName.Text = FuelTransaction.airline_name;
                    cmbCustomerName.Enabled = true;

                    cmbAirlineCode.Items.Add(FuelTransaction.airline_code);
                    cmbAirlineCode.Text = FuelTransaction.airline_code;
                    cmbAirlineCode.Enabled = false;

                    cmbFlightNo.Items.Add(FuelTransaction.flight_id);
                    cmbFlightNo.Text = FuelTransaction.flight_id;
                    cmbFlightNo.Enabled = false;

                    Bill_to_Code = FuelTransaction.bill_to;
                    Ship_to_Code = FuelTransaction.ship_to;

                    txtArrivingFrom.Text = "";
                    txtProceedingTo.Text = "";

                    txtBillTo.Text = FuelTransaction.BillToName;
                    txtBillTo.Enabled = false;
                    txtShipTo.Text = FuelTransaction.ShipToName;
                    txtShipTo.Enabled = false;

                    txtAircraftType.Text = FuelTransaction.aircraft_type;

                    if (FuelTransaction.TurboFlag == "Y")
                        chkTurboProp.Checked = true;
                    else
                        chkTurboProp.Checked = false;

                    if (FuelTransaction.flight_type == "DOMESTIC")
                    {
                        rdoDomestic.Checked = true;
                        rdoDutyPaid.Checked = true;
                        rdoDomestic.Enabled = false;
                        rdoDutyPaid.Enabled = false;
                        rdoInternational.Enabled = false;
                        rdoBonded.Checked = false;
                    }
                    else
                    {
                        rdoInternational.Checked = true;
                        rdoBonded.Checked = true;
                        rdoInternational.Enabled = false;
                        rdoBonded.Enabled = false;
                        rdoDomestic.Enabled = false;
                        rdoDutyPaid.Checked = false;
                    }
                }
                if (Flag == true)
                {
                    txtRegistrationNo.Text = FuelTransaction.RegistrationNo;
                    if (FuelTransaction.TurboProp == "Y")
                        chkTurboProp.Checked = true;
                    else
                        chkTurboProp.Checked = false;
                    chkTurboProp.Enabled = false;

                    if (FuelTransaction.offtakeweight == "Y")
                    {
                        rdoAbove40T.Checked = true;
                        rdoBelow40T.Checked = false;
                    }
                    else
                    {
                        rdoAbove40T.Checked = false;
                        rdoBelow40T.Checked = true;
                    }
                    rdoAbove40T.Enabled = false;
                    rdoBelow40T.Enabled = false;
                    txtAircraftType.Text = FuelTransaction.aircraft_type;
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        private void btnStartFuelling_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (btnStartFuelling.Text == "Save")
                {
                    string message = CheckFormValidations();
                    if (!string.IsNullOrEmpty(message))
                    {
                        ErrorMessage.DisplayMessage(message);
                        return;
                    }

                    int res = _IFuelTransaction.SaveTransaction(GetTransactionsObject(Constants.LCMeterType));

                    if (GlobalVariable.OProcessed == true || GlobalVariable.Processed == true)
                    {
                        _IFuelTransaction.updateFlightProcessedStatus(cmbFlightNo.Text);
                    }
                    _IFuelTransaction.UpdateConfigurationInfo(invseries);

                    MessageBox.Show("No - Uplift Invoice No: " + GlobalVariable.invoice_no + " Generated and  saved in database", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    string message = string.Empty;
                    if (GlobalVariable.EXITSTAT != 1)
                    {                        
                        byte result = 0;
                        byte devStatus = 0;
                        byte[] Data = new byte[1];
                        message = CheckFormValidations();
                        if (!string.IsNullOrEmpty(message))
                        {
                            ErrorMessage.DisplayMessage(message);
                            return;
                        }
                        message = CheckValidations();
                        if (!string.IsNullOrEmpty(message))
                        {
                            ErrorMessage.DisplayMessage(message);
                            return;
                        }
                        bool checkTurboProp = _IFuelTransaction.CheckTurboOptions(txtRegistrationNo.Text, cmbAirlineCode.Text, chkTurboProp.Checked);
                        if (checkTurboProp == false)
                        {
                            ErrorMessage.DisplayMessage("PLEASE CORRECT THE TURBO-PROP OPTION");
                            return;
                        }
                        if (GlobalVariable.LCFInit != 1)
                        {
                            if (GlobalVariable.Meter_Type == Constants.LCMeterType)
                            {
                                result = LCMeterLibrary.LCP02Open(Constants.minDevice, Constants.maxDevice, ref devStatus, Data);
                                if (result != 0 && result != LCMeterLibrary.LCP02Ra_ALREADYOPENED)
                                {
                                    result = LCMeterLibrary.LCP02Close();
                                    MessageBox.Show("LCR open error");
                                    return;
                                }
                            }
                        }                        
                        GlobalVariable.ReadyToFuel = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");                       
                        Transactions objTRansactions= GetTransactionsObject(GlobalVariable.Meter_Type);
                        frmStart = new FrmStart();
                        frmStart.transactions = objTRansactions;
                        frmStart.Show();
                        this.Close();
                    }
                    else
                    {                        
                        var container = DependencyInjector.Register();
                        frmLCFlowMeter = container.Resolve<FrmLCFlowMeter>();
                        PassTransactionInfo del = new PassTransactionInfo(frmLCFlowMeter.AssignTransactionInfo);
                        del(GetTransactionsObject(GlobalVariable.Meter_Type));
                        frmLCFlowMeter.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {            
            this.Close();
            FrmAircraftRegNo frmAircraftRegNo = new FrmAircraftRegNo();
            frmAircraftRegNo.AirlineCode = FuelTransaction.airline_code;
            frmAircraftRegNo.Show();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.EXITSTAT == 1)
            {
                ErrorMessage.DisplayMessage("Flow Operation is Running; Please select Start Fuelling");
                return;
            }
        }

        private void rdoBonded_CheckedChanged(object sender, EventArgs e)
        {
            fuelType = 1;
        }

        private void rdoDutyPaid_CheckedChanged(object sender, EventArgs e)
        {
            fuelType = 1;
        }

        private void cmbActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActivity.Text == "No Uplift")
            {
                btnStartFuelling.Text = "Save";
                GlobalVariable.fuel_trans_type = "No Uplift";
            }                
            else if (cmbActivity.Text == "DEFUELLING")
            {
                btnStartFuelling.Text = "Start Defuelling";
                GlobalVariable.fuel_trans_type = "DF";
            }
            else
            {
                btnStartFuelling.Text = "Start Defuelling";
                GlobalVariable.fuel_trans_type = "FT";
            }
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbCustomerName.Text))
            {
                cmbAirlineCode.Items.Clear();
                var lstResult = _IScheduledFlightsSelf.GetAirlineMasterData(cmbCustomerName.Text).Select(c => c.airline_code).ToArray();
                if (lstResult != null)
                {
                    cmbAirlineCode.Items.AddRange(lstResult);
                    cmbAirlineCode.Text = cmbAirlineCode.Items[0].ToString();
                }
                else
                {
                    cmbAirlineCode.Items.Clear();
                    cmbAirlineCode.Focus();
                }

                var dictResult = _IFuelTransaction.GetAirlineCodeList(cmbAirlineCode.Text).Select(x => x.Value).ToArray();
                if (dictResult != null)
                {
                    cmbFlightNo.Items.Clear();
                    cmbFlightNo.Items.AddRange(dictResult);
                }
                else
                    cmbFlightNo.Items.Clear();
                txtArrivingFrom.Text = "";
                txtProceedingTo.Text = "";
                txtAircraftType.Text = "";
                txtBillTo.Text = "";
                txtShipTo.Text = "";
                rdoDomestic.Checked = false;
                rdoInternational.Checked = false;
            }
            else
            {
                txtBillTo.Text = "";
                txtShipTo.Text = "";
                rdoDomestic.Checked = false;
                rdoInternational.Checked = false;
            }
        }
        private void cmbFlightNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbFlightNo.Text))
            {
                var ObjResult = _IFuelTransaction.GetFlightMasterInfo(cmbFlightNo.Text);
                if (ObjResult != null)
                {
                    txtArrivingFrom.Text = "";
                    txtProceedingTo.Text = "";
                    txtAircraftType.Text = !string.IsNullOrEmpty(ObjResult.aircraft_type) ? ObjResult.aircraft_type : "";
                    if (ObjResult.bonded.ToUpper() == "Y")
                    {
                        rdoBonded.Checked = true;
                        rdoInternational.Checked = true;
                    }
                    else
                    {
                        rdoBonded.Checked = false;
                        rdoInternational.Checked = false;
                    }
                    if (ObjResult.duty_paid.ToUpper() == "Y")
                    {
                        rdoDutyPaid.Checked = true;
                        rdoDomestic.Checked = true;
                    }
                    else
                    {
                        rdoDutyPaid.Checked = false;
                        rdoDomestic.Checked = false;
                    }
                    if (ObjResult.turbo_prop.ToUpper() == "Y")
                        chkTurboProp.Checked = true;
                    else
                        chkTurboProp.Checked = false;
                }
                else
                {
                    txtAircraftType.Text = "";
                    rdoBonded.Checked = false;
                    rdoDutyPaid.Checked = false;
                    rdoDomestic.Checked = false;
                    rdoInternational.Checked = false;
                    chkTurboProp.Checked = false;
                }
            }
        }
        #endregion [Events]

        #region [Methods]
        /// <summary>
        /// This method is used to initalize and set form values to transaction object
        /// </summary>
        /// <returns>Transaction Object</returns>

        public Transactions GetTransactionsObject(string meterType)
        {
            transactions = new Transactions();
            try
            {                
                invseries = _ILogin.GetConfigurationInfo().inv_series;
                if (string.IsNullOrEmpty(invseries) || invseries == "0")
                    invseries = "10000";
                invseries = (Convert.ToInt32(invseries) + 1).ToString();
                GlobalVariable.invoice_no = GlobalVariable.Location + "FT" + GlobalVariable.Refuller + invseries;
                
                if (!string.IsNullOrEmpty(meterType) && meterType == Constants.LCMeterType)
                {
                    var ObjResult = _IFuelTransaction.GetFlightScheduleNewInfo(cmbFlightNo.Text);
                    if (ObjResult != null)
                    {
                        transactions.Bill_to_Code = ObjResult.bill_to;
                        transactions.Ship_to_Code = ObjResult.ship_to;
                    }
                    else
                    {
                        transactions.Bill_to_Code = txtBillTo.Text;
                        transactions.Ship_to_Code = txtShipTo.Text;
                    }
                }
                else if(!string.IsNullOrEmpty(meterType) && meterType == Constants.ISOILMeterType)
                {
                    airlineMaster = new AirlineMaster();
                    if (rdoDomestic.Checked == true)
                    {
                        airlineMaster = _IFuelTransaction.GetAirlineMasterInfo(cmbAirlineCode.Text, cmbCustomerName.Text, "D");
                    }
                    else if (rdoInternational.Checked == true)
                    {
                        airlineMaster = _IFuelTransaction.GetAirlineMasterInfo(cmbAirlineCode.Text, cmbCustomerName.Text, "I");
                    }
                    if (airlineMaster == null)
                    {
                        transactions.Bill_to_Code = txtBillTo.Text;
                        transactions.Ship_to_Code = txtShipTo.Text;
                    }
                    else
                    {
                        transactions.Bill_to_Code = airlineMaster.bill_to;
                        transactions.Ship_to_Code = airlineMaster.ship_to;
                    }
                }

                transactions.invoice_no = GlobalVariable.invoice_no;
                transactions.airline_name = cmbCustomerName.Text;
                transactions.bill_to = Bill_to_Code;
                transactions.ship_to = Ship_to_Code;
                transactions.flight_id = cmbFlightNo.Text;
                transactions.arriving_from = txtArrivingFrom.Text.ToUpper();
                transactions.proceeding_to = txtProceedingTo.Text.ToUpper();
                transactions.aircraft_reg_no = txtRegistrationNo.Text.ToUpper();
                transactions.aircraft_type = txtAircraftType.Text;
                if (chkTurboProp.Checked == true)
                    transactions.turbo_prop = "Y";
                else
                    transactions.turbo_prop = "N";
                if (rdoDomestic.Checked == true)
                    transactions.flight_type = "DOM";
                else
                    transactions.flight_type = "INT";
                if (rdoDutyPaid.Checked == true)
                {
                    transactions.duty_paid = "Y";
                    transactions.bonded = "N";
                }
                else
                {
                    transactions.duty_paid = "N";
                    transactions.bonded = "Y";
                }
                string currenttime = DateTime.Now.ToString("HH:mm:ss");
                transactions.fuel_start = LCString.TimeFormatConversion(currenttime);
                transactions.fuel_end = transactions.fuel_start;
                transactions.Ready_to_fuel = transactions.fuel_start;
                transactions.final_clearance = transactions.fuel_start;
                transactions.bay_no = txtBayNo.Text;
                transactions.hydrant_pit_no = txtHydrantPitNo.Text;
                transactions.refueller_id = GlobalVariable.Refuller ?? string.Empty;
                transactions.operators = GlobalVariable.LoginUser ?? string.Empty;
                transactions.operation = "NoUplift";
                transactions.shift = GlobalVariable.shiftno ?? string.Empty;                
                transactions.business_day = Convert.ToDateTime(GlobalVariable.BusinessDay);
                transactions.trans_date = DateTime.Now.Date;
                transactions.customer_name = cmbSupplierCode.Text;
                if (rdoAbove40T.Checked == true)
                    transactions.above40T = "Y";
                else
                    transactions.above40T = "N";
            }     
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return transactions;
        }
        
        /// <summary>
        /// This method used to perform form validations.
        /// </summary>
        /// <returns>string type message</returns>
        private string CheckFormValidations()
        {
            string Message = string.Empty;
            if (string.IsNullOrEmpty(cmbCustomerName.Text))
            {
                Message = "Customer name can't blank";
                return Message;
            }
            if (cmbCustomerName.Text.Length > 50)
            {
                Message = "Customer name is too Long";
                return Message;
            }
            if (string.IsNullOrEmpty(cmbAirlineCode.Text))
            {
                Message = "Please Enter Airline Code";
                return Message;
            }
            if (rdoDomestic.Checked == false && rdoInternational.Checked == false)
            {
                Message = "Please select whether the flight is DOMESTIC or INTERNATIONAL";
                return Message;
            }
            if (string.IsNullOrEmpty(cmbFlightNo.Text))
            {
                Message = "Flight No can't be blank";
                return Message;
            }
            if (cmbFlightNo.Text.Length > 10)
            {
                Message = "Flight No is too Long";
                return Message;
            }
            if (string.IsNullOrEmpty(cmbSupplierCode.Text))
            {
                Message = "Supplier can't be blank....Please select";
                return Message;
            }
            if (GlobalVariable.fids_flag == false)
            {
                if (string.IsNullOrEmpty(txtBillTo.Text))
                {
                    Message = "Please select DOMESTIC/INTERNATIONAL flight type properly";
                    return Message;
                }
                if (string.IsNullOrEmpty(txtShipTo.Text))
                {
                    Message = "Please select DOMESTIC/INTERNATIONAL flight type properly";
                    return Message;
                }
            }
            if (string.IsNullOrEmpty(txtArrivingFrom.Text) || string.IsNullOrEmpty(txtProceedingTo.Text))
            {
                Message = "ArrvingFrom/ProceedingTo can't be blank";
                return Message;
            }
            if(string.IsNullOrEmpty(cmbActivity.Text))
            {
                Message = "Please select Fuelling Activity";
                return Message;
            }
            return Message;
        }

        /// <summary>
        /// This method used to perform Additional form validations.
        /// </summary>
        /// <returns>string type message</returns>
        private string CheckValidations()
        {
            string Message = string.Empty;
            if (fuelType == 0)
            {
                Message = "Please select any one of fuelType (i.e Bonded/DutyPaid)";
                return Message;
            }
            if (string.IsNullOrEmpty(txtRegistrationNo.Text.Trim()))
            {
                Message = "Flight RegNo can't be blank";
                return Message;
            }
            if (string.IsNullOrEmpty(txtAircraftType.Text))
            {
                Message = "Aircraft type can't be blank";
                return Message;
            }
            return Message;
        }
        #endregion [Methods]
    }
}
