using Biblioteka_ASP.Models;
using Microsoft.AspNetCore.Identity;

namespace Biblioteka_ASP.Roles
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider .CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Admin", "Librarian", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));  
                }
            }

            var adminEmail = "patryk@test.pl";
            var adminPassword = "patryk123!";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Imie = "Patryk",
                    Nazwisko = "Matusiak",
                };
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    throw new Exception("Nie udało się stworzyć Admina" + string.Join(", ", result.Errors.Select(e => e.Description)));
                }

            }
            else
            {
                if(!await userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                   await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
