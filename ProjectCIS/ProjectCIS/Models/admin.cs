using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCIS.Models
{
    public class admin
    {

        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }


        public static admin login(string username, string password)
        {
            return adminCommunicate.login(username, password).Result;
        }

        public static bool register(string username, string password)
        {
            return adminCommunicate.register(username, password);
        }

       
    }
}