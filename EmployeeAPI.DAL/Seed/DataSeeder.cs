using EmployeeAPI.Core.Entities;
using EmployeeAPI.DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeAPI.DAL.Seed;

public static class DataSeeder
{
    public async static Task<int> SeedDataAsync(this IApplicationBuilder app, IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<EmployeeAPIDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<Employee>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var isAdminUserExist = await userManager.FindByEmailAsync("mr.admin@gmail.com");

        if (isAdminUserExist == null)
        {
            var isAdminRoleExist = await roleManager.RoleExistsAsync("Admin");
            if(isAdminRoleExist == false)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var admin = new Employee()
            {
                Name = "Admin",
                Surname = "Admin",
                Email = "mr.admin@gmail.com",
                UserName = "admin"
            };
            
            var user = await userManager.CreateAsync(admin, "admin123");
            
            if (!user.Succeeded)
            {
                throw new Exception("Error while creating admin");
            }
            
            await userManager.AddToRoleAsync(admin, "Admin");
        }
        
        await context.SaveChangesAsync(); // Сохраняем изменения
        
        return 1;
    }
}