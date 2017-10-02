using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppen.Models;
using WebAppen.Utilities;
using DAL.Repositories;
using System.Threading;

namespace WebAppen.Controllers
    {
    [Authorize]
    public class HomeController : Controller
        {
        private  static PhotoRepository repo = new PhotoRepository();

        public HomeController()
            {
            

            }


        
        public ActionResult Index()
            {
            
                Random randomerare = new Random(Guid.NewGuid().GetHashCode());




            //Thread.Sleep(2000);
            var LatestPhotos = new List<PhotoVM>();
            if (repo != null)
            {
                int antalfotos = repo.All().ToList().Count;
                if (antalfotos > 0)
                {
                    if (antalfotos > 10) antalfotos = 10;
                    int tal = randomerare.Next(1, 9);
                    if (tal > antalfotos) tal = antalfotos;
                    var photosFromDB = repo.All().OrderByDescending(x => x.Datecreated).Take(tal).ToList();
                    foreach (var photo in photosFromDB)
                    {
                        LatestPhotos.Add(ModelMapper.EntityToModel(photo));
                    }
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