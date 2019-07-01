using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PhantasyApi.Models;
using PhantasyApi.Utility;


namespace PhantasyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Uploader upload = new Uploader();
            ComboList comboList = upload.parseCsvAndMap(@"E:\Users\afbooza\Desktop\songlist\uploadTest.xlsx");

            CreateWebHostBuilder(args).Build().Run();

            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
