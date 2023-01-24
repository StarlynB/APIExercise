using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityWebAPI.DataAccess;
using UniversityWebAPI.Helpers;
using UniversityWebAPI.Models.DataModel;

namespace UniversityWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSetting _jwtSetting;
        private readonly UniversitysDBContext _context;

        public AccountController(JwtSetting jwtSetting, UniversitysDBContext context)
        {
            _context= context;
            _jwtSetting = jwtSetting;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<LoginUsers>>> GetUsers()
        {
            return await _context.LoginUsers.ToListAsync();
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetToken(LoginUsers loginUsers)
        {

            try
            {
                var token = new UserTokens();
                var valid = _context.LoginUsers.Any(user => user.Username.Equals(loginUsers.Username, StringComparison.OrdinalIgnoreCase) || user.Password.Equals(loginUsers.Password));

                if (valid)
                {
                    var user = _context.LoginUsers.FirstOrDefault(user => user.Username.Equals(loginUsers.Username) || user.Password.Equals(loginUsers.Password));

                    token = JwtHelpers.GenUserTokenKey(new UserTokens()
                    {
                        UserName = user.Username,
                        Password = user.Password,
                        GuId = new Guid()
                    }, _jwtSetting);

                }
                else
                {
                    return BadRequest("wrong password");
                }

                return Ok(token);

            }
            catch (Exception ex)
            {
                throw new Exception("GetTokent Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public IActionResult GetUserList()
        {
            return Ok(_context.LoginUsers.ToListAsync());
        }

















    }
}
