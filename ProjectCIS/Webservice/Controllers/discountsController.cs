using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webservice.Models;

namespace Webservice.Controllers
{
    public class discountsController : ApiController
    {


        [System.Web.Http.Route("api/discount/register"), System.Web.Http.AcceptVerbs("GET")]
        public bool register(int amount, string code, bool active)
        {
            using (DBDataContext tdb = new DBDataContext())
            {
                // Create a new Order object.
                discountTable ct = new discountTable()
                {
                    amount = amount,
                    code = code,
                    active = active




                };


                // Add the new object to the Orders collection.
                tdb.discountTables.InsertOnSubmit(ct);

                // Submit the changes to the database.
                try
                {
                    tdb.SubmitChanges();
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

        [System.Web.Http.Route("api/discount/getcode"), System.Web.Http.AcceptVerbs("GET")]
        public discount apply(string code, bool active)
        {
            using (DBDataContext tdb = new DBDataContext())
            {



                if (tdb.discountTables.Where(x => x.code == code && x.active == active).Count() == 1)
                {

                    var query = from discount in tdb.discountTables
                                where discount.code == code
                                select discount;
                    foreach (discountTable discount in query)
                    {
                        discount.active = false;
                    }

                    try
                    {
                        tdb.SubmitChanges();
                        return new discount(tdb.discountTables.Single(x => x.code == code));

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        return null;

                        // Provide for exceptions.
                    }
                }
                else { return null; }


               
              
            } }
                

               

            }
    }



        

