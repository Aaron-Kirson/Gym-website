using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webservice.Models;

namespace Webservice.Controllers
{
    public class GoalController : ApiController
    {
        [System.Web.Http.Route("api/goal/getAd"), System.Web.Http.AcceptVerbs("GET")]
        public goal GetAd(string ad)
        {
            using (DBDataContext tdb = new DBDataContext())
            {
                return new goal(tdb.GymGoals.Single(x => x.goal == ad));
            }
        }

    }
}
