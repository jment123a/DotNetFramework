using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnetframework.Attributes;
using dotnetframework.Middlewares;
using dotnetframework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace dotnetframework.Filters
{
    public class AuthAsyncActionFilter : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //检查方法是否有AnyAuth标记
            bool AnyAuth = false;
            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                AnyAuth = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                    .Any(a => a.GetType().Equals(typeof(AnyAuthAttribute)));
            }
            if (AnyAuth) return;

            string id = HttpContextMiddleware.HttpContext.User.FindFirstValue("id");
            string name = HttpContextMiddleware.HttpContext.User.FindFirstValue("name");

            Console.WriteLine(id);
            Console.WriteLine(name);
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                context.Result = Json(new ResponseModel("登陆状态失效，请重新登录"));
            }
            base.OnActionExecuted(context);
        }
    }
}