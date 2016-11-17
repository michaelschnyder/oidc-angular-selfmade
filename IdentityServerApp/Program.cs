using System;

using Microsoft.Owin.Hosting;
using Serilog;

namespace IdentityServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IdentityServerApp";

            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .LiterateConsole(outputTemplate: "{Timestamp:HH:MM} [{Level}] ({Name:l}){NewLine} {Message}{NewLine}{Exception}")
                .CreateLogger();

            const string url = "http://identity.amazing.ctd:80";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("\n\nServer listening at {0}. Press enter to stop", url);
                Console.ReadLine();
            }
        }
    }
}
