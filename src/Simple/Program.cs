﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ProxyKit.Recipe.Simple
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var upstreamHost = WebHost.CreateDefaultBuilder(args)
                .UseStartup<UpstreamHostStartup>()
                .UseUrls("http://localhost:5002")
                .Build();

            var proxyHost = WebHost.CreateDefaultBuilder(args)
                .UseStartup<ProxyStartup>()
                .UseUrls("http://localhost:5003")
                .Build();

            await upstreamHost.StartAsync();

            proxyHost.Run();
        }
    }
}