using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Online_Exam.Authorization;
using Online_Exam.CustomAuth;
using Online_Exam.DBContext;
using Online_Exam.Entities;
using Online_Exam.Extensions;
using Online_Exam.Helpers;
using Online_Exam.Repositories;
using Online_Exam.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Online_Exam
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddControllers();
            services.AddDbContext<OnlineDbContext>(options =>
                                    options.UseSqlServer(
                                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors();
            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IExamRepository, ExamRepository>();

            // Auto Mapper Configurations
            var mapperConfig = new AutoMapper.MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // config swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnLine_Exam", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                //c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme()
                //{
                //     Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer",
                //    BearerFormat = "JWT",
                //    In = ParameterLocation.Header,
                //    Description = "JWT Authorization header using the Bearer scheme."

                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference= new OpenApiReference
                //            {
                //                Type=ReferenceType.Schema,
                //                Id="bearer"
                //            }
                //        }, new List<string>()
                //    }
                //});
            });

        //    CustomAuthentication.AddCustomAuthentication(services,Configuration);


            #region Localizations
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddLocalization(
                options=>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-Us"),
                        new CultureInfo("ar-AU")

                    };
                    
                 //   options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                 //   options.SupportedCultures = supportedCultures;
                 //   options.SupportedUICultures = supportedCultures;
                 //   options.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider { IndexOfCulture = 1, IndexofUICulture = 1 } };

                } );
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("culture", typeof(LanguageRouteConstraint));
            });
            #endregion
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExampRouting v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

           app.UseAuthorization();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{culture:culture}/{api}/{controller=''}/{action=''}/{id?}");

            });

            // use localization
            var localizeOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizeOptions.Value);




        }
    }
}
