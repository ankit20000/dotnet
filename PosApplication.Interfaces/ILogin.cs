using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface ILogin
    {
        List<object> LoadShiftInfo();
        ConfigurationInfo GetConfigurationInfo();
        bool GetUserInfo(string username, string password);
        string CheckRefuller();
        string CheckLocation();          
    }
}
