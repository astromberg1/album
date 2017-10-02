using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModels;


namespace DAL.Repositories.Interface
    {
   public interface ICommentRepository
        {
          IEnumerable<CommentsDataModel> All();

          CommentsDataModel ByID(int id);

        bool AddOrUpdate(CommentsDataModel comment);

        bool Delete(int id);

            int GetNewIndex();

    }
    }
