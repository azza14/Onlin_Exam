using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Online_Exam.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Exam.CutomAuthorize
{
    public  static class CustomAuthentication
    {
       // public static IServiceCollection DI { get;   set; }

        public static  void AddCustomAuthentication( IServiceCollection services, IConfiguration Configuration)
        {
            //var configuration = DI.BuildServiceProvider().GetService<IConfiguration>();

            var appSettingSection = Configuration.GetSection("AppSettings");
            var appSetting = appSettingSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSetting.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(x =>
               {
                   x.SaveToken = true;
                   x.RequireHttpsMetadata = false;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ClockSkew = TimeSpan.FromMinutes(30),
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });
        }
    }
}
