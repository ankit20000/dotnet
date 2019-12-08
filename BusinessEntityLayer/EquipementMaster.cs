using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class EquipementMaster
    {
        public string equipment_id { get; set; }
        public string equipment_desc { get; set; }
        public string vehicle_no { get; set; }
        public string chasis_no { get; set; }
        public string engine_no { get; set; }
        public string fuel_capacity { get; set; }
        public string flowmtr_vendor { get; set; }
        public string flowmtr_id { get; set; }
        public DateTime? tmpstamp { get; set; }
    }
}
