using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using dotnetframework.Attributes;
using dotnetframework.Commons;
using dotnetframework.Entities.Table;
using dotnetframework.Filters;
using dotnetframework.Models;
using dotnetframework.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace dotnetframework.Controllers
{
    public class HomeController : AuthAsyncActionFilter
    {
        [HttpGet("CheckLogin")]
        [AnyAuth]
        public async Task<IActionResult> CheckLogin(string userName, string passWord)
        {
            UserService userService = new UserService();
            User user = await userService.CheckLogin(userName, passWord);
            if (user == null)
            {
                return Json(new ResponseModel("账号或密码错误"));
            }
            else
            {
                //生成并返回jwt
                //通过，给予令牌
                var claims = new ClaimsIdentity(new[]
                {
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.Name)
            });

                var tokenHandler = new JwtSecurityTokenHandler();
                //发放JWT令牌  保存数据到Session/Cache
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9a4b78f3ed1f4cccd1de82bb3a2111g1"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new SecurityTokenDescriptor
                {
                    Issuer = "https://localhost:88888", //签发服务器的名称
                    Audience = "web",//接受者
                    Subject = claims,
                    Expires = DateTime.Now.AddMinutes(30),
                    SigningCredentials = creds
                };
                var jwt_token = tokenHandler.WriteToken(tokenHandler.CreateToken(token));
                return Json(new ResponseModel(jwt_token));
            }
        }

    

    }
}