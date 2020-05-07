using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetframework.Entities.Table
{
    public class User
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)] //是主键, 还是标识列
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }
    }
}
