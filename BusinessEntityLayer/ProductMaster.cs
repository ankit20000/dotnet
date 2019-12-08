using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class ProductMaster
    {
        public string product_code { get; set; }
        public string product_desc { get; set; }
        public string product_remark { get; set; }
        public DateTime? tmstamp { get; set; }
    }
}
