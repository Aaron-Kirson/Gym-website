using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ProjectCIS.Models
{
    public class productCommunicate
    {

      
        public int Id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int stock { get; set; }


        private static string URL = "http://localhost:51599/api/product/";

        public static List<product> Getproduct()
        {
             var request = HttpWebRequest.Create(String.Format(URL + "getProducts/"));// "/save" or "/update"
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "GET";

            try
            {
               
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return new List<product>();
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<List<product>>(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<product>();
            }
        }

        public static bool getStock(int productid, int amount)
        {


            var request = HttpWebRequest.Create(String.Format(URL + "stock?productid={0}&amount={1}", productid, amount));// "/save" or "/update"
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

        public static bool addProduct(string name, int price, string description, string image)
        {

            var request = HttpWebRequest.Create(String.Format(URL + "addProduct?name={0}&price={1}&description={2}&image={3}", name, price, description, image));// "/save" or "/update"
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

        public static int Getbyname(string name)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "getproduct?name={0}", name));
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "GET";

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if ((response).StatusCode != HttpStatusCode.OK)
                    {
                        return -1;
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<product>(reader.ReadToEnd()).Id;
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static product GetbyID(int Id)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "id?Id={0}", Id));
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
                        return JsonConvert.DeserializeObject<product>(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<productCommunicate> ReviewShake(int name)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "ReviewShake?product", name));// "/save" or "/update"
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
                        return new List<productCommunicate>();
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<List<productCommunicate>>(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<productCommunicate>();
            }
        }
    }
}