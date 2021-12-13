using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Heartbeat.Models;

namespace Heartbeat
{
    public class HttpClientHelper
    {
        public static void Main()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://sales.stark.dk/api/v1/order?size=5&sort=createDateTime%2Cdesc");
                //HTTP GET
                var responseTask = client.GetAsync("order");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    //var readTask = result.Content.ReadAsAsync<Order[]>();
                    readTask.Wait();

                    var orders = readTask.Result;

                    foreach (var order in orders)
                    {
                        Console.WriteLine(order);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}