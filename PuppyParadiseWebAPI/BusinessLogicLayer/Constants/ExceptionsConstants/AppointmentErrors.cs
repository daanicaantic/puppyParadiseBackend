using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Constants.ExceptionsConstants
{
    public static class AppointmentErrors
    {
        public const string CannotScheduleInPast = "You cannot schedule an appointment in the past.";
        public const string DogHasOverlappingAppointment = "The selected dog already has another appointment during the requested time.";
    }
}
