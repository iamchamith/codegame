using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BlocklyPro.Core.AppService.Dto.UserDto;
using Microsoft.IdentityModel.Tokens;

namespace BlocklyPro.Api.Configurations
{
    public class Jwt
    {
        public static string TokenGenerator(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("chamith is best,chamith is best,chamith is best,chamith is best");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static int GetClaims(string token)
        {
            token = token.ToString().Replace("Bearer", "").Trim();
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            var id = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;
            return Convert.ToInt32(id);
        }
    }
}
