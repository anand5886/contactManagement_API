using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMS.Data.Ioc
{
   public interface IRepositoryRegister
    {
        void RegisterTypes(IServiceCollection services);
    }
}
