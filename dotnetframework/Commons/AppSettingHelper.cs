using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetframework.Commons
{
    public class AppSettingHelper
    {
        private static IConfiguration Configuration { get; set; }

        static AppSettingHelper()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                           .Add(new JsonConfigurationSource
                           {
                               Path = "appsettings.json",
                               ReloadOnChange = true,
                               OnLoadException = (FileLoadExceptionContext context) =>
                               {
                                   Console.WriteLine("配置文件异常，" + context.Exception.Message.ToString());
                               }
                           })
                           .Build();
        }

        public static string GetValue(string key)
        {
            return Configuration[key];
        }
    }
}
