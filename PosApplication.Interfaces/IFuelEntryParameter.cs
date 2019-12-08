using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface IFuelEntryParameter
    {
        DensityReference GetDensityReference(string refullerid);
        DensityReference GetDensityReference();
        int UpdateDensityReference(decimal density, decimal temperature, string fuelbatchno, string refullerid);
    }
}
