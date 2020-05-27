using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace QueryBuilder.WebApplication.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "CarlosJ";
        private const string adminPassword = "CCr.5180";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope=app.ApplicationServices.CreateScope())
            {
                UserManager<IdentityUser> userManager = scope.ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();
                IdentityUser user = await userManager.FindByIdAsync(adminUser);
                if (user == null)
                {
                    user = new IdentityUser(adminUser);
                    await userManager.CreateAsync(user, adminPassword);
                }
            }
            
        }
    }
}
