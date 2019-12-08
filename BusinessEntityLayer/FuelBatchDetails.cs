using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class FuelBatchDetails
    {
        public decimal? density { get; set; }
        public decimal? temp { get; set; }
        public string fuel_batch_no { get; set; }
        public DateTime? timestamp { get; set; }
    }
}
