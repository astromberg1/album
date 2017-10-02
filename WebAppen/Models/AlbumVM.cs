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
        [Required(ErrorMessage = "Ange Album namn.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Min 5, Max 50 tecken")]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "Skapad")]
        public DateTime DateCreated { get; set; }

            [Display(Name = "Antal Foton")]
        public int NoOfPhotos { get; set; }

        public int UserID { get; set; }

        public UserVM User { get; set; }


        }
    }