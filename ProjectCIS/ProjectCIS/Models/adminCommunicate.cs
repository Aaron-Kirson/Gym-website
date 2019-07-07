using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace ProjectCIS.Models
{
    public class adminCommunicate
    {

        private static string URL = "http://localhost:51599/api/admin/";


        public static async Task<admin> login(string username, string password)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "login?username={0}&password={1}", username, password));
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "GET";

            try
            {
                using (HttpWebResponse response = await request.GetResponseAsync().ConfigureAwait(false) as HttpWebResponse)
                {
                    if ((response).StatusCode != HttpStatusCode.OK)
                    {
                        return null;
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<admin>(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
        

        public static bool register(string username, string password)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "register?username={0}&password={1}", username, password));// "/save" or "/update"
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
    }
}