using System;
using System.Linq;
using System.Threading.Tasks;
using FoJo.Business.Database;
using FoJo.Business.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FoJo.Business.Services.Implementations
{
    public class FoJoDBMigrator : IDBMigrator
    {
        private FoJoDbContext DbContext { get; }
        private UserManager<IdentityUser> UserManager { get; }
        private RoleManager<IdentityRole> RoleManager { get; }

        public FoJoDBMigrator(FoJoDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            RoleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }


        public async Task ExecuteAsync()
        {
            await DbContext.Database.MigrateAsync();

            var adminRole = await TryCreateRoleAsync("Administrator");

            await TryCreateUserAsync("Admin", adminRole.Name, "admin");

            await DbContext.SaveChangesAsync();
        }


        private async Task<IdentityRole> TryCreateRoleAsync(string roleName)
        {
            var role = await RoleManager.FindByNameAsync(roleName);

            if (role != null)
                return role;

            role = new IdentityRole(roleName);
            var createRoleResult = await RoleManager.CreateAsync(role);
            if (!createRoleResult.Succeeded)
            {
                throw new AggregateException(createRoleResult.Errors.Select(e => new InvalidOperationException(e.Description)));
            }

            return role;
        }



        private async Task<IdentityUser> TryCreateUserAsync(string userName, string roleName, string password)
        {
            var user = await UserManager.FindByNameAsync(userName);
            if (user != null)
                return user;

            user = new IdentityUser(userName)
            {
                Email = $"{userName}@{userName}.{userName}",
                EmailConfirmed = true,
            };

            var userCreateResult = await UserManager.CreateAsync(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new AggregateException(userCreateResult.Errors.Select(e => new InvalidOperationException(e.Description)));
            }

            var addToRoleResult = await UserManager.AddToRoleAsync(user, roleName);
            if (!addToRoleResult.Succeeded)
            {
                throw new AggregateException(addToRoleResult.Errors.Select(e => new InvalidOperationException(e.Description)));
            }

            return user;
        }
    }
}
