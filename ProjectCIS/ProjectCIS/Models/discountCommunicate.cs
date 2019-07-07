using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ProjectCIS.Models
{
    public class discountCommunicate
    {

        private static string URL = "http://localhost:51599/api/discount/";


        public static bool addDiscount(int amount, string code, bool active)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "register?amount={0}&code={1}&active={2}", amount, code, active));// "/save" or "/update"
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "GET";
            try
            {

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return false;
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<bool>(reader.ReadToEnd());

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static discount applyDiscount(string code, bool active)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "getcode?code={0}&active={1}", code, active));
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "GET";

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if ((response).StatusCode != HttpStatusCode.OK)
                    {
                        return null;
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<discount>(reader.ReadToEnd());
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