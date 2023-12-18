using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Entities;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Buisnes
{
    public class authControllogical
    {

        public authControllogical()
        {

        }

        public Token GenerateJwtToken(List<Users> user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TuClaveSecretaSuperSegura"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user[0].Usuario),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        // Puedes agregar más claims según tus necesidades
    };

            var token = new JwtSecurityToken(
                issuer: "TuIssuer",
                audience: "TuAudience",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Ajusta la expiración según tus necesidades
                signingCredentials: credentials
            );
            Token token1 = new Token();
            token1.token = new JwtSecurityTokenHandler().WriteToken(token);

            return token1;
        }
    }
}
