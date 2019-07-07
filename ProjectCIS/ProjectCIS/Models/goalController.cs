using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectCIS.Models
{
    public class goalController : ApiController
    {
        private static string URL = "http://localhost:51599/api/goal/";

        public static goal getAD(string ad)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "getAD?ad={0}", ad));// "/save" or "/update"
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "GET";

            try
            {

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return null;
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<goal>(reader.ReadToEnd());

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
