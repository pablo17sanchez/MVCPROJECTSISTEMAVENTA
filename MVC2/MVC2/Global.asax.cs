using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using MVC2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.MVC2Context,Migrations.Configuration>());
            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);
            CreateUsers(db);
            AddpermisonstoSuperuser(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddpermisonstoSuperuser(ApplicationDbContext db)
        {
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var rolmanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var user = usermanager.FindByName("pablo17sanchez@hotmail.com");
            if (!usermanager.IsInRole(user.Id,"View"))
            {
                usermanager.AddToRole(user.Id, "View");
            }
            if (!usermanager.IsInRole(user.Id, "Edit"))
            {
                usermanager.AddToRole(user.Id, "Edit");
            }
            if (!usermanager.IsInRole(user.Id, "Delete"))
            {
                usermanager.AddToRole(user.Id, "Delete");
            }
            if (!usermanager.IsInRole(user.Id, "Create"))
            {
                usermanager.AddToRole(user.Id, "Create");
            }

        }

        private void CreateUsers(ApplicationDbContext db)
        {
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = usermanager.FindByName("pablo17sanchez@hotmail.com");
            if (user==null)
            {
                user = new ApplicationUser
                {
                    UserName = "pablo17sanchez@hotmail.com",
                    Email = "pablo17sanchez@hotmail.com",

                };
                usermanager.Create(user,"Ciscopack1*"); 
                
            }
        }

        private void CreateRoles(ApplicationDbContext db)
        {//Manipular los Roles
            var rolmanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!rolmanager.RoleExists("View"))
            {
                rolmanager.Create(new IdentityRole("View"));
            }
            if (!rolmanager.RoleExists("Edit"))
            {
                rolmanager.Create(new IdentityRole("Edit"));
            }

            if (!rolmanager.RoleExists("Delete"))
            {
                rolmanager.Create(new IdentityRole("Delete"));
            }
            if (!rolmanager.RoleExists("Create"))
            {
                rolmanager.Create(new IdentityRole("Create"));
            }

        }
    }
}
