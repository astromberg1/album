using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppen.Models;
using WebAppen.Utilities;
using DAL.Repositories;
using System.Threading;
using System.IO;
using Microsoft.Owin.Security.Provider;

namespace WebAppen.Controllers
{
    [Authorize]
    public class PhotoController : Controller
        {
        private  PhotoRepository repo = new PhotoRepository();
        private UserRepository Userrepo = new UserRepository();
            private static AlbumRepository albumrepo = new AlbumRepository();

        public PhotoController()
            {
           
            }

        // GET: Picture
      
        public ActionResult Show(AlbumVM model)
            {
            var photos = new List<PhotoVM>();
            var photosFromDB = repo.All().Where(x => x.AlbumID == model.id);
            foreach (var photo in photosFromDB)
                {
                photos.Add(ModelMapper.EntityToModel(photo));
                }
            ViewBag.AlbumName = model.Name;
            return View(photos);
            }


            public ActionResult Showphotos(int id)
            {

                string resultat = "<p>";
                var photosFromDB = repo.All().Where(x => x.AlbumID == id);
                int i = 0;
                foreach (var photo in photosFromDB)
                {
                    i++;
                    resultat = resultat + "nr: "+ i.ToString() +" "+ photo.Datecreated + " " + photo.Name +"</p>"; 

                }

                
                return Content(resultat);
            }

        public ActionResult Details(PhotoVM photo)
            {
            var photoModel = ModelMapper.EntityToModel(repo.ByID(photo.id));
            return View(photoModel);
            }

        public ActionResult Create(AlbumVM model)
            {
            
            PhotoVM p = new PhotoVM();
                p.AlbumID = model.id;
                p.Name = "";
                p.Description = "";
            return View(p);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhotoVM model, HttpPostedFileBase photo)
            {
            Thread.Sleep(5000);
            var identity = User.Identity.Name;
            int? userID = Userrepo.GetID(identity);
            model.UserID = (int)userID;
            model.DatePosted = DateTime.Now;
            string photoFolder = Server.MapPath("~/Images");

            var path = string.Empty;
            var fileName = string.Empty;
            if (photo != null && photo.ContentLength > 0)
            {
                var rek = repo.GetNewIndex();
                    fileName = "pc" + rek + "al" + model.AlbumID + Path.GetFileName(photo.FileName);
                if (!Helpers.IsFilePhoto(fileName))
                    {
                    return Content("Filen måste ha formatet png, jpg or jpeg");
                    }
                path = Path.Combine(photoFolder, fileName);
                photo.SaveAs(path);


                }
            else
                {
                return Content("Du måste välja en fil!");
                }


            model.Path = "~/Images/" + fileName;




            if (ModelState.IsValid)
            {
              
                var newPhoto = ModelMapper.ModelToEntity(model);
                repo.AddOrUpdate(newPhoto);

                return Content("Added fil");

                //return Json(Url.Action("ViewAlbum", "Album", new { id = model.AlbumID }));

            }
                var result1 = "nånting gick fel";
                return Json(Request.UrlReferrer.ToString());
        }

        public ActionResult Delete(PhotoVM model)
            {
            return View(model);
            }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, int AlbumID)
            {
            string filePath = string.Empty;

            if (id != null && User.Identity.IsAuthenticated)
                {
                
                int photoID = (int)id;

                var photoToRemove = repo.ByID(photoID);
                //int AlbumID = (int)photoToRemove.AlbumID;

                if (photoToRemove != null)
                    {
                      
                    filePath = Request.MapPath(photoToRemove.Path);
                    FileInfo file = new FileInfo(filePath);

                    repo.Delete(photoToRemove.ID);


                    if (file.Exists)
                        {
                        file.Delete();
                        }
                    }

                                     return Json(Url.Action("ViewAlbum", "Album", new { id = AlbumID }));
                }
                //return new RedirectResult(Url.Action("ViewAlbum", "Album", new { id = AlbumID }));
                    

            return Json(Request.UrlReferrer.ToString());
        }

        public ActionResult Edit(int id)
            {
            var model = new PhotoVM();

            var photoFromDB = repo.ByID(id);
            if (photoFromDB != null)
                {
                model = ModelMapper.EntityToModel(photoFromDB);
                }

            return View(model);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult EditPhoto(PhotoVM model, HttpPostedFileBase file)
            {
            string photoFolder = Server.MapPath("../../Images");

            var path = string.Empty;
            var fileName = string.Empty;

            if (file != null && file.ContentLength > 0)
                {

                fileName = "pc" + model.id + "al" + model.AlbumID + Path.GetFileName(file.FileName);
                path = Path.Combine(photoFolder, fileName);

                file.SaveAs(path);

                model.Path = "~/Images/" + fileName;

                RemoveOldFileIfExists(model);

                }
            model.DateEdited = DateTime.Now;
            if (ModelState.IsValid)
                {
                var photoToUpdate = ModelMapper.ModelToEntity(model);
                repo.AddOrUpdate(photoToUpdate);
                return RedirectToAction("Details", "Photo", model);
                }

            ModelState.AddModelError("", "gick inte att uppdatera info");
            return View(model);

            }

        private void RemoveOldFileIfExists(PhotoVM photo)
            {
            var oldphoto = repo.ByID(photo.id);
            if (oldphoto.Path != photo.Path)
                {
                var oldPhysicalPath = Request.MapPath(oldphoto.Path);
                FileInfo oldfile = new FileInfo(oldPhysicalPath);
                if (oldfile.Exists)
                    {
                    oldfile.Delete();
                    }
                }
            }
        }
    }