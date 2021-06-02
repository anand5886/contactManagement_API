using HRMS.Business.Contacts;

using HRMS.Business.Ioc;

using HRMS.Business.Login;

using Microsoft.Extensions.DependencyInjection;

namespace HRMS.Business
{
    public class BusinessRegister : IBusinessRegister
    {
        public void RegisterTypes(IServiceCollection services)
        {
            services.AddTransient<ILogin, LoginService>();

            services.AddTransient<IContacts, ContactsService>();
        }
    }
}
