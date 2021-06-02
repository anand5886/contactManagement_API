using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMS.Business.Ioc
{
   public interface IBusinessRegister
    {
        void RegisterTypes(IServiceCollection services);
    }
}
