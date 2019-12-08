using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class TankMaster
    {
        public string tank_no { get; set; }
        public string tank_desc { get; set; }
        public string product_code { get; set; }
        public string fuel_qty { get; set; }
        public string tank_density { get; set; }
        public string tank_temp { get; set; }
        public string tank_capacity { get; set; }
        public DateTime? tmstamp { get; set; }
    }
}
