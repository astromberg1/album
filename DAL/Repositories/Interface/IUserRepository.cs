using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModels;

namespace DAL.Repositories.Interface
    {
    interface IUserRepository
        {
        IEnumerable<UserDataModel> All();

        UserDataModel ByID(int id);

        int GetID(string email);

        

        bool AddOrUpdate(UserDataModel user);

        bool Delete(int id);

      

       

        }
    }
