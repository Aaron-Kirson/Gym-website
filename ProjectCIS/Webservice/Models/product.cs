using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.Models
{
    public class product
    {

        public int Id;
        public string name;
        public int? price;
        public string description;
        public string image;
        private List<Product> list;
        public int? stock;

        public product() { }

        public product(Product p)
        {
            Id = p.Id;
            name = p.name;
            price = p.price;
            description = p.Description;
            image = p.image;
            stock = p.stock;

        }

        public static IEnumerable<Product> getProduct()
        {
            using (DBDataContext cdb = new DBDataContext())
            {
                List<Product> products = (from x in cdb.Products
                                          select x).ToList();
                return products;
            }
        }

        public product(List<Product> list)
        {
            this.list = list;
        }

        public static product getProductbyname(string name)
        {
            using (DBDataContext cdb = new DBDataContext())
            {
                return new product(cdb.Products.Single(x => x.name == name));
            }
        }
        
    }
}