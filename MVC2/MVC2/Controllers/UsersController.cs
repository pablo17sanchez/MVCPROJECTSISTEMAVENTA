using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC2.Models;
using MVC2.ViewModels;

namespace MVC2.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = usermanager.Users.ToList();
            var userviews = new List<UserView>();
            foreach (var users in user)
            {
                var userview = new UserView { 
                
                Email= users.Email,
                Name= users.UserName,
                UserID = users.Id

                
                
                };
                userviews.Add(userview);
            }

            return View(userviews);  
        }

        public ActionResult Roles(string userid)
        {
            var rolmanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = usermanager.Users.ToList();
            var roles = rolmanager.Roles.ToList();
            var unicouser = user.Find(x => x.Id == userid);
            var rolesview = new List<Rollview>();

            if (String.IsNullOrEmpty(userid))
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (unicouser==null)
            {
                return HttpNotFound();
            }
          
            foreach (var item in unicouser.Roles)
            {
                var role = roles.Find(x => x.Id == item.RoleId);

                var roleview =  new Rollview{
                RoleID= item.RoleId,
                Name=role.Name

                
                };
                rolesview.Add(roleview);
            }
            



            var userview = new UserView
            {
                Email = unicouser.Email,
                Name= unicouser.UserName,
                UserID = unicouser.Id,
                Roles= rolesview

            };



            return View(userview);
        }


        public ActionResult AddRole(string userid)
        {
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = usermanager.Users.ToList();
            
            var unicouser = user.Find(x => x.Id == userid);
            var rolesview = new List<Rollview>();

            if (String.IsNullOrEmpty(userid))
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (unicouser == null)
            {
                return HttpNotFound();
            }


            var userview = new UserView
            {
                Email = unicouser.Email,
                Name = unicouser.UserName,
                UserID = unicouser.Id,
                Roles = rolesview

            };
            var rolmanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var lista = rolmanager.Roles.ToList();
            lista.Add(new IdentityRole { Id = "", Name = "[Seleccione un roll...]" });
            lista.OrderBy(x => x.Name).ToList();
            ViewBag.RoleID = new SelectList(lista, "Id", "Name");
            //ViewBag.Error = "Debe seleccionar un cliente";
            return View(userview);
        }
        [HttpPost]
        public ActionResult AddRole(string userid,FormCollection form)
        {
            var rolid = Request["RoleID"];
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = usermanager.Users.ToList();
            var rolmanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var unicouser = user.Find(x => x.Id == userid);
            var rolesview = new List<Rollview>();

            if (String.IsNullOrEmpty(userid))
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (unicouser == null)
            {
                return HttpNotFound();
            }


            var userview = new UserView
            {
                Email = unicouser.Email,
                Name = unicouser.UserName,
                UserID = unicouser.Id,
                Roles = rolesview

            };
            if (String.IsNullOrEmpty(rolid))
            {
                 ViewBag.Error = "Tienes que seleccionar un rol ";
              
                
                 var lista = rolmanager.Roles.ToList();
                 lista.Add(new IdentityRole { Id = "", Name = "[Seleccione un roll...]" });
                 lista.OrderBy(x => x.Name).ToList();
                 ViewBag.RoleID = new SelectList(lista, "Id", "Name");
                 //ViewBag.Error = "Debe seleccionar un cliente";
                 return View(userview);
            }
            var roles = rolmanager.Roles.ToList().Find(r=>r.Id==rolid);

           
            if (!usermanager.IsInRole(unicouser.Id,roles.Name))
            {
                usermanager.AddToRole(userid, roles.Name);
            }

            //var rolesview = new List<Rollview>();

            if (String.IsNullOrEmpty(userid))
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (unicouser == null)
            {
                return HttpNotFound();
            }

            foreach (var item in unicouser.Roles)
            {
                var role = rolmanager.Roles.ToList().Find(x => x.Id == item.RoleId);

                var roleview = new Rollview
                {
                    RoleID = item.RoleId,
                    Name = role.Name


                };
                rolesview.Add(roleview);
            }




            var userView = new UserView
            {
                Email = unicouser.Email,
                Name = unicouser.UserName,
                UserID = unicouser.Id,
                Roles = rolesview

            };



            return View("Roles", userView);

        }
        public ActionResult Delete(string userid, string rolid)
        {
            var rolesview = new List<Rollview>();


            if (String.IsNullOrEmpty(userid)||String.IsNullOrEmpty(rolid))
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var rolmanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var useruario = usermanager.Users.ToList().Find(x => x.Id == userid);
            var rol = rolmanager.Roles.ToList().Find(x => x.Id == rolid);
            if (usermanager.IsInRole(useruario.Id,rol.Name))
            {
                usermanager.RemoveFromRole(useruario.Id, rol.Name);
                
            }

            if (useruario == null)
            {
                return HttpNotFound();
            }

            foreach (var item in useruario.Roles)
            {
                var role = rolmanager.Roles.ToList().Find(x => x.Id == item.RoleId);

                var roleview = new Rollview
                {
                    RoleID = item.RoleId,
                    Name = role.Name


                };
                rolesview.Add(roleview);
            }




            var userview = new UserView
            {
                Email = useruario.Email,
                Name = useruario.UserName,
                UserID = useruario.Id,
                Roles = rolesview

            };



            return View("Roles",userview);

          
        
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
         
        }
    }
}