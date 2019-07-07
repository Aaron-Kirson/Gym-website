using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.Models
{
    public class admin
    {
        public int Id;
        public string username;
        public string password;

        private List<adminTable> list;


        public admin() { }

        public admin(adminTable p)
        {
            Id = p.Id;          
            username = p.username;
            password = p.password;
           
        }

        public admin(List<adminTable> list)
        {
            this.list = list;
        }

        public adminTable ToadminTable()
        {
            adminTable ct = new adminTable()
            {
                Id = this.Id,
                username = this.username,
                password = this.password,
              


            };

            return ct;
        }

    }
}