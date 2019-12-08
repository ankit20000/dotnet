using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface IScheduledFlightOther
    {
        DataTable GetFlightRescheduleData(string LoginUser);
        DataTable GetFlightScheduleData(string LoginUser);
    }
}
