using DataLayer;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebApp
{
    public class IdentityInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ServiceStationContext serviceStationContext)
        {
            string email = "mashaprotskaya@gmail.com";
            string password = "pass";
            if (await roleManager.FindByNameAsync(Roles.Admin) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                serviceStationContext.SaveChanges();
            }
            if (await roleManager.FindByNameAsync(Roles.User) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.User));
                serviceStationContext.SaveChanges();
            }
            if (await userManager.FindByNameAsync(email) == null)
            {
                var admin = new IdentityUser { Email = email, UserName = email };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Roles.Admin);
                    serviceStationContext.SaveChanges();
                }
            }
        }
    }
}
