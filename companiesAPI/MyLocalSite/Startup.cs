using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL;
using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace MyLocalSite
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
            var notificationMetadata =
     Configuration.GetSection("NotificationMetadata").
     Get<NotificationMetadata>();
            services.AddSingleton(notificationMetadata);
            services.AddCors();

            services.AddScoped(typeof(ICompanyBL), typeof(CompanyBL));
            services.AddScoped(typeof(ICompanyDL), typeof(CompanyDL));
            services.AddScoped(typeof(IMailSender), typeof(MailSender));

            services.AddControllers();//.AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<CompanyContext>(opt =>
              opt.UseInMemoryDatabase("CompanyList"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
           
            //  services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true) // allow any origin
              .AllowCredentials()); // allow credentials

            app.UseStaticFiles();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.Map("/api", app2 =>
            {
                app.UseErrorHandlingMiddleware();
                app2.UseRouting();
                app2.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers(); //This  maps controllers that are decorated with routing attributes
                });
            }
         );

            app.UseHttpsRedirection();
           

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
