using System.Security.Claims;
using AppointBackEnd.Core.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AppointBackEnd.Core;

public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
{

    public CustomUserClaimsPrincipalFactory(
        UserManager<User> userManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    {
        // https://levelup.gitconnected.com/add-extra-user-claims-in-asp-net-core-web-applications-1f28c98c9ec6
        var identity = await base.GenerateClaimsAsync(user);
        var userWithHospitals = await this.UserManager.Users
            .SingleAsync();

        var roles = await this.UserManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            identity.AddClaim(new Claim(ClaimTypes.Role, role));
        }

        return identity;
    }
    
}