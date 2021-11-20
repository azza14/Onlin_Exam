using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Online_Exam.Entities;
using Online_Exam.Helpers;
using Online_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Authorization
{
    public class JwtMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly AppSettings _appSettings;
        public JwtMiddleware(RequestDelegate next,  IOptions< AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }
     
        public async Task Invoke (HttpContext context,IJwtUtils jwtUtils, IGenericRepository<User> _repoUser)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var userId = jwtUtils.ValidateToken(token);

                if (userId != null)
                {
                    context.Items["User"] = _repoUser.GetById(userId.Value);
                }
                await _next(context);
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
        }
    
    }
}
