using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Online_Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Online_Exam.Authorization
{
   // [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> __roles;
        public CustomAuthorizeAttribute(params Role[] roles)
        {
            __roles = roles ?? new Role[] { };
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];

            if (user == null || (__roles.Any() && !__roles.Contains(user.Role)))
            {
                // not logged in or role not authorized
                context.Result = new JsonResult(new
                {
                    message = "Unauthorized",
                    StatusCode = StatusCodes.Status401Unauthorized
                });
            }
        }


      
    }
}
