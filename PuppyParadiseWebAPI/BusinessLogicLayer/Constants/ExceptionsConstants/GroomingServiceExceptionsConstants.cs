using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Constants.ExceptionsConstants
{
    public class GroomingServiceExceptionsConstants
    {
        public const string GroomingServiceWithGivenIdNotFound = "Grooming service with this ID doesn't exist.";
        public const string MissingGroomingService = "Grooming service(s) with ID(s) {0} not found.";
    }
}
