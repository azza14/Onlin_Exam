using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Online_Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Authorization
{
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustmeAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> __roles;
        public CustmeAuthorizeAttribute(params Role[] roles)
        {
            __roles = roles ?? new Role[] { };
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization IF used [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            //authorization
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
