using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Constants.ExceptionsConstants
{
    public static class AppointmentWalkingExceptionsConstants
    {
        public const string AppointmentWalkingWithGivenIdNotFound = "AppointmentWalking with this ID doesn't exist.";
        public const string UnauthorizedToDeleteAppointment = "You are not authorized to delete this appointment.";
    }
}
