using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class AirlineMaster
    {
        public string loc_code { get; set; }
        public string airline_code { get; set; }
        public string airline_name { get; set; }
        public string bill_to { get; set; }
        public string ship_to { get; set; }
        public string sold_to { get; set; }
        public string bill_to_name { get; set; }
        public string ship_to_name { get; set; }
        public string Country { get; set; }
        public DateTime? tmstamp { get; set; }
        public string airline_flag { get; set; }
    }
}
