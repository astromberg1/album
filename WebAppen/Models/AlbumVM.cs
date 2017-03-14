using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppen.Models
    {
    public class AlbumVM
        {
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter Album name.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Minimum 5, Maximum 50 Characters")]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        [Display(Name = "Created")]
        public DateTime DateCreated { get; set; }

        public int UserID { get; set; }

        public UserVM User { get; set; }


        }
    }