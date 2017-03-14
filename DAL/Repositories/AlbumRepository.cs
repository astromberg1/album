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
    public class AlbumRepository:IAlbumRepository
        {
        public bool AddOrUpdate(AlbumDataModel album)
            {
            try
                {
                using (var ctx = new MVCContext())
                    {
                    var albumToUpdate = ctx.Albums.Where(g => g.ID == album.ID)
                            .Include(g => g.photos)
                            .Include(g => g.User)
                            


                            .FirstOrDefault();
                    if (albumToUpdate != null)
                        {
                        albumToUpdate.Name = album.Name;
                        albumToUpdate.Description = album.Description;
                        ctx.SaveChanges();
                        return true;
                        }
                    else
                        {
                        var newAlbum = new AlbumDataModel();
                        newAlbum.UserID = album.UserID;
                        newAlbum.User = album.User;
                        newAlbum.Name = album.Name;
                        newAlbum.Description = album.Description;
                        newAlbum.DateCreated = DateTime.Now;
                        ctx.Albums.Add(newAlbum);
                        ctx.SaveChanges();
                        return true;
                        }
                    }
                }
            catch (Exception e)
                {
                // handle exceptions
                }

            return false;

            }

        public IEnumerable<AlbumDataModel> All()
            {
            using (var ctx = new MVCContext())
                {
                var albums = ctx.Albums
                            .Include(g => g.photos)
                            .Include(g => g.User)
                            ;

                return albums.ToList();
                }
            }

        public AlbumDataModel ByID(int ID)
            {
            using (var ctx = new MVCContext())
                {
                var albums = ctx.Albums.Where(g => g.ID == ID)
                            .Include(g => g.photos)
                            .Include(g => g.User)
                            .
                            FirstOrDefault();
                return albums;
                }
            }

        public bool Delete(int ID)
            {
            using (var ctx = new MVCContext())
                {
                var album = ctx.Albums.Where(g => g.ID == ID)
                            .Include(g => g.photos)
                            .Include(g => g.User)
                           .
                            FirstOrDefault();

                if (album != null)
                    {
                    ctx.Albums.Remove(album);
                    ctx.SaveChanges();
                    return true;
                    }
                }
            return false;
            }
        }
    }


        
    
