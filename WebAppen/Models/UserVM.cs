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

        public string FirstName { get; set; }
        
       

        public string LastName { get; set; }
        public string Email { get; set; }
     
        [Display(Name = "Name")]
        public string FullName { get { return FirstName + " " + LastName; } }


        




        }
    }