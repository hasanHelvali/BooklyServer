using Bookly.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Bookly.Persistence.Seeds;
public static class DataSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();

        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new AppRole { Name = "Admin" });

        if (!await roleManager.RoleExistsAsync("Customer"))
            await roleManager.CreateAsync(new AppRole { Name = "Customer" });

        if (await userManager.FindByEmailAsync("admin@bookly.com") == null)
        {
            var admin = new User
            {
                UserName = "admin@bookly.com",
                Email = "admin@bookly.com",
                FirstName = "Admin",
                LastName = "Bookly",
                IsActive = true,
                
            };
            admin.NotHashPass = "Admin1234";

            await userManager.CreateAsync(admin, "Admin1234");
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
