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
    public class UserRepository:IUserRepository
        {
        public bool AddOrUpdate(UserDataModel user)
            {
            try
                {
                using (var ctx = new MVCContext())
                    {
                    var userToUpdate = ctx.Users.Where(u => u.ID == user.ID)
                        .Include(u => u.Albums)
                        .Include(u => u.Comments)
                        .Include(u => u.Photos)
                        .FirstOrDefault();

                    if (userToUpdate != null)
                        {
                        userToUpdate.FirstName = user.FirstName;
                        userToUpdate.LastName = user.LastName;

                        userToUpdate.email = user.email;

                        userToUpdate.Idguid = user.Idguid;


                        ctx.SaveChanges();
                        return true;
                        }
                    else
                        {
                        var newUser = new UserDataModel();
                        newUser.FirstName = user.FirstName;
                        newUser.LastName = user.LastName;

                        newUser.email = user.email;
                        newUser.Idguid = user.Idguid;

                        ctx.Users.Add(newUser);
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

        public IEnumerable<UserDataModel> All()
            {
            using (var ctx = new MVCContext())
                {
                var users = ctx.Users
                        .Include(u => u.Albums)
                        .Include(u => u.Comments)
                        .Include(u => u.Photos);

                return users.ToList();
                }
            }

            public int GetNewIndex()
            {
                using (var ctx = new MVCContext())
                {
                    var users = ctx.Users
                        .Include(u => u.Albums)
                        .Include(u => u.Comments)
                        .Include(u => u.Photos);

                var res = users.OrderBy(x => x.ID).LastOrDefault();

                    if (res == null)
                        return 1;
                    else
                        return res.ID + 1;

                }
            }

        public int GetID(string email)
            {
            using (var ctx = new MVCContext())
                {
                var user = ctx.Users.Where(u => u.email == email).FirstOrDefault();

                return user.ID;
                }



            }

        public UserDataModel ByID(int id)
            {
            using (var ctx = new MVCContext())
                {
                var user = ctx.Users.Where(u => u.ID == id)
                        .Include(u => u.Albums)
                        .Include(u => u.Comments)
                        .Include(u => u.Photos)
                        .FirstOrDefault();
                return user;
                }
            }

        public bool Delete(int id)
            {
            using (var ctx = new MVCContext())
                {
                var user = ctx.Users.Where(u => u.ID == id)
                        .Include(u => u.Albums)
                        .Include(u => u.Comments)
                        .Include(u => u.Photos)
                        .FirstOrDefault();

                if (user != null)
                    {
                    //ta bort allt relaterat till user
                    ctx.Photos.RemoveRange(user.Photos);
                    ctx.Comments.RemoveRange(user.Comments);
                    ctx.Albums.RemoveRange(user.Albums);

                    ctx.Users.Remove(user);
                    ctx.SaveChanges();
                    return true;
                    }
                }
            return false;
            }

        
        




    }
    }
