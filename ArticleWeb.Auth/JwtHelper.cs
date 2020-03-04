using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArticleWeb.Auth
{
    public class JwtHelper
    {
        public static string GenerateJwtToken(string userName)
        {
            var jwt = new JwtSecurityToken(
                   "Article",
                   "Article",
                   claims: GetIdentity(userName),
                   expires: DateTime.Now.Add(TimeSpan.FromHours(5)),
                   signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aaaaaaaaaaaaaaaaa"))
                   , SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        private static List<Claim> GetIdentity(string username)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
        }
    }
}
