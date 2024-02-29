using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

public class AppClaimsFactory : IUserClaimsPrincipalFactory<IdentityUser>
{
    public Task<ClaimsPrincipal> CreateAsync(IdentityUser user)
    {

       var claims = new Claim[] {
      new(ClaimTypes.Email, user.Email!),
      new(ClaimTypes.Name, user.UserName!),
      new(ClaimTypes.NameIdentifier, user.Id),
      new(ClaimTypes.Authentication, "true"),
    };
        var claimsIdentity = new ClaimsIdentity(claims, "Bearer");

        ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

        return Task.FromResult(claimsPrincipal);

    }
}