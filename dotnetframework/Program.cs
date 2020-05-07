using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using dotnetframework.Commons;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace dotnetframework
{
    public class Program
    {


        public static void Main(string[] args)
        {
            string _ProjectName = "dotnetframework";
            string _TablePath = "dotnetframework.Entities.Table";

            //Code First
            Assembly assembly = Assembly.Load(_ProjectName);
            SqlSugarClient Db = SqlSugarHelper.Instantiate();
            Db.CodeFirst.BackupTable().InitTables(assembly.GetTypes().Where(i => i.Namespace == _TablePath).Where(i => i.IsClass).ToArray());

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
