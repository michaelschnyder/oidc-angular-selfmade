using System;
using Microsoft.Owin.Hosting;

namespace WebApiServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "WebApiServerApp";

            const string url = "http://api.amazing.ctd:80";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("\n\nServer listening at {0}. Press enter to stop", url);
                Console.ReadLine();
            }
        }
    }
}
