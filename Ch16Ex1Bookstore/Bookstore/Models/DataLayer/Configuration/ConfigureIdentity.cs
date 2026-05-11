using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Models
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<User>>();

            string roleName = "Admin";
            string username = "admin";
            string password = "Sesame";

            if (await roleManager.FindByNameAsync(roleName) == null) {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            if (await userManager.FindByNameAsync(username) == null) {
                var user = new User {
                    UserName = username,
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@example.com"
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
