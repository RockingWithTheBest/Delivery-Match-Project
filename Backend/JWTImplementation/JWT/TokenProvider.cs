using Backend.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Microservice.JWT
{
    public sealed class TokenProvider
    {
        private readonly IConfiguration configuration;
        public TokenProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Create(User user)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            string secretKey = jwtSettings["Secret"];//Used to sign the JWT
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expiryInMinutes = Convert.ToDouble(jwtSettings["ExpirationInMinutes"]);

            if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
            {
                throw new ArgumentException("JWT secret key must be at least 32 characters long");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.Name, user.FirstName +' '+user.LastName ?? string.Empty),
                new Claim(ClaimTypes.MobilePhone, user.Phone ?? string.Empty),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject =  new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = signInCredentials,
                Issuer = issuer,
                Audience = audience
            };

            var handler = new JsonWebTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            // Validate token is created
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Failed to create JWT token");
            }

            return token;
        }
    }
}
