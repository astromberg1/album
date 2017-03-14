using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModels;


namespace DAL.Repositories.Interface
    {
    public interface IPhotoRepository
        {
        IEnumerable<PhotoDataModel> All();

        PhotoDataModel ByID(int id);

        bool AddOrUpdate(PhotoDataModel photo);

        bool Delete(int id);

        }
    }
