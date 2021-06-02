using HRMS.Business;
using HRMS.Business.Ioc;
using HRMS.Data;
using HRMS.Data.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace HRMS.API.Configuration
{
    public class IocContainerConfiguration
    {
        private readonly IBusinessRegister _businessRegister;
        private readonly IRepositoryRegister _repositoryRegister;
        public IocContainerConfiguration()
        {
            _businessRegister = new BusinessRegister();
            _repositoryRegister = new RepositoryRegister();
        }
        public void ConfigureService(IServiceCollection services)
        {
            _businessRegister.RegisterTypes(services);
            _repositoryRegister.RegisterTypes(services);
        }
    }
}
