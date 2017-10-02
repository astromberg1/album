using System.Security.Cryptography.X509Certificates;
using DAL.DataModels;
using WebAppen.Models;
using DAL.Repositories;

namespace WebAppen.Utilities
    {
    
    public static class ModelMapper
        {

        private static UserRepository repouser = new UserRepository();
        private static PhotoRepository repophoto = new PhotoRepository();
        private static AlbumRepository repoalbum = new AlbumRepository();
        private static CommentRepository repocomment = new CommentRepository();

        #region Users

        public static UserDataModel ModelToEntity(UserVM model)
            {
            UserDataModel user = new UserDataModel();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            user.email = model.Email;

            user.ID = model.id;

            user.Idguid = model.Idguid;
            return user;

            }

        public static UserVM EntityToModel(UserDataModel entity)
            {
            UserVM model = new UserVM();
          
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            model.Email = entity.email;
           
            model.id = entity.ID;
            model.Idguid = entity.Idguid;

            return model;


            }
        #endregion

        #region Album
        public static AlbumDataModel ModelToEntity(AlbumVM model)
            {
            AlbumDataModel entity = new AlbumDataModel();
            entity.ID = model.id;
            entity.Name = model.Name;
            
            entity.DateCreated = model.DateCreated;
            entity.UserID = model.UserID;

            return entity;
            }

        public static AlbumVM EntityToModel(AlbumDataModel entity)
            {
            AlbumVM model = new AlbumVM();
            model.id = entity.ID;
            model.Name = entity.Name;
            model.DateCreated = entity.DateCreated;
            model.UserID = entity.UserID;
            model.NoOfPhotos = entity.photos.Count;
            model.User = EntityToModel(entity.User);

            return model;
            }
        #endregion

        #region Photo


        public static PhotoDataModel ModelToEntity(PhotoVM model)
            {
            PhotoDataModel entity = new PhotoDataModel();
            entity.Name = model.Name;
            entity.ID = model.id;
            entity.Path = model.Path;
            entity.UserID = model.UserID;
            entity.Description = model.Description;
            entity.Datecreated = model.DatePosted;
            entity.Dateupdated = model.DateEdited;
            entity.AlbumID = model.AlbumID;
            entity.publik = model.IsPublicPhoto;





            return entity;

            }

        public static PhotoVM EntityToModel(PhotoDataModel entity)
            {
            PhotoVM model = new PhotoVM();

            model.Name = entity.Name;
            model.id = entity.ID;
            model.Path = entity.Path;
            model.UserID = entity.UserID;
            model.Description = entity.Description;
            model.DatePosted = entity.Datecreated;
            model.DateEdited = entity.Dateupdated;
            model.AlbumID = entity.AlbumID;
            model.IsPublicPhoto = entity.publik;

            entity.User = repouser.ByID((int)entity.UserID);

            model.User = EntityToModel(entity.User);
            model.Uploader = entity.User.FirstName + " " + entity.User.LastName;

           

            return model;


            }

        #endregion

        #region Comment
        public static CommentsDataModel ModelToEntity(CommentsVM model)
            {
            CommentsDataModel entity = new CommentsDataModel();
            entity.Comment = model.Comment;
            entity.Title = model.Title;
            entity.ID = model.id;
            entity.PhotoID = model.PhotoID;
            entity.UserID = model.UserID;
            
            entity.Datecreated = model.DatePosted;
            entity.Dateupdated = model.DateEdited;

            return entity;
            }

        public static CommentsVM EntityToModel(CommentsDataModel entity)
            {
            CommentsVM model = new CommentsVM();
            model.Comment = entity.Comment;
            model.Title = entity.Title;
            model.id = entity.ID;
            model.PhotoID = entity.PhotoID;
            model.Picture = EntityToModel(entity.Photo);
            model.UserID = entity.UserID;
            model.User = EntityToModel(entity.User);
          
            model.DateEdited = entity.Dateupdated;
            model.DatePosted = entity.Datecreated;



            return model;
            }




        #endregion


        }



    }
    