using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class LocationMaster
    {
        public string loc_code { get; set; }
        public string loc_name { get; set; }
        public string sap_code { get; set; }
        public string iata_code { get; set; }
        public string loc_address1 { get; set; }
        public string loc_address2 { get; set; }
        public string city_code { get; set; }
        public string postal_code { get; set; }
        public int? turn_around_time { get; set; }
        public int? grace_time { get; set; }
        public DateTime? tmstamp { get; set; }
    }
}
