namespace PalmerBlog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PalmerBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PalmerBlog.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            if(!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if(!context.Users.Any(u => u.Email == "ecpalmer21@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ecpalmer21@gmail.com",
                    Email = "ecpalmer21@gmail.com",
                    FirstName = "Ele",
                    LastName = "Palmer",
                    DisplayName = "Ele"
                }, "ladybu2");
            }

            var userId = userManager.FindByEmail("ecpalmer21@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");
                         
        }
    }
}
