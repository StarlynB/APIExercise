using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UniversityWebAPI.Models.DataModel;

namespace UniversityWebAPI.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaim(this UserTokens userAccount, Guid Id)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", userAccount.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.Email, userAccount.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };


            if (userAccount.UserName == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator")); ;
            }
            else if (userAccount.UserName == "User1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User1"));
                claims.Add(new Claim("User only", "User1"));
            }

            return claims;
        
        }

        public static IEnumerable<Claim> GetClaim(this UserTokens userAccount, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaim(userAccount, Id);
        }

        public static UserTokens GenUserTokenKey(UserTokens model, JwtSetting jwtSetting)
        {
            try
            {
                var userTokens = new UserTokens();
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                //obtain Secret Key

                var key = System.Text.Encoding.ASCII.GetBytes(jwtSetting.IssuerSigningKey);

                Guid Id;

                //Expired in 1 Day

                DateTime Expired = DateTime.UtcNow.AddDays(1);

                //validity of our token
                userTokens.Validity = Expired.TimeOfDay;


                //generate our JWT
                var JwToken = new JwtSecurityToken(
                    issuer: jwtSetting.ValidIssuer,
                    audience: jwtSetting.ValidAudience,
                    claims: GetClaim(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(Expired).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256));

                userTokens.Token = new JwtSecurityTokenHandler().WriteToken(JwToken);
                userTokens.UserName = model.UserName;
                userTokens.Id = model.Id;
                userTokens.GuId= Id;
                return userTokens;
                    
            }catch(Exception ex) 
            {
                throw new Exception("Error generating the JWT" + ex);            
            }



    }
    } 
}
