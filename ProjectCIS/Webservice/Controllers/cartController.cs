using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webservice.Models;


namespace Webservice.Controllers
{
    public class cartController : ApiController
    {

        [Route("api/cart/GetReceipt"), System.Web.Http.AcceptVerbs("GET")]
        public Cart GetReceipt(int customer)
        {

            using (DBDataContext tdb = new DBDataContext())
            {
                try
                {
                    return new Cart(tdb.cartTables.Single(x => x.customerId == customer && x.incart == true));
                }
                catch (Exception ex) { return null; }
            }



        }

        [Route("api/cart/add"), System.Web.Http.AcceptVerbs("GET")]
        public bool add(int amount, int customerId, int productId, bool incart, string purchased, int discount)
        {

            using (DBDataContext cdb = new DBDataContext())
            {


                // Create a new Order object.
                cartTable ct = new cartTable()
                {
                    amount = amount,
                    customerId = customerId,
                    incart = incart,
                    productId = productId,
                    purchased = purchased,
                    discount = discount
                   



                };


                // Add the new object to the Orders collection.
                cdb.cartTables.InsertOnSubmit(ct);

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

        [Route("api/cart/addDiscount"), System.Web.Http.AcceptVerbs("GET")]
        public bool addDiscount(int amount, int customer)
        {

            using (DBDataContext cdb = new DBDataContext())
            {

                var query = from Cart in cdb.cartTables
                            where Cart.customerId == customer
                            select Cart;
                foreach (cartTable cart in query)
                {
                    cart.discount = amount;
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

        [Route("api/cart/MarkOrdersAsPaid"), System.Web.Http.AcceptVerbs("POST")]
        public List<cartTable> MarkOrdersAsPaid(List<cartTable> carts)
        {
            using (DBDataContext cdb = new DBDataContext())
            {

                if (carts != null)
                {



                    foreach (cartTable cart in carts)
                    {
                        cartTable oldCart = cdb.cartTables.Single(x => x.Id == cart.Id);
                        oldCart.purchased = DateTime.Now.ToString();
                        oldCart.incart = false;
                    }

                    cdb.SubmitChanges();
                    return new List<cartTable>();
                }
                else
                    return new List<cartTable>();


            }



        }

        [Route("api/cart/UpdateQuantity"), System.Web.Http.AcceptVerbs("GET")]
        public void UpdateQuantity(int cartId, int quantity)
        {

            using (DBDataContext cdb = new DBDataContext())
            {

                var query = from Cart in cdb.cartTables
                            where Cart.Id == cartId
                            select Cart;
                foreach (cartTable Cart in query)
                {
                    Cart.amount = quantity;
                }
                // Submit the changes to the database.
                try
                {
                    cdb.SubmitChanges();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    // Provide for exceptions.
                }


            }
        }



        [Route("api/cart/getOrder"), System.Web.Http.AcceptVerbs("POST")]
        public List<cartTable> getOrder(int customerId)
        {
            using (DBDataContext cdb = new DBDataContext())
            {
                List<cartTable> orders = (from x in cdb.cartTables
                                          where x.customerId == customerId
                                          && x.incart
                                          orderby x.purchased descending
                                          select x).ToList();
                return orders;
            }
        }


        [Route("api/cart/DeleteCart"), System.Web.Http.AcceptVerbs("GET")]
        public bool DeleteCart(int cartId)
        {

            using (DBDataContext cdb = new DBDataContext())
            {



                var query = from Cart in cdb.cartTables
                            where Cart.Id == cartId
                            select Cart;
                foreach (cartTable Cart in query)
                {
                    cdb.cartTables.DeleteOnSubmit(Cart);
                }
                // Submit the changes to the database.
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



    }
}
