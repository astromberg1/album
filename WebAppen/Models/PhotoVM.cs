using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppen.Models
    {
    public class PhotoVM
        {

        public int id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Max 140 characters, minimum 2", MinimumLength = 2)]
        public string Description { get; set; }
        public string Path { get; set; }
        public int? UserID { get; set; }
        [Display(Name = "Posted")]
        public DateTime? DatePosted { get; set; }
        [Display(Name = "Edited")]
        public DateTime? DateEdited { get; set; }
        [Required]
        [Display(Name = "Public")]
        public bool IsPublicPhoto { get; set; }
        public int AlbumID { get; set; }
        public string Uploader { get; set; }

        public UserVM User { get; set; }

        }
    }