using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public static class AppointmentDateTimeValidator
    {
        public static bool IsValidAppointmentDate(DateOnly date, TimeOnly time)
        {
            var appointmentDateTime = date.ToDateTime(time);
            return appointmentDateTime > DateTime.Now;
        }
    }
}
