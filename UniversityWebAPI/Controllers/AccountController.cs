using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityWebAPI.Helpers;
using UniversityWebAPI.Models.DataModel;

namespace UniversityWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSetting _jwtSetting;

        public AccountController(JwtSetting jwtSetting)
        {
            _jwtSetting = jwtSetting;
        }

        public List<User> Login = new List<User>
        {
            new User()
            {
                Id = 1,
                Email = "Baez25@gmail.com",
                Name= "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id = 2,
                Email = "Lolo@gmail.com",
                Name= "User1",
                Password= "User1"
            }
        };


        [HttpPost]
        public IActionResult GetToken(LoginUsers loginUsers)
        {
            try
            {
                var token = new UserTokens();
                var valid = Login.Any(user => user.Name.Equals(loginUsers.Username, StringComparison.OrdinalIgnoreCase));

                if (valid)
                {
                    var user = Login.FirstOrDefault(user => user.Name.Equals(loginUsers.Username, StringComparison.OrdinalIgnoreCase));

                    token = JwtHelpers.GenUserTokenKey(new UserTokens()
                    {
                        UserName = user.Name,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuId = new Guid()
                    }, _jwtSetting);

                }
                else
                {
                    return BadRequest("wrong password");
                }

                return Ok(token);

            } catch (Exception ex)
            {
                throw new Exception("GetTokent Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public IActionResult GetUserList()
        {
            return Ok(Login);
        }
    
        


        
    
       










    }
}
