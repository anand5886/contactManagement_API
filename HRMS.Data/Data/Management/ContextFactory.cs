using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using HRMS.API.Models;
using HRMS.API.Data.DataSeed;
using HRMS.API.Configuration.Settings;
using HRMS.Data.Models;

namespace HRMS.API.Data.Management
{
    public class ContextFactory : IContextFactory
    {
        private readonly HttpContext httpContext;
        //private readonly IDataSeeder dataSeeder;

        // private readonly ConnectionSettings connectionOptions;
        private readonly TENANT_MASTERContext _TENANTcontext;
        public ContextFactory(IHttpContextAccessor httpContentAccessor, TENANT_MASTERContext context)//IHttpContextAccessor httpContentAccessor, ConnectionSettings connectionOptions, 
        {
            this.httpContext = httpContentAccessor.HttpContext;
            //this.dataSeeder = dataSeeder;
            //this.connectionOptions = connectionOptions;
            _TENANTcontext = context;
        }

        public IDbContext DbContext => throw new NotImplementedException();

        private string TenantId
        {
            get
            {
                string host = this.httpContext.Request.Host.Host;
                host = host.Split(".", StringSplitOptions.None)[0] == "localhost" ? "DEV" : host.Split(".", StringSplitOptions.None)[0];
                string s = "http://oakridge.andupandu.com/welcome";
                string s2 = s.Split(".", StringSplitOptions.None)[0].ToUpper();
                return host.ToUpper();
            }
        }
        //public IDbContext DbContext => new HRMSContext(ChangeDatabaseNameInConnectionString(this.TenantId).Options, this.dataSeeder);
        //private DbContextOptionsBuilder<HRMSContext> ChangeDatabaseNameInConnectionString(string tenantId)
        //{
        //    //Create DbContextOptionsBuilder with new Database name
        //    var contextOptionsBuilder = new DbContextOptionsBuilder<HRMSContext>();
        //    //var configDetails = _TENANTcontext.TblClientConfig.Where(o => o.ClientKey.ToUpper() == tenantId).ToList();
        //    //if (configDetails.Count > 0)
        //    //{
        //    //    string servername = configDetails[0].ServerName + "," + configDetails[0].ServerPort;
        //    //    string databasename = configDetails[0].DatabaseName;
        //    //    string UserID = configDetails[0].UserId;
        //    //    string UserPassword = configDetails[0].UserPassword;

        //    //    string childConnection = "Server=" + servername + ";Database=" + databasename + ";Integrated Security=False;User ID=" + UserID + "; Password=" + UserPassword;

        //    //    contextOptionsBuilder.UseSqlServer(childConnection);
        //    //}
        //    return contextOptionsBuilder;
        //}

        public string ChangeDatabaseName(string tenantId)
        {
            var configDetails = _TENANTcontext.TblClientConfig.Where(o => o.ClientKey == tenantId).ToList();
            string servername = configDetails[0].ServerName + "," + configDetails[0].ServerPort;
            string databasename = configDetails[0].DatabaseName;
            string UserID = configDetails[0].UserId;
            string UserPassword = configDetails[0].UserPassword;
            string childConnection = "Server=" + servername + ";Database=" + databasename + ";Integrated Security=False;User ID=hrmsdbadmin; Password=hrmsdbadminpwd";

            // contextOptionsBuilder.UseSqlServer(childConnection);

            return childConnection;
        }
    }
}
