using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webservice.Models;

namespace Webservice.Controllers
{
    public class commentController : ApiController
    {
        [Route("api/comment/ReviewShake"), AcceptVerbs("POST")]
        public List<comment> ReviewShake([FromBody] int name)
        {
            return comment.ReviewShake(name);
        }

        [Route("api/comment/average"), AcceptVerbs("POST")]
        public double? GetAverage([FromBody] int product)
        {

            using (DBDataContext cdb = new DBDataContext())
            {



                  double? RatingAverage = cdb.commentTables.Where(r => r.fkProduct == product).Average(r => r.rating);
               
               // Submit the changes to the database.
                try
                {
                    if (RatingAverage == null)
                    {
                        return 0;
                    }
                    else 
                    return RatingAverage;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                    // Provide for exceptions.
                }
            }
        }

        [System.Web.Http.Route("api/comment/InsertGymReview"), System.Web.Http.AcceptVerbs("GET")]
        public bool InsertGymReview(int rating, string feedback, int user)
        {
            using (DBDataContext cdb = new DBDataContext())
            {



                // Create a new Order object.
                GymReview ct = new GymReview()
                {

                    rating = rating,
                    comment = feedback,
                    fkCustomer = user





                };
                // Add the new object to the Orders collection.
                cdb.GymReviews.InsertOnSubmit(ct);

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

        [System.Web.Http.Route("api/comment/insertReview"), System.Web.Http.AcceptVerbs("GET")]
        public bool insertReview(string comment, int review, string username, int fkProduct)
        {
            using (DBDataContext cdb = new DBDataContext())
            {



                // Create a new Order object.
                commentTable ct = new commentTable()
                {
                    CName = username,
                    rating = review,
                    CText = comment,
                    fkProduct = fkProduct

                };
                // Add the new object to the Orders collection.
                cdb.commentTables.InsertOnSubmit(ct);

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

