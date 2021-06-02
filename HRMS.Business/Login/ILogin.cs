using HRMS.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace HRMS.Business.Login
{
    public interface ILogin
    {
        Task<UserEntity> ValidateUser(string userName, string password);
        Task<List<UserRoleFunctionalityEntity>> GetUserRoleFunctionlity(string userID);
        Task<List<ConfigEntity>> GetConfigValues(string configType);
        UserEntity GetUserEntity(string Id);
    }
}
