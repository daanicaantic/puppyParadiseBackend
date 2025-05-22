using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Constants.ExceptionsConstants
{
    public static class DogExceptionsConstants
    {
        public const string DogWithGivenIdNotFound = "Dog with this ID doesn't exist.";
        public const string DogWithGivenWeightNotFound = "Dog with this weight doesn't exist.";
        public const string DogOwnershipMismatch = "You do not have permission to schedule an appointment for this dog.";
        public const string NegativeDogWeight = "A dog's weight cannot be negative.";

        public const string UnknownDogSize = "Unknown dog size.";
        public const string RequiredDogSize = "Dog size is required.";
    }
}
