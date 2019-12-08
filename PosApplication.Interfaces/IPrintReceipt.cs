using BusinessEntityLayer;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface IPrintReceipt
    {
        void PrintCirculationLC(StockTransfer stockTransfer);
        void PrintCirculationISOIL(StockTransfer stockTransfer);
        void PrintStockTransferLC(StockTransfer stockTransfer);
        void PrintStockTransferISOIL(StockTransfer stockTransfer);
        void PrintOutLC(Transactions transactions);
        void PrintOutISOIL(Transactions transactions);
        DataSet GetTransactionsInfo();
        void PrintReportLC(string invoiceno);
    }
}
