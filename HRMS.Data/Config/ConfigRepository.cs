using HRMS.Data.Models;
using HRMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Data.Config
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly TENANT_MASTERContext _master;

        public ConfigRepository(TENANT_MASTERContext tenantMaster)
        {
            _master = tenantMaster;
        }

        public async Task<List<ConfigEntity>> GetConfiguration(string configType)
        {
            try
            {
                var configDetails = from smtp in _master.TblConfig
                                          where smtp.ConfigType == configType.Trim().ToUpper() && smtp.IsActive == true
                                          select new ConfigEntity
                                          {
                                              ConfigKey = smtp.ConfigKey,
                                              ConfigValue = smtp.ConfigValue
                                          };               
                return await Task.FromResult(configDetails.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
