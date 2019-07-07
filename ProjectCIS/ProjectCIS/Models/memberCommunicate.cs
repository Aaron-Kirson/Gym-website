using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ProjectCIS.Models
{
    public class memberCommunicate
    {

        public int Id { get; set; }
        public string membership { get; set; }
        public int price { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public bool active { get; set; }
        public int fkCustomer { get; set; }




        private static string URL = "http://localhost:51599/api/member/";

        public static bool addMembership(string membership, int price)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "addMembership?membership={0}&price={1}", membership, price));// "/save" or "/update"
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

        public static List<member> ShowMembership(int user)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "ShowMembership?user={0}", user));// "/save" or "/update"
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "GET";

            try
            {

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return new List<member>();
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<List<member>>(reader.ReadToEnd());

                    }
                }
            }
            catch (Exception ex)
            {
                return new List<member>();
            }

        }



        public static bool membershipPass(string membership, int price, string startTime, string endTime, bool active, int customer)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "membershipPass?membership={0}&price={1}&startTime={2}&endTime={3}&active={4}&customer={5}", membership, price, startTime, endTime, active, customer));// "/save" or "/update"
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