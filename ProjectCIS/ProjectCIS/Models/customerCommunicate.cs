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
    public class customerCommunicate
    {
        private static string URL = "http://localhost:51599/api/customer/";


        public static async Task<customer> login(string username, string password)
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
                        return JsonConvert.DeserializeObject<customer>(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       

        public static customer getID(string name)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "getId?name={0}", name));
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
                        return JsonConvert.DeserializeObject<customer>(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

      

        public static bool forgot(string username, string password)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "forgot?username={0}&password={1}", username, password));// "/save" or "/update"
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

        public static bool register(string address, string firstName, string surname, string email,  string username, string password, string name, string card, int month, int year, string level, string goal, string training, string postal, string gender)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "register?firstname={0}&surname={1}&email={2}&username={3}&password={4}&name={5}&card={6}&month={7}&year={8}&level={9}&goal={10}&training={11}&address={12}&postal={13}&gender={14}", firstName, surname, email, username, password, name, card, month, year, level, goal, training, address, postal, gender));// "/save" or "/update"
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