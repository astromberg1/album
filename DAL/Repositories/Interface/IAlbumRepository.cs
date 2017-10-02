using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModels;


namespace DAL.Repositories.Interface
    {
    public interface IAlbumRepository
        {

        IEnumerable<AlbumDataModel> All();

        AlbumDataModel ByID(int id);

            int GetNewIndex();

        bool AddOrUpdate(AlbumDataModel album);

        bool Delete(int id);
        }
    }
