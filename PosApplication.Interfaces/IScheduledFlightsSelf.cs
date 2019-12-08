using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface IScheduledFlightsSelf
    {
        DataTable GetFlightRescheduleData(string LoginUser);
        DataTable GetFlightScheduleData(string LoginUser);
        List<AirlineMaster> GetAirlineMasterData(string airlinename);
        List<string> GetFlightScheduleData(string FlightNo,string BillTo,string supplier,string AirlineFlag );
    }
}
