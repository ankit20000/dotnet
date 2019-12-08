using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class DensityVariance
    {
        public string storage_id { get; set; }
        public decimal? current_density { get; set; }
        public decimal? observed_density { get; set; }
        public decimal? temp { get; set; }
        public string fuel_batch_no { get; set; }
        public decimal? variance { get; set; }
        public string remarks { get; set; }
        public DateTime? trans_date { get; set; }
    }
}
