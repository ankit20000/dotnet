using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface IFuelTransaction
    {
        FlightScheduleNew GetFlightScheduleNewInfo(string FlightNo);
        void updateFlightProcessedStatus(string FlightNo);
        void UpdateConfigurationInfo(string invseries);
        FlightMaster GetFlightMasterInfo(string FlightNo);
        FlightSchedule GetFlightScheduleInfo(string FlightNo);
        Dictionary<string,string> GetAirlineCodeList(string AirlineCode);
        bool CheckTurboOptions(string registrationNo,string airlineCode,bool turboflag);
        AirlineMaster GetAirlineMasterInfo(string airlineCode,string airlineName,string airlineFlag);
        int SaveTransaction(Transactions transactions);
    }
}
