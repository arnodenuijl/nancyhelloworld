using System;
using Nancy;
using Nancy.Hosting.Self;

namespace NancyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:1234");
            var config = new HostConfiguration {RewriteLocalhost = true};

            using (var host = new NancyHost(config, uri))
            {
                host.Start();
            }
        }
    }

    public class HomeModule : NancyModule
    {
        public HomeModule() : base("/")
        {
            Get["/"]  = o =>
            {
                Console.WriteLine(Request.Url);
                return "Hello world!";
            };
        }
    }    
}
