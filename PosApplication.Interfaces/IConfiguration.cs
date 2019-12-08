using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface IConfiguration
    {
        List<object> LoadRefuller();
        void SaveConfigInfo(ConfigurationInfo configurationInfo);
        void UpdateConfigInfo(ConfigurationInfo configurationInfo);
    }
}
