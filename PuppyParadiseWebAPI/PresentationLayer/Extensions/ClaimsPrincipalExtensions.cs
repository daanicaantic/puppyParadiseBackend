using System.Security.Claims;

namespace PresentationLayer.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)
                ?? user.Claims.FirstOrDefault(c => c.Type.Contains("nameidentifier"));

            if (userIdClaim == null)
                throw new UnauthorizedAccessException("User ID claim missing.");

            return int.Parse(userIdClaim.Value);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole("Admin");
        }
    }
}
