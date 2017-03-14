using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Security.Claims;
using System.Web;

namespace WebAppen.Utilities
    {
    public static class Helpers
        {
      
       

        



        public static bool IsFilePhoto(string filename)
            {
            if (filename.EndsWith(".png") || filename.EndsWith(".PNG"))
                {
                return true;
                }

            if (filename.EndsWith(".jpg") || filename.EndsWith(".JPG"))
                {
                return true;
                }
            if (filename.EndsWith(".jpeg") || filename.EndsWith(".JPEG"))
                {
                return true;
                }

            return false;
            }
        }


    }