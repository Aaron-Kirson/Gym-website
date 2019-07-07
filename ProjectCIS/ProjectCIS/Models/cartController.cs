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
    public class cartController : ApiController
    {
        public int id { get; set; }
        public int amount { get; set; }
        public int customerId { get; set; }
        public string purchased { get; set; }
        public bool incart { get; set; }
        public int productId { get; set; }
        public int discount { get; set; }

        private static string URL = "http://localhost:51599/api/cart/";


        internal static bool addcart(int amount, int customerId, int productId, bool incart, string purchased,int discount)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "add?amount={0}&customerId={1}&productId={2}&incart={3}&purchased={4}&discount={5}", amount, customerId, productId, incart, purchased, discount));// "/save" or "/update"
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

        public static Cart GetReceipt(int customer)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "GetReceipt?customer={0}", customer));// "/save" or "/update"
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
                        return JsonConvert.DeserializeObject<Cart>(reader.ReadToEnd());

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool addDiscount(int amount, int customer)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "addDiscount?amount={0}&customer={1}", amount, customer));// "/save" or "/update"
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

        public static List<Cart> MarkOrder(List<Cart> carts)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "MarkOrdersAsPaid?carts={0}", carts));// "/save" or "/update"
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "POST";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string JSONPost = JsonConvert.SerializeObject(carts, Formatting.None,
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
                        return new List<Cart>();
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<List<Cart>>(reader.ReadToEnd());
                    }
                }
                
            }
            catch
            {

                return new List<Cart>();
            }
        }

    

    public static void UpdateQuantity(int cartId, int quantity)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "UpdateQuantity?cartId={0}&quantity={1}", cartId, quantity));// "/save" or "/update"
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "GET";

            try
            {

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                       
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        JsonConvert.DeserializeObject<bool>(reader.ReadToEnd());

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRRRRRRRRRRRRRRRRRRRRRRRRRROOOOOOOOOOOOOOOOOOOOOORRRRRRRRRRRRRRRRR");
            }
        }

        public static bool DeleteCart(int cartId)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "DeleteCart?cartId={0}", cartId));// "/save" or "/update"
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

       
    


        public static List<Cart> getOrder(int customerId)
        {
            var request = HttpWebRequest.Create(String.Format(URL + "getOrder?customerId={0}", customerId));// "/save" or "/update"
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "POST";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string JSONPost = JsonConvert.SerializeObject(customerId, Formatting.None,
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
                        return new List<Cart>();
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<List<Cart>>(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<Cart>();
            }
        }
    
    }
}
    

