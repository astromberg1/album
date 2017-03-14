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
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum 3, Maximum 50 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(140, ErrorMessage = "Max 140 Characters!")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        public int? UserID { get; set; }
        public int PhotoID { get; set; }

        [Display(Name = "Posted")]
        public DateTime? DatePosted { get; set; }
        [Display(Name = "Edited")]
        public DateTime? DateEdited { get; set; }

        public PhotoVM Picture { get; set; }
        public UserVM User { get; set; }

        }
    }
