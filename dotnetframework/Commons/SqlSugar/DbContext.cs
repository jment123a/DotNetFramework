using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace dotnetframework.Commons.SqlSugar
{
    public class DbContext<T> where T : class, new()
    {
        public DbContext()
        {
            Db = SqlSugarHelper.Instantiate();
        }
        public SqlSugarClient Db;
        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }

    }
}
