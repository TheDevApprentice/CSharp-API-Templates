using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebScrapper.DOMAIN.Models.Helper.TokenHelper
{
    public class TokenGenerator
    {
        private readonly IConfiguration? _configuration;
        private readonly string _jwtSecretKey;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string role = "")
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDescriptor = null;
            SecurityToken token = null;


            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
            var key = Encoding.ASCII
                      .GetBytes(jwtKey);

            // Generate token based on the user's role
            if (!string.IsNullOrEmpty(role))
            {
                switch (role)
                {
                    case nameof(Administrator):
                        tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(
                            new Claim[] {
                                new Claim(ClaimTypes.Name,
                                nameof(Administrator)),
                                new Claim(ClaimTypes.Role,
                                nameof(Administrator))
                            }),
                            Issuer = jwtIssuer,
                            Audience = jwtAudience,
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(
                                                 new SymmetricSecurityKey(key),
                                                 SecurityAlgorithms.HmacSha256Signature
                                             )
                        };

                        token = tokenHandler
                            .CreateToken(tokenDescriptor);

                        return tokenHandler
                            .WriteToken(token);

                    case nameof(RegistreredUser):
                        tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(
                            new Claim[] {
                                new Claim(ClaimTypes.Name,
                                nameof(RegistreredUser)),
                                new Claim(ClaimTypes.Role,
                                nameof(RegistreredUser))
                            }),
                            Issuer = jwtIssuer,
                            Audience = jwtAudience,
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(
                                                 new SymmetricSecurityKey(key),
                                                 SecurityAlgorithms.HmacSha256Signature
                                              )
                        };

                        token = tokenHandler
                            .CreateToken(tokenDescriptor);

                        return tokenHandler
                            .WriteToken(token);

                    case nameof(Guest):
                        tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new(
                            new[] {
                                new Claim(ClaimTypes.Name,
                                nameof(RegistreredUser)),
                                new Claim(ClaimTypes.Role,
                                nameof(RegistreredUser))
                            }),
                            Issuer = jwtIssuer,
                            Audience = jwtAudience,
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(
                                                 new SymmetricSecurityKey(key),
                                                 SecurityAlgorithms.HmacSha256Signature
                                              )
                        };

                        token = tokenHandler
                            .CreateToken(tokenDescriptor);

                        return tokenHandler
                            .WriteToken(token);
                }
            }
            else
            {
                tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                                new Claim[] {
                                        new Claim(ClaimTypes.Name,
                                        nameof(Guest)),
                                        new Claim(ClaimTypes.Role,
                                        nameof(Guest))
                                    }),
                    Issuer = jwtIssuer,
                    Audience = jwtAudience,
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(
                                         new SymmetricSecurityKey(key),
                                         SecurityAlgorithms.HmacSha256Signature
                                       )
                };

                token = tokenHandler
                        .CreateToken(tokenDescriptor);

                return tokenHandler
                       .WriteToken(token);
            }

            throw new InvalidOperationException("sdfsdf");
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
