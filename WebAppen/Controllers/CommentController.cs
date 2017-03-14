using DAL.Repositories;
using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebAppen.Models;
using WebAppen.Utilities;

namespace WebAppen.Controllers
    {
    [Authorize]
    public class CommentController : Controller
        {
           private CommentRepository repo = new CommentRepository();
        private  UserRepository Userrepo = new UserRepository();
        private PhotoRepository photorepo = new PhotoRepository();

        public CommentController()
                {
            
                }
            // GET: Comment
            [AllowAnonymous]
            public ActionResult Comments(int photoID)
                {
                var comments = new List<CommentsVM>();



                var commentsFromDB = repo.All().Where(x => x.PhotoID == photoID);

                foreach (var comment in commentsFromDB)
                    {
                    comments.Add(ModelMapper.EntityToModel(comment));
                    }


                return PartialView(comments);
                }

            public ActionResult NewComment(PhotoVM photo)
                {
                var newComment = new CommentsVM();
                newComment.PhotoID = photo.id;

                return View(newComment);
                }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult NewComment(CommentsVM model)
                {
            var identity = User.Identity.Name;
            int? userID = Userrepo.GetID(identity);

            model.UserID = (int)userID;
            var photomodel = photorepo.ByID(model.PhotoID);

            model.DatePosted = DateTime.Now;


                if (ModelState.IsValid && User.Identity.IsAuthenticated)
                    {

                    var newComment = ModelMapper.ModelToEntity(model);
                    repo.AddOrUpdate(newComment);
            
                return RedirectToAction("Details", "Photo", photomodel);

                }
            return RedirectToAction("Details", "Photo", photomodel);

            }
            [HttpPost]
            public ActionResult Delete(int commentID)
                {
                if (User.Identity.IsAuthenticated)
                    {
               
                    var commentToRemove = repo.ByID(commentID);
                        if (commentToRemove != null)
                            {
                            repo.Delete(commentID);
                            }
                        return Content("Kommentar borttagen");
                        }


                    
                return Content("gick inte att ta bort den");
                }
            }
        

    }