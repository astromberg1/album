using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataModels
    {
    public class PhotoDataModel
        {
        public PhotoDataModel()
            {
            this.Comments = new HashSet<CommentsDataModel>();
            }

        //[Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public Nullable<DateTime> Datecreated { get; set; }

        public Nullable<DateTime> Dateupdated { get; set; }

        public bool publik { get; set; }
        public string Name { get; set; }

        public string Path { get; set; }
         public string Description { get; set; }


        public int? UserID { get; set; }
        
        
        public int AlbumID { get; set; }

      
        [ForeignKey("UserID")]
        public virtual UserDataModel User { get; set; }

        [ForeignKey("AlbumID")]
        public virtual AlbumDataModel Album { get; set; }

        public virtual ICollection<CommentsDataModel> Comments { get; set; }






        }
    }
