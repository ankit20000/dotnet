using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class LCMeterLibrary
    {
        #region [Library Functions]
        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte LCP02Open(byte minDevice, byte maxDevice, ref byte Data,
              [MarshalAs(UnmanagedType.LPArray)]byte[] devices);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte LCP02IssueCommand(byte device, byte command, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte LCP02Close();

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte LCP02MustGetField(byte device, byte fieldNum, [MarshalAs(UnmanagedType.LPArray)] byte[] fieldData,
        ref byte devStatus, long EntryDelay, long ExitDelay);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02GetField(byte device, byte fieldNum, ref long fieldData, ref byte devStatus, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02MustGetStatus(byte device, ref LCRStatus status, ref byte devStatus, long EntryDelay, long ExitDelay);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02MustPrint(byte device, [MarshalAs(UnmanagedType.LPArray)] byte[] text, long textLen, long EntryDelay, long ExitDelay);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02AbortRequest(byte device);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02ActivatePumpAndPrint(byte device, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02AreYouThere(byte device);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02CheckRequest(byte device);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02DeleteTransaction(byte device, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02EStop(byte device, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern long LCP02FieldSize(byte fieldNum);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02GetDeliveryStatus(byte device, ref LCRStatus status, ref byte devStatus, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02GetFirstTicketLine(byte device, ref byte ticketLine, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02GetNextTicketLine(byte device, ref byte ticketLine, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02GetSecurityLevel(byte device, ref byte security, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02GetStatus(byte device, ref LCRStatus status, ref byte devStatus, byte mode);

        //[DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        //public static extern byte LCP02GetTransaction(byte device, ref LCRStatus trans, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02GetVersion(byte device, ref int version, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02MustGetDeliveryStatus(byte device, ref LCRStatus status, ref byte devStatus, long EntryDelay, long ExitDelay);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02MustGetSecurityLevel(byte device, ref byte security, long EntryDelay, long ExitDelay);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02MustSetField(byte device, byte fieldNum, [MarshalAs(UnmanagedType.LPArray)] byte[] fieldData, ref byte devStatus, long EntryDelay, long ExitDelay);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02Print(byte device, [MarshalAs(UnmanagedType.LPArray)] byte[] text, long textLen, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02SetDeviceAddr(byte device, byte newDevice, byte mode);

        [DllImport("LCLP02NT.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern byte LCP02SetField(byte device, byte fieldNum, [MarshalAs(UnmanagedType.LPArray)] byte[] fieldData, ref byte devStatus, byte mode);
        #endregion [Library Functions]

        #region [Miscellaneous LCR definitions]

        public const byte LCP02_PID_LCR = 2;                    //LCP product ID for LCR
        public const byte LCP02_NullDelayPtr = 0;               //null pointer to delay function
        public const byte LCR_MIN_SLAVE_ADDR = 1;               // minimum LCR node address
        public const byte LCR_MAX_SLAVE_ADDR = 250;             // maximum LCR node address
        public const byte byteLCR_NEW_DEVICE_ADDR = 250;        // new LCR device address

        #endregion [Miscellaneous LCR definitions]

        #region [LCR field types]

        public const byte LCRT_TEXT = 0;                        // ASCIIZ string
        public const byte LCRT_INTEGER = 1;                     //2 byte signed integer
        public const byte LCRT_DATE = 2;                        //9 byte ASCIIZ string
        public const byte LCRT_TIME = 3;                        //9 byte ASCIIZ string
        public const byte LCRT_LONG = 4;                        //4 byte signed long integer
        public const byte LCRT_VOLUME = 5;                      //4 byte signed long integer with implied decimal point
        public const byte LCRT_FFLOAT = 6;                      //free format 4 byte floating point
        public const byte LCRT_LIST = 50;                       //1 byte unsigned char
        public const byte LCRT_UFLOAT = 80;                     //4 byte unsigned floating point
        public const byte LCRT_SFLOAT = 90;                     //4 byte signed floating point

        #endregion [LCR field types]

        #region [LCR text field lengths]

        public const byte LCRTl_DeliveryFinish = 17;            //delivery finish date and time
        public const byte LCRTl_DeliveryStart = 17;             //delivery start date and time
        public const byte LCRTl_FactoryKey = 15;                //factory key
        public const byte LCRTl_Language = 10;                  //language revision
        public const byte LCRTl_LastCalibrated = 17;            //date and time of last calibration
        public const byte LCRTl_MeterID = 10;                   //meter identifier
        public const byte LCRTl_ProductCode = 5;                //product code
        public const byte LCRTl_ProductDescriptor = 18;         //product descriptor
        public const byte LCRTl_SerialID = 10;                  //serial identifier
        public const byte LCRTl_ShiftStart = 17;                //date and time of beginning of shift
        public const byte LCRTl_Software = 10;                  //software revision
        public const byte LCRTl_Ticket = 10;                    //ticket revision
        public const byte LCRTl_TicketHeaderLine = 35;          //ticket header line
        public const byte LCRTl_UnitID = 10;                    //unit identifier
        public const byte LCRTl_UserKey = 10;                   //user key
        public const byte LCRTl_UserSetKey = 10;                //key to set user key

        #endregion [LCR text field lengths]

        #region [LCR list type groups]

        public const byte LCRLg_PRODUCT_NUMBER = 0;             //product number list
        public const byte LCRLg_PRESETS_ALLOWED = 1;            //presets types allowed list
        public const byte LCRLg_PRODUCT_TYPE = 2;               //product type list
        public const byte LCRLg_DATE_FORMAT = 3;                //date format list
        public const byte LCRLg_UNIT_OF_MEASURE = 4;            //unit of measure list
        public const byte LCRLg_YES_NO = 5;                     //yes/no list
        public const byte LCRLg_AUX_UNIT_OF_MEASURE = 6;        //auxiliary unit of measure list
        public const byte LCRLg_PRESET_TYPE = 7;                //preset type list
        public const byte LCRLg_HEADER_LINE_INDEX = 8;          //header line index list
        public const byte LCRLg_PULSE_OUTPUT = 9;               //pulse output list
        public const byte LCRLg_TEMPERATURE_UNIT = 10;          //temperature unit list
        public const byte LCRLg_RATE_BASE = 11;                 //rate base list
        public const byte LCRLg_LINEARIZATION_POINT = 12;       //linearization point list
        public const byte LCRLg_SECURITY = 13;                  //security locked/unlocked list
        public const byte LCRLg_DECIMALS = 14;                  //number of decimals list
        public const byte LCRLg_COMP_TYPE = 15;                 //compensation type list
        public const byte LCRLg_DIAGNOSTIC_MESSAGE = 16;        //diagnostic messages list
        public const byte LCRLg_COMP_PARAMETER = 17;            //compensation parameter list
        public const byte LCRLg_COMP_TEMPERATURE = 18;          //compensation temperature list
        public const byte LCRLg_PRINTER = 19;                   //printer type list
        public const byte LCRLg_RESIDUAL = 20;                  //residual processing list
        public const byte LCRLg_FLOW_DIRECTION = 21;            //flow direction list
        public const byte LCRLg_AUXILIARY_PORT_1 = 22;          //auxiliary port 1 option list
        public const byte LCRLg_AUXILIARY_PORT_2 = 23;          //auxiliary port 2 option list
        public const byte LCRLg_LCR_RESET = 24;                 //LCR reset option list
        public const byte LCRLg_LINEARIZATION_STATE = 25;       //linearization state list

        #endregion [LCR list type groups]

        #region [Product numbers]              (LCRT_LIST+0)

        public const byte LCRL_PRODUCT1 = 0;
        public const byte LCRL_PRODUCT2 = 1;
        public const byte LCRL_PRODUCT3 = 2;
        public const byte LCRL_PRODUCT4 = 3;

        #endregion [Product numbers]

        #region [Preset types allowed]         (LCRT_LIST+1)

        public const byte LCRL_PRESETS_NONE = 0;
        public const byte LCRL_PRESETS_GROSS = 1;
        public const byte LCRL_PRESETS_NET = 2;
        public const byte LCRL_PRESETS_BOTH = 3;

        #endregion [Preset types allowed]

        #region [Product types]                (LCRT_LIST+2)

        public const byte LCRL_AMMONIA = 0;
        public const byte LCRL_AVIATION = 1;
        public const byte LCRL_DISTILLATE = 2;
        public const byte LCRL_GASOLINE = 3;
        public const byte LCRL_METHANOL = 4;
        public const byte LCRL_LPG = 5;
        public const byte LCRL_LUBE_OIL = 6;
        public const byte LCRL_NO_PRODUCT_TYPE = 7;

        #endregion [Product types]

        #region [Date format]                  (LCRT_LIST+3)

        public const byte LCRL_MMDDYY = 0;
        public const byte LCRL_DDMMYY = 1;

        #endregion [Date format]  

        #region [Units of measure]             (LCRT_LIST+4)

        public const byte LCRL_GALLONS = 0;
        public const byte LCRL_LITRES = 1;
        public const byte LCRL_CUBIC_M = 2;
        public const byte LCRL_LBS = 3;
        public const byte LCRL_KGS = 4;
        public const byte LCRL_BARRELS = 5;
        public const byte LCRL_OTHER = 6;

        #endregion [Units of measure] 

        #region [Yes/No fields]                (LCRT_LIST+5)

        public const byte LCRL_YES = 0;
        public const byte LCRL_NO = 1;

        #endregion [Yes/No fields]

        // Auxiliary units of measure.   (LCRT_LIST+6)  Same as LCRT_LIST+4.

        #region [Preset types]                 (LCRT_LIST+7)

        public const byte LCRL_CLEAR = 0;
        public const byte LCRL_MULTIPLE = 1;
        public const byte LCRL_RETAIN = 2;
        public const byte LCRL_INVENTORY = 3;

        #endregion [Preset types]

        #region [Header line indexes]          (LCRT_LIST+8)

        public const byte LCRL_HEADER1 = 0;
        public const byte LCRL_HEADER2 = 1;
        public const byte LCRL_HEADER3 = 2;
        public const byte LCRL_HEADER4 = 3;
        public const byte LCRL_HEADER5 = 4;
        public const byte LCRL_HEADER6 = 5;
        public const byte LCRL_HEADER7 = 6;
        public const byte LCRL_HEADER8 = 7;
        public const byte LCRL_HEADER9 = 8;
        public const byte LCRL_HEADER10 = 9;
        public const byte LCRL_HEADER11 = 10;
        public const byte LCRL_HEADER12 = 11;

        #endregion [Header line indexes]

        #region [Pulse outputs]                (LCRT_LIST+9)

        public const byte LCRL_RISING = 0;
        public const byte LCRL_FALLING = 1;

        #endregion [Pulse outputs] 

        #region [Temperature units]            (LCRT_LIST+10)

        public const byte LCRL_DEG_C = 0;
        public const byte LCRL_DEG_F = 1;

        #endregion [Temperature units]

        #region [Rate base]                    (LCRT_LIST+11)

        public const byte LCRL_SECONDS = 0;
        public const byte LCRL_MINUTES = 1;
        public const byte LCRL_HOURS = 2;

        #endregion [Rate base]

        #region [Linearization points]         (LCRT_LIST+12)

        public const byte LCRL_LINEAR_POINT1 = 0;
        public const byte LCRL_LINEAR_POINT2 = 1;
        public const byte LCRL_LINEAR_POINT3 = 2;
        public const byte LCRL_LINEAR_POINT4 = 3;
        public const byte LCRL_LINEAR_POINT5 = 4;
        public const byte LCRL_LINEAR_POINT6 = 5;
        public const byte LCRL_LINEAR_POINT7 = 6;
        public const byte LCRL_LINEAR_POINT8 = 7;
        public const byte LCRL_LINEAR_POINT9 = 8;
        public const byte LCRL_LINEAR_POINT10 = 9;

        #endregion [Linearization points]

        #region [Security]                     (LCRT_LIST+13)

        public const byte LCRL_LOCKED = 0;
        public const byte LCRL_UNLOCKED = 1;

        #endregion [Security] 

        #region [Number of decimal places]     (LCRT_LIST+14)

        public const byte LCRL_HUNDREDTHS = 0;
        public const byte LCRL_TENTHS = 1;
        public const byte LCRL_WHOLE = 2;

        #endregion [Number of decimal places]

        #region [Compensation types]           (LCRT_LIST+15)

        public const byte LCRL_COMP_TYPE_NONE = 0;
        public const byte LCRL_LINEAR_F = 1;
        public const byte LCRL_LINEAR_C = 2;
        public const byte LCRL_TABLE_24 = 3;
        public const byte LCRL_TABLE_54 = 4;
        public const byte LCRL_TABLE_6B = 5;
        public const byte LCRL_TABLE_54B = 6;
        public const byte LCRL_TABLE_54C = 7;
        public const byte LCRL_TABLE_54D = 8;
        public const byte LCRL_NH3 = 9;

        #endregion [Compensation types]

        #region [Diagnostic messages]          (LCRT_LIST+16)

        public const byte LCRL_ROM_CHECKSUM = 0;
        public const byte LCRL_TEMPERATURE = 1;
        public const byte LCRL_VCF_TYPE = 2;
        public const byte LCRL_VCF_PARAMETER = 3;
        public const byte LCRL_VCF_DOMAIN = 4;
        public const byte LCRL_METER_CALIBRATION = 5;
        public const byte LCRL_PULSER = 6;
        public const byte LCRL_PRESET_STOP = 7;
        public const byte LCRL_NO_FLOW_STOP = 8;
        public const byte LCRL_STOP_REQUESTED = 9;
        public const byte LCRL_DELIVERY_END_REQUEST = 10;
        public const byte LCRL_POWER_FAIL = 11;
        public const byte LCRL_PRESET = 12;
        public const byte LCRL_NO_TERMINAL = 13;
        public const byte LCRL_PRINTER_NOT_READY = 14;
        public const byte LCRL_DATA_ACCESS_ERROR = 15;
        public const byte LCRL_DELIVERY_TICKET_PENDING = 16;
        public const byte LCRL_SHIFT_TICKET_PENDING = 17;
        public const byte LCRL_FLOW_ACTIVE = 18;
        public const byte LCRL_DELIVERY_ACTIVE = 19;
        public const byte LCRL_GROSS_PRESET_ACTIVE = 20;
        public const byte LCRL_NET_PRESET_ACTIVE = 21;
        public const byte LCRL_GROSS_PRESET_STOP = 22;
        public const byte LCRL_NET_PRESET_STOP = 23;
        public const byte LCRL_TVC_ACTIVE = 24;
        public const byte LCRL_S1_CLOSE = 25;
        public const byte LCRL_INIT_WARNING = 28;
        public const byte LCRL_END_OF_LIST = 29;

        #endregion [Diagnostic messages]          (LCRT_LIST+16)

        #region [Compensation parameters]      (LCRT_LIST+17)

        public const byte LCRL_COMP_PARAM_NONE = 0;
        public const byte LCRL_COEFFICIENT1 = 1;
        public const byte LCRL_COEFFICIENT2 = 2;
        public const byte LCRL_SG_60 = 3;
        public const byte LCRL_DENSITY_KGPL = 4;
        public const byte LCRL_API_GRAVITY = 5;
        public const byte LCRL_DENSITY_KGPCUM1 = 6;
        public const byte LCRL_COEFFICIENT3 = 7;
        public const byte LCRL_DENSITY_KGPCUM2 = 8;
        public const byte LCRL_NO_COMP_PARAM = 9;

        #endregion [Compensation parameters]

        #region [Compensation temperatures]    (LCRT_LIST+18)

        public const byte LCRL_NO_COMP_TEMP = 0;
        public const byte LCRL_DEG_F1 = 1;
        public const byte LCRL_DEG_C1 = 2;
        public const byte LCRL_DEG_F2 = 3;
        public const byte LCRL_DEG_C2 = 4;
        public const byte LCRL_DEG_F3 = 5;
        public const byte LCRL_DEG_C3 = 6;
        public const byte LCRL_DEG_C4 = 7;
        public const byte LCRL_DEG_C5 = 8;
        public const byte LCRL_DEG_C6 = 9;

        #endregion [Compensation temperatures]

        #region [Printer]                      (LCRT_LIST+19)

        public const byte LCRL_EPSON200ROLL = 0;
        public const byte LCRL_EPSONNEWFONTB = 0;
        public const byte LCRL_EPSON290SLIP = 1;
        public const byte LCRL_EPSONNEWFONTA = 1;
        public const byte LCRL_EPSON295SLIP = 2;
        public const byte LCRL_EPSONOLDFONTA = 2;
        public const byte LCRL_EPSON300ROLL = 3;
        public const byte LCRL_EPSONOLDFONTB = 3;
        public const byte LCRL_OKIDATAML184T = 4;
        public const byte LCRL_AXIOHMBLASTER = 5;
        public const byte LCRL_BLASTER = 5;

        #endregion [Printer]

        #region [Residuals]                    (LCRT_LIST+20)

        public const byte LCRL_ROUND = 0;
        public const byte LCRL_TRUNCATE = 1;

        #endregion [Residuals]

        #region [Flow direction]               (LCRT_LIST+21)

        public const byte LCRL_RIGHT = 0;
        public const byte LCRL_LEFT = 1;

        #endregion [Flow direction]

        #region [Auxiliary 1 options]          (LCRT_LIST+22)

        public const byte LCRL_AUX1_ON_DURING_DELIVERY = 0;
        public const byte LCRL_AUX1_OFF = 1;
        public const byte LCRL_AUX1_ON = 2;
        public const byte LCRL_AUX1_MONITOR_FLOW_RATE = 3;

        #endregion [Auxiliary 1 options]

        #region [Auxiliary 2 options]          (LCRT_LIST+23)

        public const byte LCRL_AUX2_FLOW_DIRECTION = 0;
        public const byte LCRL_AUX2_ON_DURING_DELIVERY = 1;
        public const byte LCRL_AUX2_OFF = 2;
        public const byte LCRL_AUX2_ON = 3;

        #endregion [Auxiliary 2 options]

        #region [Reset options]                (LCRT_LIST+24)

        public const byte LCRL_CLEAR_ALL = 0;
        //      LCRL_NO defined above as = 1
        public const byte LCRL_REBUILD = 2;

        #endregion [Reset options]

        #region [Linearization state]          (LCRT_LIST+25)

        public const byte LCRL_APPLIED = 0;
        public const byte LCRL_SETUP = 1;

        #endregion [Linearization state]

        #region [LCR A to D code word definitions]

        public const byte LCRA_R100_0 = 0x1;
        public const byte LCRA_R128_6 = 0x2;
        public const byte LCRA_RTD_SLOPE = 0x4;
        public const byte LCRA_RTD_OFFSET = 0x8;
        public const byte LCRA_VOLT_12 = 0x10;
        public const byte LCRA_VOLT_16 = 0x20;
        public const byte LCRA_VOLT_SLOPE = 0x40;
        public const byte LCRA_VOLT_OFFSET = 0x80;

        #endregion [LCR A to D code word definitions]

        #region [LCR field number definitions]

        public const byte LCRF_ProductNumber_DL = 0;
        public const byte LCRF_ProductCode_DL = 1;
        public const byte LCRF_GrossQty_NE = 2;
        public const byte LCRF_NetQty_NE = 3;
        public const byte LCRF_FlowRate_NE = 4;
        public const byte LCRF_GrossPreset_PL = 5;
        public const byte LCRF_NetPreset_PL = 6;
        public const byte LCRF_Temp_NE = 7;
        public const byte LCRF_Residual_WM = 8;
        public const byte LCRF_PulsesPerDistance_UL = 9;
        public const byte LCRF_CalibDistance_UL = 10;
        public const byte LCRF_ProductDescriptor_DL = 11;
        public const byte LCRF_Odometer_UL = 12;
        public const byte LCRF_ShiftGross_NE = 13;
        public const byte LCRF_ShiftNet_NE = 14;
        public const byte LCRF_ShiftDeliveries_NE = 15;
        public const byte LCRF_ClearShift_DL = 16;
        public const byte LCRF_GrossTotal_WM = 17;
        public const byte LCRF_NetTotal_WM = 18;
        public const byte LCRF_DateFormat_UL = 19;
        public const byte LCRF_Date_UL = 20;
        public const byte LCRF_Time_UL = 21;
        public const byte LCRF_SaleNumber_WM = 22;
        public const byte LCRF_TicketNumber_WM = 23;
        public const byte LCRF_UnitID_UL = 24;
        public const byte LCRF_NoFlowTimer_DL = 25;
        public const byte LCRF_S1Close_WM = 26;
        public const byte LCRF_PresetType_DL = 27;
        public const byte LCRF_PulseOutputEdge_UL = 28;
        public const byte LCRF_Header_AE = 29;
        public const byte LCRF_TicketHeaderLine_UL = 30;
        public const byte LCRF_PrintGrossAndParam_WM = 31;
        public const byte LCRF_VolCorrectedMsg_WM = 32;
        public const byte LCRF_Temp_WM = 33;
        public const byte LCRF_TempOffset_WM = 34;
        public const byte LCRF_TempScale_WM = 35;
        public const byte LCRF_MeterID_WM = 36;
        public const byte LCRF_TicketRequired_WM = 37;
        public const byte LCRF_QtyUnits_WM = 38;
        public const byte LCRF_Decimals_WM = 39;
        public const byte LCRF_FlowDirection_WM = 40;
        public const byte LCRF_TimeUnit_WM = 41;
        public const byte LCRF_CalibrationEvent_NE = 42;
        public const byte LCRF_ConfigurationEvent_NE = 43;
        public const byte LCRF_GrossCount_NE = 44;
        public const byte LCRF_NetCount_NE = 45;
        public const byte LCRF_ProverQty_WM = 46;
        public const byte LCRF_PulsesPerUnit_WM = 47;
        public const byte LCRF_AuxMult_WM = 48;
        public const byte LCRF_AuxUnit_WM = 49;
        public const byte LCRF_CalibrationNumber_NE = 50;
        public const byte LCRF_LinearPoint_AE = 51;
        public const byte LCRF_LinearFlowRate_WM = 52;
        public const byte LCRF_LinearError_WM = 53;
        public const byte LCRF_LinearProverQty_WM = 54;
        public const byte LCRF_Linearize_WM = 55;
        public const byte LCRF_Printer_WM = 56;
        public const byte LCRF_CompensationType_WM = 57;
        public const byte LCRF_CompensationParam_WM = 58;
        public const byte LCRF_BaseTemp_WM = 59;
        public const byte LCRF_Software_NE = 60;
        public const byte LCRF_PricePerUnit_DL = 61;
        public const byte LCRF_TaxPerUnit_DL = 62;
        public const byte LCRF_PercentTax_DL = 63;
        public const byte LCRF_DiagnosticMessages_AE = 64;
        public const byte LCRF_TotalTaxPerUnit_NE = 65;
        public const byte LCRF_TotalPercentTax_NE = 66;
        public const byte LCRF_ADCCode_NE = 67;
        public const byte LCRF_SupplyVoltage_NE = 68;
        public const byte LCRF_PulserReversals_NE = 69;
        public const byte LCRF_ShiftStart_NE = 70;
        public const byte LCRF_AuxQty_NE = 71;
        public const byte LCRF_UserKey_DL = 72;
        public const byte LCRF_Security_UL = 73;
        public const byte LCRF_FactoryKey_AE = 74;
        public const byte LCRF_R100_0_FL = 75;
        public const byte LCRF_R128_6_FL = 76;
        public const byte LCRF_RawADC_NE = 77;
        public const byte LCRF_RTDSlope_FL = 78;
        public const byte LCRF_RTDOffset_FL = 79;
        public const byte LCRF_SerialID_FL = 80;
        public const byte LCRF_UserSetKey_FL = 81;
        public const byte LCRF_LCRReset_FL = 82;
        public const byte LCRF_CompParamType_NE = 83;
        public const byte LCRF_CompTempType_NE = 84;
        public const byte LCRF_PresetsAllowed_DL = 85;
        public const byte LCRF_Aux1_DL = 86;
        public const byte LCRF_Aux2_DL = 87;
        public const byte LCRF_DefaultProduct_NE = 88;
        public const byte LCRF_DeliveryStart_NE = 89;
        public const byte LCRF_DeliveryFinish_NE = 90;
        public const byte LCRF_LastCalibrated_NE = 91;
        public const byte LCRF_GrossRemaining_NE = 92;
        public const byte LCRF_NetRemaining_NE = 93;
        public const byte LCRF_ProductType_WM = 94;
        public const byte LCRF_SubTotalCost_NE = 95;
        public const byte LCRF_TotalTax_NE = 96;
        public const byte LCRF_TotalCost_NE = 97;
        public const byte LCRF_Ticket_NE = 98;
        public const byte LCRF_Language_NE = 99;
        public const byte LCRF_ShiftPassword = 105;
        public const byte LCRF_CustomerID = 106;
        public const byte LCR_NUM_FIELDS = 100;
        public const long LCR_MAX_FIELDS = 256;

        #endregion [LCR field number definitions]

        #region [LCR command code definitions]

        public const byte LCRC_RUN = 0;                   // run command
        public const byte LCRC_STOP = 1;                  // stop command
        public const byte LCRC_END_DELIVERY = 2;          // end delivery command
        public const byte LCRC_AUX = 3;                   // auxiliary command
        public const byte LCRC_SHIFT = 4;                 // shift command
        public const byte LCRC_CALIBRATE = 5;             // calibrate command
        public const byte LCRC_PRINT = 6;                 // print command
        public const byte LCR_NUM_COMMANDS = 7;           // number of LCR commands

        #endregion [LCR command code definitions]

        #region [LCR status masks]
        //      LCRSc_* = Delivery Code
        //      LCRSd_* = Delivery Status
        //      LCRSm_* = Machine Status
        //      LCRSp_* = Printer Status

        public const byte LCRSc_DEL_TICKET_PENDING = 0x1;
        public const byte LCRSc_SHIFT_TICKET_PENDING = 0x2;
        public const byte LCRSc_FLOW_ACTIVE = 0x4;
        public const byte LCRSc_DELIVERY_ACTIVE = 0x8;
        public const byte LCRSc_GROSS_PRESET_ACTIVE = 0x10;
        public const byte LCRSc_NET_PRESET_ACTIVE = 0x20;
        public const byte LCRSc_GROSS_PRESET_STOP = 0x40;
        public const byte LCRSc_NET_PRESET_STOP = 0x80;
        public const long LCRSc_TVC_ACTIVE = 0x100;
        public const long LCRSc_S1_CLOSE_REACHED = 0x200;
        public const long LCRSc_BEGIN_DELIVERY = 0x400;
        public const long LCRSc_NEW_DELIVERY_QUEUED = 0x800;
        public const long LCRSc_INIT_WARNING = 0x1000;
        public const long LCRSc_CONFIG_EVENT = 0x2000;
        public const long LCRSc_CALIB_EVENT = 0x4000;

        public const byte LCRSd_ROM_CHECKSUM = 0x1;
        public const byte LCRSd_TEMPERATURE = 0x2;
        public const byte LCRSd_VCF_TYPE = 0x4;
        public const byte LCRSd_WATCHDOG = 0x4;
        public const byte LCRSd_VCF_PARAMETER = 0x8;
        public const byte LCRSd_VCF_SETUP = 0x8;
        public const byte LCRSd_VCF_DOMAIN = 0x10;
        public const byte LCRSd_METER_CALIBRATION = 0x20;
        public const byte LCRSd_PULSER_FAILURE = 0x40;
        public const byte LCRSd_PRESET_STOP = 0x80;
        public const long LCRSd_NO_FLOW_STOP = 0x100;
        public const long LCRSd_STOP_REQUEST = 0x200;
        public const long LCRSd_DELIVERY_END_REQUEST = 0x400;
        public const long LCRSd_POWER_FAIL = 0x800;
        public const long LCRSd_PRESET_ERROR = 0x1000;
        public const long LCRSd_LAPPAD_ERROR = 0x2000;
        public const long LCRSd_PRINTER_ERROR = 0x4000;
        public const long LCRSd_DATA_ACCESS_ERROR = 0x8000;

        public const byte LCRSm_UNKNOWN = 0x7;

        public const byte LCRSm_SWITCH_BETWEEN = 0x0;
        public const byte LCRSm_SWITCH_RUN = 0x1;
        public const byte LCRSm_SWITCH_STOP = 0x2;
        public const byte LCRSm_SWITCH_PRINT = 0x3;
        public const byte LCRSm_SWITCH_SHIFT_PRINT = 0x4;
        public const byte LCRSm_SWITCH_CALIBRATE = 0x5;
        public const byte LCRSm_SWITCH = 0x7;
        public const byte LCRSm_PRINTING = 0x8;
        public const byte LCRSm_STATE_RUN = 0x0;
        public const byte LCRSm_STATE_STOP = 0x10;
        public const byte LCRSm_STATE_END_DELIVERY = 0x20;
        public const byte LCRSm_STATE_AUX = 0x30;
        public const byte LCRSm_STATE_SHIFT = 0x40;
        public const byte LCRSm_STATE_CALIBRATE = 0x50;
        public const byte LCRSm_STATE_WAIT_NOFLOW = 0x60;
        public const byte LCRSm_STATE = 0x70;
        public const byte LCRSm_ERROR = 0x80;

        public const byte LCRSp_DELIVERY_TICKET = 0x1;
        public const byte LCRSp_SHIFT_TICKET = 0x2;
        public const byte LCRSp_DIAGNOSTIC_TICKET = 0x4;
        public const byte LCRSp_USER_PRINT = 0x8;
        public const byte LCRSp_ERROR_WARNING = 0x40;
        public const byte LCRSp_BUSY = 0x80;

        #endregion [LCR status masks]

        #region [LCR return code definitions]
        //      LCP02Ra_* = Return codes from C-API.
        //      LCP02Rd_* = Return codes from LCR device.
        //      LCP02Rf_* = Return codes from flash memory access routines.
        //      LCP02Rg_* = General purpose return codes.
        //      LCP02Rp_* = Return codes from printer routines.
        //      LCP02Rt_* = Return codes from temperature sensing device.

        public const byte LCP02Rd_PARAMID = 0x20;         // bad parameter identifier return code
        public const byte LCP02Rd_FIELDNUM = 0x21;        // bad field number return code
        public const byte LCP02Rd_FIELDDATA = 0x22;       // bad field data
        public const byte LCP02Rd_NOTSET = 0x23;          // set not allowed due to mode vs status
        public const byte LCP02Rd_COMMANDNUM = 0x24;      // bad command number return code
        public const byte LCP02Rd_DEVICEADDR = 0x25;      // bad device address
        public const byte LCP02Rd_REQUESTQUEUED = 0x26;   // request is queued
        public const byte LCP02Rd_NOREQUESTQUEUED = 0x27; // no request is queued
        public const byte LCP02Rd_REQUESTABORTED = 0x28;  // request has been aborted
        public const byte LCP02Rd_PREVIOUSREQUEST = 0x29; // previous request being processed
        public const byte LCP02Rd_ABORTNOTALLOWED = 0x2A; // abort is not allowed
        public const byte LCP02Rd_PARAMBLOCK = 0x2B;      // bad parameter block number return code
        public const byte LCP02Rd_BAUDRATE = 0x2C;        // bad baud rate

        public const byte LCP02Rf_START = 0x30;           // start operation failed
        public const byte LCP02Rf_NOACK = 0x31;           // a shift out operation was not acknowledged
        public const byte LCP02Rf_CRC = 0x32;             // CRC error on read data
        public const byte LCP02Rf_PARAMETERS = 0x33;      // invalid input parameters
        public const byte LCP02Rf_PAGEBOUNDARY = 0x34;    // page boundary error
        public const byte LCP02Rf_WRITEFAILED = 0x35;     // write operation failed

        public const byte LCP02Rt_OVERRANGE = 0x40;       // temperature over range
        public const byte LCP02Rt_UNDERRANGE = 0x41;      // temperature under range
        public const byte LCP02Rt_VCFTYPE = 0x43;         // VCF type error
        public const byte LCP02Rt_PARAMLIMIT = 0x44;      // table parameter out of limits
        public const byte LCP02Rt_DOMAIN = 0x45;          // temperature domain error

        public const byte LCP02Ra_OPEN = 0x50;            // NBS card initialization error
        public const byte LCP02Ra_CLOSE = 0x51;           // NBS card termination error
        public const byte LCP02Ra_CONNECT = 0x52;         // connection failed error
        public const byte LCP02Ra_MSGSIZE = 0x53;         // message size error
        public const byte LCP02Ra_DEVICE = 0x54;          // invalid device number
        public const byte LCP02Ra_FIELDNUM = 0x55;        // invalid field number
        public const byte LCP02Ra_FIELDDATA = 0x56;       // bad field data
        public const byte LCP02Ra_COMMANDNUM = 0x57;      // invalid command number
        public const byte LCP02Ra_NODEVICES = 0x58;       // no devices present in network
        public const byte LCP02Ra_VERSION = 0x59;         // version mismatch
        public const byte LCP02Ra_PARAMSTRING = 0x5A;     // bad environment parameter string
        public const byte LCP02Ra_NOREQUESTQUEUED = 0x5B; // no request has been queued
        public const byte LCP02Ra_QUEUEDREQUEST = 0x5C;   // a request is already queued
        public const byte LCP02Ra_REQUESTCODE = 0x5D;     // invalid request code queued
        public const byte LCP02Ra_NOTOPENED = 0x5E;       // network communications is not opened
        public const byte LCP02Ra_ALREADYOPENED = 0x5F;   // network communications already opened

        public const byte LCP02Rp_PRINTERBUSY = 0x60;     // the printer is busy
        public const byte LCP02Rp_OVERFLOW = 0x61;        // printer buffer overflow
        public const byte LCP02Rp_TIMEOUT = 0x62;         // printer timeout

        public const byte LCP02Rg_FIELDINIT = 0x70;       // flash variable has not been initialized
        public const byte LCP02Rg_FIELDRANGE = 0x71;      // new field table data out of range
        public const byte LCP02Rg_NOTREAD = 0x72;         // flash structure not yet read
        public const byte LCP02Rg_GROSSNOTACTIVE = 0x73;  // gross preset is not active
        public const byte LCP02Rg_NETNOTACTIVE = 0x74;    // net preset is not active
        public const byte LCP02Rg_NEVERSETTABLE = 0x75;   // field is never settable
        public const byte LCP02Rg_FIELDNOTUSED = 0x76;    // field is not used
        public const byte LCP02Rg_BADSWITCH = 0x77;       // bad switch position for requested command
        public const byte LCP02Rg_BADSTATE = 0x78;        // bad machine state for requested command
        public const byte LCP02Rg_PENDINGTICKET = 0x79;   // command ignored due to pending ticket
        public const byte LCP02Rg_FLASHPROTECTED = 0x7A;  // flash is protected via the switch
        public const byte LCP02Rg_DUPLINEARPOINT = 0x7B;  // duplicate linearization points
        public const byte LCP02Rg_LINEARRANGE = 0x7C;     // adjacent linear points range error
        public const byte LCP02Rg_ENDOFLIST = 0x7D;       // end of transactions list
        public const byte LCP02Rg_LOSTRANSACTIONS = 0x7E; // transactions were lost in the LCR
        public const byte LCP02Rg_CUSTOMERNOTSET = 0x7F;  // customer number has not been set

        public const byte MAX_PRN_BUFFER = 100;
        #endregion [LCR return code definitions]

        #region [LCR Security Levels]

        public const byte LCRS_PAUSE_LEVEL = 0x0;           //delivery has been paused
        public const byte LCRS_DELIVERY_LEVEL = 0x1;        //Switch out of calibration, not unlocked
        public const byte LCRS_UNLOCKED_LEVEL = 0x2;        //Switch out of calibration, unlocked
        public const byte LCRS_WM_LEVEL = 0x3;              //Switch in calibration, no delivery active
        public const byte LCRS_FACTORY_LEVEL = 0x4;         //user can set factory parameters
        public const byte LCRS_ALWAYS_EDITABLE = 0x8;       //field is always editable
        public const byte LCRS_NEVER_EDITABLE = 0x9;        //field is never editable
        public const byte LCRS_DELIVERY_ACTIVE = 0x80;      //delivery active bit

        #endregion [LCR Security Levels]

        #region [Communication Mode Bytes]

        public const byte LCRM_NO_WAIT = 0x0;               //API will not wait for response
        public const byte LCRM_WAIT = 0x1;                  //API wait for response
        public const byte LCRM_ABORT = 0x2;                 //API will abort request if no response

        #endregion [Communication Mode Bytes]
    }

    #region [Structure definitions]

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LCRStatus
    {
        public int DeliveryCode;                            //Delivery Code Word
        public int DeliveryStatus;                          //Delevery Status Word
        public byte PrinterStatus;                          //Printer Status Byte
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LCRTransaction
    {
        Single temperature;                                 //temperature of product at the end of delivery
        long customer;                                      //Five digit customer number
        long saleNumber;                                    //Sale number
        long gross;                                         //Gross volume delivered
        long net;                                           //net volume delivered
        int status;                                         //delivery status at the end of delivery
        byte compType;                                      //Compensation type used during delivery
        byte dateFormat;                                    //format of the data in date/time field
        byte decimals;                                      //decimal settings for volume fields
        byte product;                                       //product number delivered
        byte qtyUnits;                                      //Unit of measure for volume fields
        byte tempScale;                                     //temperature scale used during delivery
        byte datetimes;                                     //date and time delivery ended
    }
    #endregion [Structure definitions]

}
