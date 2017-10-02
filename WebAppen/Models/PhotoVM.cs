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
        [StringLength(20, ErrorMessage = "Max 20 tecken")]
        [Display(Name = "Namn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Max 50 tecken, minst 2", MinimumLength = 2)]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        public string Path { get; set; }
        public int? UserID { get; set; }
        [Display(Name = "Skickad")]
        public DateTime? DatePosted { get; set; }
        [Display(Name = "Ändrad")]
        public DateTime? DateEdited { get; set; }
        [Required]
        [Display(Name = "Publik")]
        public bool IsPublicPhoto { get; set; }
        public int AlbumID { get; set; }
            [Display(Name = "Uppladdare")]
        public string Uploader { get; set; }

        public UserVM User { get; set; }

        }
    }