using HRMS.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HRMS.API.Configuration
{
    public class EntityFrameworkConfiguration
    {
        public void ConfigureConnecions(IServiceCollection services, IConfiguration configuration)
        {
            var ParenthrmsdbConnection = configuration.GetConnectionString("ParentEntities");
            services.AddDbContext<TENANT_MASTERContext>(options => options.UseSqlServer(ParenthrmsdbConnection));
            //services.AddDbContext<HRMSContext>();

            //DbContext dbContext = new DbContext((options) => {   });
            services.AddDbContext<HRMSContext>((serviceProvider, options) =>
            {
                var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                var connection = ParenthrmsdbConnection.ToString().Replace(";Database=TENANT_MASTER;", string.Format(";Database=HRMS_{0};", httpContext.Request.Headers["tenantId"].ToString()));

                options.UseSqlServer(connection);
            });
        }
        //private string ResolveDbContext(HttpContext context)
        //{
        //    try
        //    {
        //        string tenantID = context.Request.Host.Host.Split(".")[0] == "localhost" ? "DEV" : context.Request.Host.Host.Split(".")[0];
        //        //string tenantID = context.Request.Headers["tenantId"].ToString();
        //        string childConnection = string.Empty;
        //        TENANT_MASTERContext tenant = new TENANT_MASTERContext();
        //        var configDetails = tenant.TblClientConfig.Where(o => o.ClientKey.ToUpper() == tenantID).ToList();
        //        if (configDetails.Count > 0)
        //        {
        //            string servername = configDetails[0].ServerName + "," + configDetails[0].ServerPort;
        //            string databasename = configDetails[0].DatabaseName;
        //            string UserID = configDetails[0].UserId;
        //            string UserPassword = configDetails[0].UserPassword;
        //            childConnection = "Server=" + servername + ";Database=" + databasename + ";Integrated Security=False;User ID=" + UserID + "; Password=" + UserPassword;
        //        }
        //        return childConnection;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
            
        //}
    }
}
