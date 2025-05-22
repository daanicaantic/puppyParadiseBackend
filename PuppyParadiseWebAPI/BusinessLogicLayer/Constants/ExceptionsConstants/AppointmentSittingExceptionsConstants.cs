using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Constants.ExceptionsConstants
{
    public class AppointmentSittingExceptionsConstants
    {
        public const string SittingAppointmentWithGivenIdNotFound = "Sitting appointment with this ID doesn't exist.";
        public const string PickupTimeMustBeAfterDropoffTime = "Pickup time must be after dropoff time.";
    }
}
