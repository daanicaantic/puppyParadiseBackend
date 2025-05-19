using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Constants.ExceptionsConstants
{
    public static class AuthorizationExceptionsConstants
    {
        public const string MissingUserIdClaim = "User ID claim is missing.";
        public const string InvalidUserIdClaim = "User ID claim is invalid.";
    }
}
