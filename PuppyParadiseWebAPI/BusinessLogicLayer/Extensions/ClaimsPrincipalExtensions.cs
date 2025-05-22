using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Data;
using System.Net;
using BusinessLogicLayer.Constants.ExceptionsConstants;

namespace BusinessLogicLayer.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetRequiredUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                throw new UnauthorizedAccessException(AuthorizationExceptionsConstants.MissingUserIdClaim);

            if (!int.TryParse(userId, out int parseId))
                throw new UnauthorizedAccessException(AuthorizationExceptionsConstants.InvalidUserIdClaim);

            return parseId;
        }
    }
}
