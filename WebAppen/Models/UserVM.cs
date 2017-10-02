using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebAppen.Models
    {
    public class UserVM
        {

        public int id{ get; set; }

        public Guid Idguid { get; set; }

            [Display(Name = "Förnamn")]
        public string FirstName { get; set; }


        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
            [Display(Name = "Epost adress")]
        public string Email { get; set; }

            [Display(Name = "Användar typ")]
        public string Role { get; set; }

        [Display(Name = "Namn")]
        public string FullName { get { return FirstName + " " + LastName; } }


        




        }
    }