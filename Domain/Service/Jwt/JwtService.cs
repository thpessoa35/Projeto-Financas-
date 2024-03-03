using ijwtRepository;
using Microsoft.IdentityModel.Tokens;
using ProjectFinancas.Controllers.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace jwtService
{
    public class JwtService : IJwtRepository
    {
        private readonly SymmetricSecurityKey _chave;

        public JwtService(IConfiguration config)
        {
            _chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["SecretKey"]));
        }

        public string CreateToken(CodigoDto codigoDto)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, codigoDto.Email),
            };

            var credentials = new SigningCredentials(_chave, SecurityAlgorithms.HmacSha256);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
