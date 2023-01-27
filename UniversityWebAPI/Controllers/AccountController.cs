using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
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
        private readonly IStringLocalizer<AccountController> _stringLocalizer;
        public AccountController(JwtSetting jwtSetting, UniversitysDBContext context, IStringLocalizer<AccountController> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _context = context;
            _jwtSetting = jwtSetting;

        }



        [HttpPost]
        public IActionResult GetToken(LoginUsers loginUsers)
        {
            try
            {
                
                var token = new UserTokens();

                //Message Languages
                var MessageWelcome = _stringLocalizer.GetString("Welcome").Value ?? string.Empty;

                //Search a user in context with LinQ
                var SearchUsers = (from User in _context.users
                                   where User.Name == loginUsers.Username && User.Password == loginUsers.Password
                                   select User).FirstOrDefault();

                if(SearchUsers != null)
                {
                    // var user = _context.LoginUsers.FirstOrDefault(user => user.Username.Equals(loginUsers.Username, StringComparison.OrdinalIgnoreCase) && user.Password.Equals(loginUsers.Password, StringComparison.OrdinalIgnoreCase));

                    token = JwtHelpers.GetUserTokens(new UserTokens()
                    {
                        UserName = SearchUsers.Name,
                        EmailId = SearchUsers.Email,
                        Id = SearchUsers.Id,
                        GuId = Guid.NewGuid(),
                    }, _jwtSetting);
                    
                }
                else
                {
                    return BadRequest("wrong password");
                }

                return Ok(new
                {
                    AccountName = MessageWelcome,

                },token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetTokent Error", ex);
            }
        }

        private IActionResult Ok(object value, UserTokens token)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetUserList()
        {
            return Ok();
        }

















    }
}
