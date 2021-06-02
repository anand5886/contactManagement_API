using HRMS.API.Configuration;
using HRMS.Business.Login;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using HRMS.Data;
using Microsoft.Extensions.Logging;

namespace HRMS.API
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
            /*Resolves the dependency*/
            IocContainerConfiguration ioc = new IocContainerConfiguration();
            ioc.ConfigureService(services);
            /*Configure the connections*/
            EntityFrameworkConfiguration entity = new EntityFrameworkConfiguration();
            entity.ConfigureConnecions(services, Configuration);
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("HRMSCorsPolicy",
                builder => builder
                   .SetIsOriginAllowedToAllowWildcardSubdomains()
                   .WithOrigins("https://andupandu.com")
                   .AllowAnyMethod()
                   .AllowCredentials()
                   .AllowAnyHeader()
                   .Build()
                    );
            });

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/hrms_api_{Date}.txt");

            app.UseMyMiddleware();

            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors("HRMSCorsPolicy");
            app.UseCors(x => x
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .SetIsOriginAllowed(origin => true) // allow any origin
                 .AllowCredentials()); // allow credentials

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseWelcomePage();

        }
    }
}
