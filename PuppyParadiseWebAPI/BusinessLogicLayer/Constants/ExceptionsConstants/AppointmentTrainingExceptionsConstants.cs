using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Constants.ExceptionsConstants
{
    public class AppointmentTrainingExceptionsConstants
    {
        public const string TrainingAppointmentWithGivenIdNotFound = "Training appointment with this ID doesn't exist.";
        public const string AppointmentIsInThePast = "Cannot create an appointment in the past.";
        public const string DogHasOverlappingAppointment = "The selected dog already has another training appointment during the requested time.";
    }
}
