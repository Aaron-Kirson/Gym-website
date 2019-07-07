using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCIS.Models
{
    public class product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int stock { get; set; }



        public static int GetproductID(string name)
        {
            return productCommunicate.Getbyname(name);
        }

        public static bool Getstock(int productid, int amount)
        {
            return productCommunicate.getStock(productid, amount);
        }

        public static bool addProduct(string name, int price, string description, string image)
        {
            return productCommunicate.addProduct(name, price, description, image);
        }

 

        public static List<product> Getproduct()
        {
            return productCommunicate.Getproduct();
        }

        public static product GetProductByID(int Id)
        {
            return productCommunicate.GetbyID(Id);
        }
    }
}