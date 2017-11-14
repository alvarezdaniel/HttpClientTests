using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Self;
using Nancy.ViewEngines.SuperSimpleViewEngine;

namespace HttpServer
{
    class Program
    {
        private string _url = "http://localhost";
        private int _port = 12345;
        private NancyHost _nancy;

        public Program()
        {
            var uri = new Uri($"{_url}:{_port}/");

            var configuration = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

            _nancy = new NancyHost(configuration, uri);
        }

        private void Start()
        {
            _nancy.Start();
            Console.WriteLine($"Started listennig port {_port}");
            Console.ReadKey();
            _nancy.Stop();
        }

        static void Main(string[] args)
        {
            var p = new Program();
            p.Start();
        }
    }
}
