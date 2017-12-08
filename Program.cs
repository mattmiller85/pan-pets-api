
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace pan_pets.api {
    public class Program {

        public static IWebHost Host { get; private set; }

        public static void Main (string[] args) {
            Host = BuildWebHost(args);
            Host.Run();
        }

        public static void StartAsync (string[] args) {
            Host = BuildWebHost(args);
            Host.RunAsync();
        }

        public static async void Stop() {
            await Host?.StopAsync();
        }

        public static IWebHost BuildWebHost (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ()
            .Build ();
    }
}