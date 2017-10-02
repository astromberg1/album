using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interface;
using DAL.DataModels;
using System.Data.Entity;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;


namespace DAL.Repositories
    {

   public class PhotoRepository:IPhotoRepository
        {

        public bool AddOrUpdate(PhotoDataModel photo)
            {
            try
                {
                using (var ctx = new MVCContext())
                    {
                    var photoToUpdate = ctx.Photos.Where(p => p.ID == photo.ID)
                        .Include(p => p.User)
                        .Include(p => p.Comments)
                        .Include(p => p.Album)
                        .FirstOrDefault();


                    if (photoToUpdate != null)
                        {
                        photoToUpdate.Name = photo.Name;
                        photoToUpdate.AlbumID = photo.AlbumID;
                        photoToUpdate.Path = photo.Path;
                        photoToUpdate.publik = photo.publik;
                        photoToUpdate.Description = photo.Description;
                        photoToUpdate.Datecreated = photo.Dateupdated;
                        ctx.SaveChanges();
                        return true;
                        }
                    else
                        {
                        var newPhoto = new PhotoDataModel();
                        newPhoto.User = photo.User;
                        newPhoto.Album = photo.Album;
                        newPhoto.Name = photo.Name;
                        newPhoto.AlbumID = photo.AlbumID;
                        newPhoto.Path = photo.Path;
                        newPhoto.publik = photo.publik;
                        newPhoto.Description = photo.Description;
                        newPhoto.Datecreated = photo.Datecreated;
                        newPhoto.Dateupdated = photo.Dateupdated;
                        newPhoto.UserID = photo.UserID;
                        ctx.Photos.Add(newPhoto);
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

        public IEnumerable<PhotoDataModel> All()
            {
            using (var ctx = new MVCContext())
                {
                var photos = ctx.Photos
                        .Include(p => p.Comments)
                        .Include(p => p.Album)
                        .Include(p => p.User);
                return photos.ToList();
                }
            }


            public int GetNewIndex()
            {
                using (var ctx = new MVCContext())
                {
                    var photos = ctx.Photos
                        .Include(p => p.Comments)
                        .Include(p => p.Album)
                        .Include(p => p.User);
                    var res = photos.OrderByDescending(i => i.ID).FirstOrDefault();
               

                    if (res == null)
                        return 1;
                    else
                        return res.ID+1;

                }
            }


        public PhotoDataModel ByID(int id)
            {

            

            using (var ctx = new MVCContext())
                {
                var photo = ctx.Photos.Where(p => p.ID == id)
                        .Include(p => p.User)
                        .Include(p => p.Comments)
                        .Include(p => p.Album)
                        .FirstOrDefault();
                return photo;
                }
            }

        public bool Delete(int id)
            {
            using (var ctx = new MVCContext())
                {
                var photo = ctx.Photos.Where(p => p.ID == id)
                        .Include(p => p.User)
                        .Include(p => p.Comments)
                        .Include(p => p.Album)
                        .FirstOrDefault();
                if (photo != null)
                    {
                    
                    ctx.Comments.RemoveRange(photo.Comments);
                

                    ctx.Photos.Remove(photo);
                    ctx.SaveChanges();
                    return true;
                    }
                else
                    {
                    return false;
                    }
                }
            }
        }


    }
    
