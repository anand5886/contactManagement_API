using HRMS.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace HRMS.Data.Login
{
    public interface ILoginRepository
    {
        Task<UserEntity> AuthenticateUser(string userName, string password);
        Task<List<UserRoleFunctionalityEntity>> GetUserRoleFunctionlity(string userID);

        UserEntity GetUserEntity(string Id);
    }
}
