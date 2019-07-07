using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webservice.Models;

namespace Webservice.Controllers
{
    public class productController : ApiController
    {

        [Route("api/product/stock"), System.Web.Http.AcceptVerbs("GET")]
        public bool stock(int productid, int amount)
        {
            using (DBDataContext cdb = new DBDataContext())
            {
                var query = from Product in cdb.Products
                            where Product.Id == productid
                            select Product;
                foreach (Product Product in query)
                {
                    Product.stock -= amount;
                }

                try
                {
                    cdb.SubmitChanges();
                    return true;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;

                    // Provide for exceptions.
                }
            }
        }
        [Route("api/product/getProducts"), System.Web.Http.AcceptVerbs("GET")]
        public IEnumerable<Product> Getproduct()
        {
            return product.getProduct();
        }


        [Route("api/product/addProduct"), System.Web.Http.AcceptVerbs("GET")]
        public bool Register(string name, int price, string description, string image)
        {
            using (DBDataContext cdb = new DBDataContext())
            {


                // Create a new Order object.
                Product ct = new Product()
                {
                    name = name,
                    price = price,
                    Description = description,
                    image = image


                };


                // Add the new object to the Orders collection.
                cdb.Products.InsertOnSubmit(ct);

                // Submit the change to the database.
                try
                {
                    cdb.SubmitChanges();
                    return true;

                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                    // Make some adjustments.
                    // ...
                    // Try again.


                }
            }
        }

      

        [System.Web.Http.Route("api/products"), System.Web.Http.AcceptVerbs("GET")]
        public product GetProductbyname(string name)
        {
            using (DBDataContext tdb = new DBDataContext())
            {
                try
                {
                    return new product(tdb.Products.Single(Product => Product.name == name));
                }
                catch (Exception ex) { return null; }
            }
        }

        [System.Web.Http.Route("api/product/Id"), System.Web.Http.AcceptVerbs("GET")]
        public product GetProductbyID(int Id)
        {
            using (DBDataContext tdb = new DBDataContext())
            {
                try
                {
                    return new product(tdb.Products.Single(product => product.Id == Id));
                }
                catch (Exception ex) { return null; }
            }
        }
    }
}
