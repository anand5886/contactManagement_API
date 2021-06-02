using HRMS.Data.Config;
using HRMS.Data.Login;
using HRMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Business.Login
{
    public class LoginService : ILogin
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfigRepository _config;
        public LoginService(ILoginRepository loginRepository, IConfigRepository config)
        {
            _loginRepository = loginRepository;
            _config = config;
        }
        public async Task<UserEntity> ValidateUser(string userName, string password)
        {
            return await _loginRepository.AuthenticateUser(userName, password);
        }

        public async Task<List<ConfigEntity>> GetConfigValues(string configType)
        {
            try
            {
                return await _config.GetConfiguration(configType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserRoleFunctionalityEntity>> GetUserRoleFunctionlity(string userID)
        {
            return await _loginRepository.GetUserRoleFunctionlity(userID);
        }

        public UserEntity GetUserEntity(string Id)
        {
           return _loginRepository.GetUserEntity(Id);
        }
    }
}
