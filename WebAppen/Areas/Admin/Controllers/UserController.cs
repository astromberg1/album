using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using WebAppen.Models;
using DAL.Repositories;
using WebAppen.Utilities;
using System.Collections;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using WebAppen.Controllers;
using Microsoft.AspNet.Identity.Owin;

namespace WebAppen.Areas.Admin.Controllers
{
  

    [Authorize]

    public class UserController : Controller
    {
        UserRepository userrepo = new UserRepository();
        UserVM _uservm = new UserVM();
      
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public UserController()
        {
            //var controller = DependencyResolver.Current.GetService<AccountController>();
            //controller.ControllerContext = new ControllerContext(this.Request.RequestContext, controller);
            
            


        }


        

        // GET: Admin/User
        public ActionResult Index()
        {
            List<UserVM> userlista = new List<UserVM>();
            var model = userrepo.All();

            foreach (var item in model)
                {
                userlista.Add(ModelMapper.EntityToModel(item));

                }

            

            return View(userlista);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int pid = (int)id;
            UserVM userVM = ModelMapper.EntityToModel(userrepo.ByID(pid));
            if (userVM == null)
            {
                return HttpNotFound();
            }
            return View(userVM);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FirstName,LastName,Email")] UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                //userrepo.AddOrUpdate(userVM);
                
                return RedirectToAction("Index");
            }

            return View(userVM);
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int pid = (int)id;
            UserVM userVM = ModelMapper.EntityToModel(userrepo.ByID(pid));
            
            if (userVM == null)
            {
                return HttpNotFound();
            }
            return View(userVM);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstName,LastName,Email")] UserVM userVM)
        {
            if (ModelState.IsValid)
            {

                
                userrepo.AddOrUpdate(ModelMapper.ModelToEntity(userVM));


                return RedirectToAction("Index");
            }
            return View(userVM);
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int pid = (int)id;
            UserVM userVM = ModelMapper.EntityToModel(userrepo.ByID(pid));

            
            if (userVM == null)
            {
                return HttpNotFound();
            }
            return View(userVM);
        }



        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)


        {

            ApplicationDbContext appdb = new ApplicationDbContext();
            int pid = (int)id;
            UserVM userVM = ModelMapper.EntityToModel(userrepo.ByID(pid));

            if (userVM.Email != User.Identity.Name)
            {






                userrepo.Delete(id);
                return RedirectToAction("Delete", "Account",
                          new { strid = userVM.Idguid.ToString(), Area = "" });

            }


            //går inte att deleta sig själv






            return RedirectToAction("Index");
        }


    }
    }
