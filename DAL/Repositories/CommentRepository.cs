using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interface;
using DAL.DataModels;
using System.Data.Entity;

namespace DAL.Repositories
    {
   
        public class CommentRepository : ICommentRepository
            {
            public bool AddOrUpdate(CommentsDataModel comment)
                {
                try
                    {
                    using (var ctx = new MVCContext())
                        {
                        var commentToUpdate = ctx.Comments.Where(c => c.ID == comment.ID)
                            .Include(c => c.User)
                            .Include(c => c.Photo)
                        
                            .FirstOrDefault();
                        if (commentToUpdate != null) //EDIT
                            {
                     
                        commentToUpdate.User = comment.User;
                        commentToUpdate.Photo = comment.Photo;


                        commentToUpdate.UserID = comment.UserID;
                        commentToUpdate.PhotoID = comment.PhotoID;
                        commentToUpdate.Comment = comment.Comment;
                        commentToUpdate.Title = comment.Title;
                        commentToUpdate.Dateupdated = comment.Dateupdated;
                            ctx.SaveChanges();
                            return true;
                            }
                        else
                            {
                            var newComment = new CommentsDataModel();
                          
                            newComment.User = comment.User;
                            newComment.Photo = comment.Photo;
                            newComment.Comment = comment.Comment;
                        newComment.Title = comment.Title;
                        newComment.Datecreated = comment.Datecreated;
                        newComment.Dateupdated = comment.Dateupdated;
                        newComment.UserID = comment.UserID;
                            newComment.PhotoID = comment.PhotoID;
                            ctx.Comments.Add(newComment);
                            ctx.SaveChanges();
                            return true;
                            }
                        }
                    }
                catch (Exception e)
                    {
                    //Handle exceptions
                    }
                return false;
                }

            public IEnumerable<CommentsDataModel> All()
                {
                using (var ctx = new MVCContext())
                    {
                var comments = ctx.Comments
                    .Include(c => c.User)
                        .Include(c => c.Photo);
                     
                        return comments.ToList();
                    }
                }

                public int GetNewIndex()
                {
                    using (var ctx = new MVCContext())
                    {
                        var comments = ctx.Comments
                            .Include(c => c.User)
                            .Include(c => c.Photo);

                          var res = comments.OrderBy(x => x.ID).LastOrDefault();

                        if (res == null)
                            return 1;
                        else
                            return res.ID + 1;

                    }
                }

        public CommentsDataModel ByID(int id)
                {
                using (var ctx = new MVCContext())
                    {
                    var comment = ctx.Comments.Where(c => c.ID == id)
                           .Include(c => c.User)
                            .Include(c => c.Photo)
                           
                            .FirstOrDefault();
                    return comment;
                    }
                }

            public bool Delete(int id)
                {
                using (var ctx = new MVCContext())
                    {
                    var comment = ctx.Comments.Where(c => c.ID == id)
                            .Include(c => c.User)
                            .Include(c => c.Photo)
                           
                            .FirstOrDefault();
                if (comment != null)
                        {
                        ctx.Comments.Remove(comment);
                        ctx.SaveChanges();
                        return true;
                        }
                    }
                return false;
                }
            }

        }
    
