using Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Data
{
    public class Seed
    {
 
            public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
            {
                var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string[] roleNames = { "Admin", "Manager", "Member" };
                IdentityResult roleResult;

                foreach (var roleName in roleNames)
                {
                    var roleExist = await RoleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
      
    }
}
