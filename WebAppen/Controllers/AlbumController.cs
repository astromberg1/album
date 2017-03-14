using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppen.Models;
using WebAppen.Utilities;
using DAL.Repositories.Interface;
using System.Security.Claims;
using System.IO;
using DAL.Repositories;

namespace WebAppen.Controllers
    {
    [Authorize]
    public class AlbumController : Controller
        {

        private AlbumRepository repo = new AlbumRepository();
        private  UserRepository Userrepo = new UserRepository();

        public AlbumController()
                {
           
                }

            [AllowAnonymous]
            public ActionResult Index()
                {
                var albums = new List<AlbumVM>();
            if (repo != null)
                {
                var albumsFromDB = repo.All();

                if (albumsFromDB != null)
                    {
                    foreach (var album in albumsFromDB)
                        {
                        var albumToAdd = ModelMapper.EntityToModel(album);
                        albums.Add(albumToAdd);
                        }
                    }

                }
                return View(albums);
                }
            [AllowAnonymous]
            public ActionResult ViewAlbum(int? id)
                {
                if (id == null)
                    {
                    return RedirectToAction("Index");
                    }

                AlbumVM albumToView = null;

                var albumID = (int)id;

                albumToView = ModelMapper.EntityToModel(repo.ByID(albumID));


                if (albumToView != null)
                    {
                    return View(albumToView);
                    }

                return RedirectToAction("Index");

                }

            public ActionResult Create()
                {

                return View(new AlbumVM());
                }
            [HttpPost]
            public ActionResult Create(AlbumVM model)
                {
                if (User.Identity.IsAuthenticated)
                    {
                var identity = User.Identity.Name;
                int? userID = Userrepo.GetID(identity);
                    if (userID != null)
                        {
                        model.DateCreated = DateTime.Now;
                        model.UserID = (int)userID;

                        var entity = ModelMapper.ModelToEntity(model);
                        repo.AddOrUpdate(entity);
                        }
                    return RedirectToAction("Index", "Album");
                    }
                return Redirect(Request.UrlReferrer.ToString());
                }
            [HttpPost]
            public ActionResult Delete(int albumID)
                {
                if (User.Identity.IsAuthenticated)
                    {
                var identity = User.Identity.Name;
                int? userID = Userrepo.GetID(identity);
                


                    var albumToRemove = repo.ByID(albumID);

                    if (albumToRemove.UserID == userID)
                        {

                        if (albumToRemove.photos != null)
                            {
                            foreach (var photo in albumToRemove.photos)
                                {
                                var filePath = Request.MapPath(photo.Path);
                                FileInfo file = new FileInfo(filePath);
                                if (file.Exists)
                                    {
                                    file.Delete();
                                    }
                                }
                            }


                        repo.Delete(albumToRemove.ID);
                        return Content("Album borttaget");
                        }
                    }
                return Content("Gick inte att ta bort");

                }

            public ActionResult AlbumList()
                {
                var albumList = new List<AlbumVM>();
                foreach (var album in repo.All())
                    {
                    albumList.Add(ModelMapper.EntityToModel(album));
                    }


                return PartialView("_AlbumListView", albumList);
                }
            }
        }