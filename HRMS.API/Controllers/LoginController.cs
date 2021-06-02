using HRMS.Business.Login;
using HRMS.Data.Models;
using HRMS.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.API.Areas.Login.Controllers
{
    [Route("api/HRMS/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;
        private readonly AppSettings _appSettings;
        public LoginController(ILogin login, IOptions<AppSettings> appSettings)
        {
            _login = login;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("ValidateUser")]
        public async Task<IActionResult> ValidateUser(object userdetails)
        {
            try
            {
                Dictionary<string, string> user = JsonConvert.DeserializeObject<Dictionary<string, string>>(userdetails.ToString());
                var response = await _login.ValidateUser(user["UserName"].ToString(), user["UserPasswordHash"].ToString());
                if (response.RESPONSEMESSAGE.Contains("successfully"))
                {
                    response.Token = GenerateJwtToken(response.UserName);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("GetUserRoleFunctionlity")]
        public async Task<IActionResult> GetUserRoleFunctionlity(object userRoleFunctionlity)
        {
            try
            {
                Dictionary<string, string> user = JsonConvert.DeserializeObject<Dictionary<string, string>>(userRoleFunctionlity.ToString());
                var response = await _login.GetUserRoleFunctionlity(user["username"].ToString());
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserEntity GetById(string id)
        {
            try
            {
                return _login.GetUserEntity(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private string GenerateJwtToken(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", id) }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
