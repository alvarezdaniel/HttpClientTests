using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientTests
{
    public static class Test1
    {
        // http://www.nimaara.com/2016/11/01/beware-of-the-net-httpclient/
        public static void Run1()
        {
            var endpoint = new Uri("http://localhost:12345");
            for (var i = 0; i < 10; i++)
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetStringAsync(endpoint).Result;
                    Console.WriteLine(response);
                }
            }
        }

        public static void Run2()
        {
            var ep = ServicePointManager.FindServicePoint(new Uri("http://localhost:12345"));
            ep.ConnectionLeaseTimeout = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;

            var endpoint = new Uri("http://localhost:12345");
            for (var i = 0; i < 10; i++)
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetStringAsync(endpoint).Result;
                    Console.WriteLine(response);
                }
            }
        }

        private static readonly HttpClient Client = new HttpClient();

        public static void Run3()
        {
            var endpoint = new Uri("http://localhost:12345");
            for (var i = 0; i < 10; i++)
            {
                var response = Client.GetStringAsync(endpoint).Result;
                Console.WriteLine(response);
            }
        }

        public static void Run4()
        {
            var endpoint = new Uri("http://localhost:12345");
            for (var i = 0; i < 10; i++)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.ConnectionClose = true;

                var response = client.GetStringAsync(endpoint).Result;
                Console.WriteLine(response);
            }
        }
    }
}
