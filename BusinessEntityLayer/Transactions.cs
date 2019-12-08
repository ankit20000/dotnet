using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class Transactions
    {
        public string invoice_no { get; set; }
        public string airline_name { get; set; }
        public string bill_to { get; set; }
        public string ship_to { get; set; }
        public string flight_id { get; set; }
        public string arriving_from { get; set; }
        public string proceeding_to { get; set; }
        public string aircraft_reg_no { get; set; }
        public string aircraft_type { get; set; }
        public string turbo_prop { get; set; }
        public string duty_paid { get; set; }
        public string bonded { get; set; }
        public string payment_type { get; set; }
        public string equipment_no { get; set; }
        public decimal? qty { get; set; }
        public decimal? meter_start { get; set; }
        public decimal? meter_end { get; set; }
        public string fuel_start { get; set; }
        public string fuel_end { get; set; }
        public decimal? density { get; set; }
        public decimal? temprature { get; set; }
        public string batch_no { get; set; }
        public string bay_no { get; set; }
        public string hydrant_pit_no { get; set; }
        public string Ready_to_fuel { get; set; }
        public string final_clearance { get; set; }
        public string carnetcard_no { get; set; }
        public string issuedby { get; set; }
        public string exp_date { get; set; }
        public string auth_no { get; set; }
        public string auth_date { get; set; }
        public string cash_memo_no { get; set; }
        public string cash_memo_dt { get; set; }
        public string refueller_id { get; set; }
        public string operators { get; set; }
        public string operation { get; set; }
        public string offloading_rcpt { get; set; }
        public string comments { get; set; }
        public string received_by { get; set; }
        public string shift { get; set; }
        public string shift_processed { get; set; }
        public string shift_processed_by { get; set; }
        public DateTime? business_day { get; set; }
        public DateTime? trans_date { get; set; }
        public string rollover_shift { get; set; }
        public string rollover_day { get; set; }
        public string customer_name { get; set; }
        public decimal? dip_start { get; set; }
        public decimal? dip_end { get; set; }
        public string above40T { get; set; }
        public string flight_type { get; set; }
        public string export_flag { get; set; }
        public string Bill_to_Code { get; set; }
        public string Ship_to_Code { get; set; }
    }
}
