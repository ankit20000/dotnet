using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public static class FuelTransaction
    {
        public static string airline_name { get; set; }
        public static string BillToName { get; set; }
        public static string ShipToName { get; set; }
        public static string flight_id { get; set; }
        public static string flight_type { get; set; }
        public static string supplier_code { get; set; }
        public static string eta { get; set; }
        public static string etd { get; set; }
        public static string flight_origin { get; set; }
        public static string final_destination { get; set; }
        public static string aircraft_type { get; set; }
        public static string AirlineFlag { get; set; }
        public static string airline_code { get; set; }
        public static string bill_to { get; set; }
        public static string ship_to { get; set; }
        public static string product_type { get; set; }
        public static string TurboFlag { get; set; }
        // Registration Form Properties
        public static string RegistrationNo { get; set; }
        public static string TurboProp { get; set; }
        public static string offtakeweight { get; set; }
        public static string wide_body { get; set; }        
    }
}
