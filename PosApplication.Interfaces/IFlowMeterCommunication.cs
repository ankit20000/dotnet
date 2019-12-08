using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface IFlowMeterCommunication
    {
        List<string> GetInvoiceList();
        DensityReference GetDensityReference(string refullerId);
        int SaveTransaction(Transactions transactions);
        void updateFlightProcessedStatus(string FlightNo);
        void UpdateConfigurationInfo(string invseries,string meterend);
    }
}
