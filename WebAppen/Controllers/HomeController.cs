using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppen.Models;
using WebAppen.Utilities;
using DAL.Repositories;

namespace WebAppen.Controllers
    {
    [AllowAnonymous]
    public class HomeController : Controller
        {
        private  PhotoRepository repo = new PhotoRepository();

        public HomeController()
            {
            

            }
      


        public ActionResult Index()
            {

            var LatestPhotos = new List<PhotoVM>();
        if (repo !=null)
                { 
                var photosFromDB = repo.All().OrderByDescending(x => x.Datecreated).Take(4).ToList();
            foreach (var photo in photosFromDB)
                {
                LatestPhotos.Add(ModelMapper.EntityToModel(photo));
                }
            }

            return View(LatestPhotos);

            }

        public ActionResult About()
            {
            ViewBag.Message = "Your application description page.";

            return View();
            }

        public ActionResult Contact()
            {
            ViewBag.Message = "Your contact page.";

            return View();
            }
        }
    }