using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webservice.Models;


namespace Webservice.Controllers
{
    public class customerController : ApiController
    {

        [System.Web.Http.Route("api/customer/getId"), System.Web.Http.AcceptVerbs("GET")]
        public customer GetId(string name)
        {
            using (DBDataContext tdb = new DBDataContext())
            {
                try
                {
                    return new customer(tdb.customerTables.Single(customerTable => customerTable.username == name));
                }
                catch (Exception ex) { return null; }
            }
        }

       


        [System.Web.Http.Route("api/customer/login"), System.Web.Http.AcceptVerbs("GET")]
        public customer AuthenticatePlayer(string username, string password)
        {
            using (DBDataContext tdb = new DBDataContext())
            {
                if (tdb.customerTables.Where(x => x.username == username).Count() == 1)
                {

                    if (tdb.customerTables.Where(x => x.username == username && x.password == password).Count() == 1)
                    {
                        
                        return new customer(tdb.customerTables.Single(x => x.username == username && x.password == password));
                    }


                    else
                        return null;
                }
                else
                    return null;
            }
        }

        [System.Web.Http.Route("api/customer/register"), System.Web.Http.AcceptVerbs("GET")]
        public bool Register(string firstName, string surname, string email, string username, string password, string name, string card, int month, int year, string level, string goal, string training, string address, string postal, string gender)
        {
            using (DBDataContext cdb = new DBDataContext())
            {

                if (cdb.customerTables.Where(x => x.username == username).Count() == 1)
                {
                    return false;
                }
                else
                {
                    // Create a new Order object.
                    customerTable ct = new customerTable()
                    {
                        firstName = firstName,
                        surname = surname,
                        username = username,
                        password = password,
                        email = email,
                        name = name,
                        card = card,
                        month = month,
                        year = year,
                        exp = level,
                        goals = goal,
                        training = training,
                        address = address,
                        postal = postal,
                        gender  = gender


                        

                    };


                    // Add the new object to the Orders collection.
                    cdb.customerTables.InsertOnSubmit(ct);
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

        [System.Web.Http.Route("api/customer/forgot"), System.Web.Http.AcceptVerbs("GET")]
        public bool forgot(string username, string password)
        {
            using (DBDataContext tdb = new DBDataContext())
            {
                // Query the database for the row to be updated.

                var query = from customer in tdb.customerTables
                            where customer.username == username
                            select customer;

                foreach (customerTable customer in query)
                {
                    customer.password = password;
                }


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

        //[System.Web.Http.Route("api/customer/membershipRegister"), System.Web.Http.AcceptVerbs("GET")]
        //public bool membershipRegister(string name, string card, string month, string year, string cw)
        //{
        //    using (DBDataContext cdb = new DBDataContext())
        //    {

        //            // Create a new Order object.
        //            customerTable ct = new customerTable()
        //            {
        //                firstName = firstName,
        //                surname = surname,
        //                username = username,
        //                password = password,
        //                email = email


        //            };


        //            // Add the new object to the Orders collection.
        //            cdb.customerTables.InsertOnSubmit(ct);
        //        }
        //        // Submit the change to the database.
        //        try
        //        {
        //            cdb.SubmitChanges();
        //            return true;

        //        }

        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            return false;
        //            // Make some adjustments.
        //            // ...
        //            // Try again.


        //        }
        //    }

    }
    }
