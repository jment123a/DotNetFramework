using dotnetframework.Commons.SqlSugar;
using dotnetframework.Entities.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetframework.Services
{
    public class UserService : DbContext<User>
    {
        public async Task<User> CheckLogin(string userName, string passWord)
        {
            return await CurrentDb.AsQueryable().SingleAsync(i => i.UserName == userName && i.PassWord == passWord);
        }
    }
}
