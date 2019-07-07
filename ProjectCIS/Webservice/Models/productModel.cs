using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.Models
{
    public class productModel
    {
        public int Id;
        public string name;
        public int? price;
        public string description;
        public string image;

        public productModel() { }
        public productModel(int pid) { Id = pid; }
        public productModel(Product p)
        {
            Id = p.Id;
            name = p.name;
            price = p.price;
            description = p.Description;
            image = p.image;

        }

     
       

    }
}