using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebApp
{
    public class IdentityInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string email = StaticData.Email;
            string password = StaticData.Password;
            if (await roleManager.FindByNameAsync(StaticData.Admin) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(StaticData.Admin));
            }
            if (await roleManager.FindByNameAsync(StaticData.Worker) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(StaticData.Worker));
            }
            if (await userManager.FindByNameAsync(email) == null)
            {
                var admin = new IdentityUser { Email = email, UserName = email };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, StaticData.Admin);
                }
            }
        }
    }
}
