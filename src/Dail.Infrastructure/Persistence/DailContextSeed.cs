using Dail.Domain.Constants;
using Dail.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace Dail.Infrastructure.Persistence;

public static class DailContextSeed
{
    public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
    {
        var defaultUser = new ApplicationUser { UserName = "admin", Email = "admin@dail.com" };

        if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
        {
            await userManager.CreateAsync(defaultUser, "Pass@123456");
            await userManager.AddToRoleAsync(defaultUser, SystemRoles.Admin);
        }

        var defaultDailUser = new ApplicationUser { UserName = "dail", Email = "dail@dail.com" };

        if (userManager.Users.All(u => u.UserName != defaultDailUser.UserName))
        {
            await userManager.CreateAsync(defaultDailUser, "Pass@123456");
            await userManager.AddToRoleAsync(defaultDailUser, SystemRoles.DailUser);
        }
    }

    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        foreach (FieldInfo field in typeof(SystemRoles).GetFields())
        {
            var role = field.GetValue(null)!.ToString();
            if (roleManager.Roles.All(r => r.Name != role))
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = role });
            }
        }
    }
}