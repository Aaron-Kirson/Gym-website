using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Webservice.Models;

namespace Webservice.Controllers
{
    public class adminController : ApiController
    {

        [System.Web.Http.Route("api/admin/login"), System.Web.Http.AcceptVerbs("GET")]
        public admin login(string username, string password)
        {
            using (DBDataContext tdb = new DBDataContext())
            {
                if (tdb.adminTables.Where(x => x.username == username).Count() == 1)
                {

                    if (tdb.adminTables.Where(x => x.username == username && x.password == password).Count() == 1)
                    {

                        return new admin(tdb.adminTables.Single(x => x.username == username && x.password == password));
                    }

                    else
                        return null;
                }
                else
                    return null;
            }
        }

        [System.Web.Http.Route("api/admin/register"), System.Web.Http.AcceptVerbs("GET")]
        public bool Register(string username, string password)
        {
            using (DBDataContext cdb = new DBDataContext())
            {

                if (cdb.adminTables.Where(x => x.username == username).Count() == 1)
                {
                    return false;
                }
                else
                {
                    // Create a new Order object.
                    adminTable ct = new adminTable()
                    {
                       
                        username = username,
                        password = password
               
                    };


                    // Add the new object to the Orders collection.
                    cdb.adminTables.InsertOnSubmit(ct);
                }
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

        
        }

    }

