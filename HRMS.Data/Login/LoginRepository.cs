using HRMS.Data.Models;
using HRMS.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Data.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly TENANT_MASTERContext _tenantMASTERContext;

        public LoginRepository(TENANT_MASTERContext tenantMASTERContext)
        {
            _tenantMASTERContext = tenantMASTERContext;
        }
        public async Task<UserEntity> AuthenticateUser(string userName, string password)
        {
            try
            {
                object[] parameters = { userName, password };
                var result = _tenantMASTERContext.Set<UserEntity>().FromSqlRaw("EXEC uspLogin {0},{1}", parameters).AsEnumerable().FirstOrDefault();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<UserRoleFunctionalityEntity>> GetUserRoleFunctionlity(string userID)
        {
            try
            {
                var UserRoleFunctionlityDetails = (from user in _tenantMASTERContext.TblUser
                                                   join ur in _tenantMASTERContext.TblUserRole on user.UserIdPk equals ur.UserIdPk
                                                   join ro in _tenantMASTERContext.TblRole on ur.RoleIdPk equals ro.RoleIdPk
                                                   join rf in _tenantMASTERContext.TblRoleFunctionality on ro.RoleIdPk equals rf.RoleIdPk
                                                   join f in _tenantMASTERContext.TblFunctionality on rf.FunctionalityIdPk equals f.FunctionalityIdPk
                                                   where user.UserName.ToUpper().Trim() == userID.ToUpper().Trim() && user.IsActive == true && ur.IsActive == true
                                                   && ro.IsActive == true && rf.IsActive == true && f.IsActive == true
                                                   select new UserRoleFunctionalityEntity
                                                   {
                                                       UserID = user.UserIdPk,
                                                       UserName = user.UserName,
                                                       FirstName = user.FirstName,
                                                       LastName = user.LastName,
                                                       RoleName = ro.RoleName,
                                                       RoleDescription = ro.RoleDesc,
                                                       FunctionalityName = f.FuncName,
                                                       FunctionalityDescription = f.FuncDesc
                                                   });
                return await Task.FromResult(UserRoleFunctionlityDetails.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserEntity GetUserEntity(string id)
        {
            try
            {
                var result = (from user in _tenantMASTERContext.TblUser
                              where user.UserName.ToUpper().Trim() == id.ToUpper().Trim() && user.IsActive == true
                              select new UserEntity
                              {
                                  USER_ID_PK = user.UserIdPk,
                                  UserName = user.UserName,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName
                              }).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
