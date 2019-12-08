using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface IDailyAvailableFlights
    {
        DataSet GetFlightMastersData();
        DataSet GetFlightScheduleNews(int day);
        FlightScheduleNew GetFlightScheduleNew(string flightNo);
    }
}
