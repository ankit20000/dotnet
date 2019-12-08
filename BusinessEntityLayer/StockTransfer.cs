using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class StockTransfer
    {
        public string bill_no { get; set; }
        public DateTime? trans_date { get; set; }
        public string trans_time { get; set; }
        public string tran_type { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public decimal? Qty { get; set; }
        public decimal? temperature { get; set; }
        public decimal? density { get; set; }
        public string fuel_batch_no { get; set; }
        public string equipment_no { get; set; }
        public decimal? meter_start { get; set; }
        public decimal? meter_end { get; set; }
        public string operators{get;set;}
        public string shift { get; set; }
        public string shift_processed { get; set; }
        public string shift_processed_by { get; set; }
        public DateTime? business_day { get; set; }
        public string comments { get; set; }
        public string nozzle_calib { get; set; }
        public string circulation { get; set; }
        public DateTime? tmStamp { get; set; }
        public string rollover_shift { get; set; }
        public DateTime? rollover_day { get; set; }
        public string remark { get; set; }
        public string export_flag { get; set; }
        public string MeterStartTime { get; set; }
        public string MeterEndTime { get; set; }
    }
}
