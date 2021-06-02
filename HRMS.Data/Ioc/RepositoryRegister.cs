//using HRMS.API.Data.DataSeed;
//using HRMS.API.Data.Management;
using HRMS.Data.Config;
using HRMS.Data.Contacts;
using HRMS.Data.Ioc;
using HRMS.Data.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HRMS.Data
{
    public class RepositoryRegister : IRepositoryRegister
    {
        public void RegisterTypes(IServiceCollection services)
        {
            //services.AddTransient<IDataSeeder, DataSeeder>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<IContextFactory, ContextFactory>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IContactsRepository, ContactsRepository>();
            services.AddTransient<IConfigRepository, ConfigRepository>();
        }
    }
}
