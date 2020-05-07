using dotnetframework.Commons.SqlSugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetframework.Commons
{
    public class SqlSugarHelper
    {
        public static SqlSugarClient Instantiate()
        {
            var Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = AppSettingHelper.GetValue("MysqlConnectionString"),
                DbType = DbType.MySql,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return Db;
        }
    }
}
