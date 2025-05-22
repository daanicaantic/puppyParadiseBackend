using System.Security.Claims;
using BusinessLogicLayer.Constants.ExceptionsConstants;
using DomainLayer.Constants;

namespace PresentationLayer.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                throw new UnauthorizedAccessException(AuthorizationExceptionsConstants.MissingUserIdClaim);

            return int.Parse(userIdClaim.Value);
        }

        public static int GetRequiredUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                throw new UnauthorizedAccessException(AuthorizationExceptionsConstants.MissingUserIdClaim);

            if (!int.TryParse(userId, out int parseId))
                throw new UnauthorizedAccessException(AuthorizationExceptionsConstants.InvalidUserIdClaim);

            return parseId;
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(ConstRoles.Admin);
        }
    }
}
