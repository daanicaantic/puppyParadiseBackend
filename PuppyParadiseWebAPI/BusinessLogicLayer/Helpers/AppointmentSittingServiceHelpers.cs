using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Constants.ExceptionsConstants;

namespace BusinessLogicLayer.Helpers
{
    public class AppointmentSittingServiceHelpers
    {
        public static (DateTime Dropoff, DateTime Pickup) ValidateAndGetDateTimes(DateOnly dropoffDate, TimeOnly dropoffTime, DateOnly pickupDate, TimeOnly pickupTime)
        {
            var dropoff = dropoffDate.ToDateTime(dropoffTime);
            var pickup = pickupDate.ToDateTime(pickupTime);
            var now = DateTime.Now;

            if (pickup <= dropoff)
                throw new Exception(AppointmentSittingExceptionsConstants.PickupTimeMustBeAfterDropoffTime);

            if (dropoff < now || pickup < now)
                throw new Exception(AppointmentSittingExceptionsConstants.AppointmentIsInThePast);

            return (dropoff, pickup);
        }
    }
}
