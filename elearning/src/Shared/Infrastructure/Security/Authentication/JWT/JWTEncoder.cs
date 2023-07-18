using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using elearning.src.IAM.Token.Domain;

namespace elearning.src.Shared.Infrastructure.Security.Authentication.JWT
{
    public class JWTEncoder : IJWTEncoder
    {
        private IConfiguration _configuration;

        public JWTEncoder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Encode(Payload payload)
        {
            var secret = _configuration.GetValue<string>("AppSettings:Secret");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("user_id", payload.userId),
                    new Claim("email", payload.email),
                    new Claim("first_name", payload.firstName),
                    new Claim("last_name", payload.lastName),
                    new Claim("role", payload.role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}