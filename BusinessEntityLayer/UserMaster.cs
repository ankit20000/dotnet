using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class UserMaster
    {
        public string loginName { get; set; }
        public string fullName { get; set; }
        public string password { get; set; }
        public int user_level { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string address4 { get; set; }
        public string res_phone_no { get; set; }
        public string mob_phone_no { get; set; }
    }
}
