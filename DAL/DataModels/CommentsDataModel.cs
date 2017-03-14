using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataModels
    {
    public class CommentsDataModel
        {
        //[Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Comment { get; set; }

        public string Title { get; set; }
        public Nullable<DateTime> Datecreated { get; set; }

        public Nullable<DateTime> Dateupdated { get; set; }

        
        public int? UserID { get; set; }

        public int PhotoID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserDataModel User { get; set; }

        [ForeignKey("PhotoID")]
        public virtual PhotoDataModel Photo { get; set; }
        
        

        }
    }
