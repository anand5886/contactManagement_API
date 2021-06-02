using HRMS.Data.Models;
using HRMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Data.Config
{
    public interface IConfigRepository
    {
        Task<List<ConfigEntity>> GetConfiguration(string configType);
    }
}
