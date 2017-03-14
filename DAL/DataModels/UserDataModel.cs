using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataModels
    {
    public class UserDataModel
        {
        public UserDataModel()
            {
            this.Comments = new HashSet<CommentsDataModel>();
            this.Photos = new HashSet<PhotoDataModel>();
            this.Albums = new HashSet<AlbumDataModel>();
            }
        //[Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public Guid Idguid { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string email { get; set; }



        public virtual ICollection<PhotoDataModel> Photos { get; set; }

        public virtual ICollection<CommentsDataModel> Comments { get; set; }
        public virtual ICollection<AlbumDataModel> Albums { get; set; }

       




        }
    }
//            context.Users.Add(
//  new DataModels.UserDataModel { ID=1,FirstName="Kalle",LastName="Svensson", email = "test@test.com" }
//);