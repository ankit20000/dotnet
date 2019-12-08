using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface ICirculationTest
    {
        int SaveStockTransfer(StockTransfer stockTransfer);
        void UpdateConfigurationDetails(string otherSeries, string endReading);
    }
}
