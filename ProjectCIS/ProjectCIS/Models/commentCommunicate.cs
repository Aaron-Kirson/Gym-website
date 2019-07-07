using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ProjectCIS.Models
{
    public class commentCommunicate
    {

        public int id { get; set; }
        public string CText { get; set; }
        public int rating { get; set; }
        public int fkCustomer { get; set; }
        public int fkProduct { get; set; }
        public string CName { get; set; }



        private static string URL = "http://localhost:51599/api/comment/";

        public static bool insertReview(string comment, int review, string username, int fkProduct)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "insertReview?comment={0}&review={1}&username={2}&fkProduct={3}", comment, review, username, fkProduct));// "/save" or "/update"
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

        public static double? GetAverageComment(int product)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "average?product={0}", product));// "/save" or "/update"
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "POST";


            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string JSONPost = JsonConvert.SerializeObject(product, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                streamWriter.Write(JSONPost);
                streamWriter.Flush();
                streamWriter.Close();
            }
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new double();
                }
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return JsonConvert.DeserializeObject<double>(reader.ReadToEnd());
                }
            }
        }

        public static bool InsertGymReview(int rating, string feedback, int user)
        {

            var request = HttpWebRequest.Create(String.Format(URL + "InsertGymReview?rating={0}&feedback={1}&user={2}", rating, feedback, user));// "/save" or "/update"
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

        public static List<commentCommunicate> ReviewShake(int name )
        {
            var request = HttpWebRequest.Create(String.Format(URL + "ReviewShake?comment", name));// "/save" or "/update"
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "POST";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string JSONPost = JsonConvert.SerializeObject(name, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

                    streamWriter.Write(JSONPost);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return new List<commentCommunicate>();
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<List<commentCommunicate>>(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<commentCommunicate>();
            }
        }
    }
    }
