using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class AirlineRegistrationMaster
    {
        public string airline_code { get; set; }
        public string aircraft_reg_no { get; set; }
        public string turbo_prop { get; set; }
        public string aircraft_type { get; set; }
        public string registration_country { get; set; }
        public string registration_date { get; set; }
        public string wide_body { get; set; }
        public string off_take_weight { get; set; }
        public string airline_name { get; set; }
        public DateTime? tmstamp { get; set; }
    }
}
