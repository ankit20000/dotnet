using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class FlightMaster
    {
        public string loc_code { get; set; }
        public string flight_id { get; set; }
        public string airline_code { get; set; }
        public DateTime? FrmDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string arriving_from { get; set; }
        public string proceeding_to { get; set; }
        public string bill_to { get; set; }
        public string aircraft_type { get; set; }
        public string tail_no { get; set; }
        public decimal? tank_capacity { get; set; }
        public decimal? estimated_qty { get; set; }
        public string estimated_time_arrival { get; set; }
        public string estimated_time_departure { get; set; }
        public string approach_time { get; set; }
        public decimal? estimated_time_fuel { get; set; }
        public string bonded { get; set; }
        public string duty_paid { get; set; }
        public string turbo_prop { get; set; }
        public string carnet_card_no { get; set; }
        public string carnet_exp_date { get; set; }
        public string carnet_issued_by { get; set; }
        public string carnet_ho_authno { get; set; }
        public string frequency { get; set; }
        public DateTime? tmstamp { get; set; }
        public string supplier_code { get; set; }
        public string type { get; set; }
        public string ship_to { get; set; }
    }
}
