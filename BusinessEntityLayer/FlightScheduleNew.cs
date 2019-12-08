using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class FlightScheduleNew
    {
        public string loc_code { get; set; }
        public string supplier_code { get; set; }
        public string airline_code { get; set; }
        public string airline_name { get; set; }
        public string flight_id { get; set; }
        public string flight_type { get; set; }
        public string product_type { get; set; }
        public string turbo_flag { get; set; }
        public string bill_to { get; set; }
        public string ship_to { get; set; }
        public string aircraft_type { get; set; }
        public string flight_origin { get; set; }
        public string arriving_from { get; set; }
        public string proceed_to { get; set; }
        public string final_destination { get; set; }
        public string destination_country { get; set; }
        public string estimated_qty { get; set; }
        public string uom { get; set; }
        public string eta { get; set; }
        public string etd { get; set; }
        public string approach_time { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }
        public string frequency { get; set; }
        public string sch_type { get; set; }
        public DateTime? created_on { get; set; }
        public string AirlineFlag { get; set; }
        public string BillToName { get; set; }
        public string ShipToName { get; set; }
    }
}
