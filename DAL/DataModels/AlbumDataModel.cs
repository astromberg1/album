using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataModels
    {
    public class AlbumDataModel
        {
        public AlbumDataModel()
            {

            photos = new HashSet<PhotoDataModel>();

          


            }

        //[Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual UserDataModel User { get; set; }


        public virtual ICollection<PhotoDataModel> photos { get; set; }

     

        

        }

    }
    
