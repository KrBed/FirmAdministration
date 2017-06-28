using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.Owin;
using Owin;
using FirmAdministartion.Data;
using FirmAdministartion.Data.DataAccess;
using FirmAdministartion.Data.Identity;
using FirmAdministartion.Data.Identity.Config;
using FirmAdministration.Web.App_Start;
using FirmAdministration.Web.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(FirmAdministration.Web.Startup))]
namespace FirmAdministration.Web
{

    public partial class Startup
    {



        public void Configuration(IAppBuilder app)
        {

           
            CreateRolesAndUsers();
            ConfigureAuth(app);

        }

        private static void NewMethod()
        {
            Mapper.Initialize(x => x.CreateMap<ApplicationUser, UserViewModel>());
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));

                ApplicationUser user = new ApplicationUser()
                {
                    Email = "admin@wp.pl",
                    UserName = "admin@wp.pl",
                };

                string userPassword = "!QAZ1qaz";

                var newUser = userManager.Create(user, userPassword);

                if (newUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Manager"))
            {
                roleManager.Create(new IdentityRole("Manager"));
            }

            if (!roleManager.RoleExists("Employee"))
            {
                roleManager.Create(new IdentityRole("Employee"));
            }
        }

    }


}
