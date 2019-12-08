using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class GlobalVariable
    {
        public static string LoginUser { get; set; }
        public static string Meter_Type { get; set; }
        public static string Location { get; set; }
        public static string shiftno { get; set; }
        public static bool fids_flag { get; set; } = false;
        public static string BusinessDay { get; set; }
        public static string BOServerIP { get; set; }
        public static string Refuller { get; set; }       
        public static long MeterStart { get; set; }
        public static int LCFInit { get; set; }
        public static bool Processed { get; set; }
        public static bool DFProcessed { get; set; }
        public static bool OProcessed { get; set; }
        public static string fuel_trans_type { get; set; }
        public static string invoice_no { get; set; }
        public static byte EXITSTAT { get; set; }
        public static string ReadyToFuel { get; set; }
        public static string CirculationType { get; set; }
        public static string Reason { get; set; }
        public static string StockTransferType { get; set; }       
    }
}
