using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface IStockTransfer
    {
        List<object> GetRefuellerMaster(string refuellerId);
        List<object> GetTankMaster();
        int SaveStockTransfer(StockTransfer stockTransfer);
    }
}
