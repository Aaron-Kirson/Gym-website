using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webservice.Models;

namespace Webservice.Controllers
{
    public class memberController : ApiController
    {


        [System.Web.Http.Route("api/member/ShowMembership"), System.Web.Http.AcceptVerbs("GET")]
        public List<customerMembership> ShowMembership(int user)
        {
           

            DBDataContext tdb = new DBDataContext();
            {
                List<customerMembership> aqa = tdb.customerMemberships.Where(x => x.fkCustomer == user && x.active == true).ToList();
                return aqa;
            }
        }


        [System.Web.Http.Route("api/member/addMembership"), System.Web.Http.AcceptVerbs("GET")]
        public bool membershipPass(string membership, int price)
        {
            using (DBDataContext tdb = new DBDataContext())
            {

                membershipTable cm = new membershipTable()
                {

                    name = membership,
                    Price = price


                };

                tdb.membershipTables.InsertOnSubmit(cm);


                try
                {
                    tdb.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }


            }
        }

        [System.Web.Http.Route("api/member/membershipPass"), System.Web.Http.AcceptVerbs("GET")]
        public bool membershipPass(string membership, int price, string startTime, string endTime, bool active, int customer)
        {
            using (DBDataContext tdb = new DBDataContext())
            {

                if (tdb.customerMemberships.Where(x => x.fkCustomer == customer).Count() == 1)
                {
                    return false;
                }
                else
                {


                    customerMembership cm = new customerMembership()
                    {


                        startTime = startTime,
                        endTime = endTime,
                        active = active,
                        membership = membership,
                        fkCustomer = customer,
                        price = price


                    };

                    tdb.customerMemberships.InsertOnSubmit(cm);

                }
                try
                {
                    tdb.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

               


            }
        }
    }
}
    
