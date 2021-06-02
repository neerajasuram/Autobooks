﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GroceryStoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {


            CreateWebHostBuilder(args).Build().Run();
            //ClientClass cs = new ClientClass();
            //cs.InvokeAPI();

        }

       

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
