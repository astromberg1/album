using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppen.Models
    {
    public class CommentsVM
        {

        public int id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minst 3, Max 50 tecken")]
        [Display(Name = "Titel")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "Max 100 tecken!")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Kommentar")]
        public string Comment { get; set; }
        public int? UserID { get; set; }
        public int PhotoID { get; set; }

        [Display(Name = "Skickad")]
        public DateTime? DatePosted { get; set; }
        [Display(Name = "Ändrad")]
        public DateTime? DateEdited { get; set; }

        public PhotoVM Picture { get; set; }
        public UserVM User { get; set; }

        }
    }
