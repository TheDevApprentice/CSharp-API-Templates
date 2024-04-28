using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebScrapper.DOMAIN.Models.Helper.TokenHelper
{
    /// <summary>
    /// Provides methods for generating JWT tokens.
    /// </summary>
    public class TokenGenerator
    {
        private readonly IConfiguration? _configuration;
        private readonly string _jwtSecretKey;

        /// <summary>
        /// Initializes a new instance of the TokenGenerator class.
        /// </summary>
        /// <param name="configuration">The configuration containing token settings.</param>
        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Generates a JWT token with optional role information.
        /// </summary>
        /// <param name="role">The role of the user (optional).</param>
        /// <returns>The generated JWT token.</returns>
        public string GenerateJwtToken(string role = "")
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDescriptor = null;
            SecurityToken token = null;

            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
            var key = Encoding.ASCII.GetBytes(jwtKey);

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
                                    new Claim(ClaimTypes.Name, nameof(Administrator)),
                                    new Claim(ClaimTypes.Role, nameof(Administrator))
                                }),
                            Issuer = jwtIssuer,
                            Audience = jwtAudience,
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256Signature
                            )
                        };
                        break;

                    case nameof(RegistreredUser):
                        tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(
                                new Claim[] {
                                    new Claim(ClaimTypes.Name, nameof(RegistreredUser)),
                                    new Claim(ClaimTypes.Role, nameof(RegistreredUser))
                                }),
                            Issuer = jwtIssuer,
                            Audience = jwtAudience,
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256Signature
                            )
                        };
                        break;

                    case nameof(Guest):
                        tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(
                                new Claim[] {
                                    new Claim(ClaimTypes.Name, nameof(Guest)),
                                    new Claim(ClaimTypes.Role, nameof(Guest))
                                }),
                            Issuer = jwtIssuer,
                            Audience = jwtAudience,
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256Signature
                            )
                        };
                        break;
                }
            }
            else
            {
                // Generate token for guest user
                tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                        new Claim[] {
                            new Claim(ClaimTypes.Name, nameof(Guest)),
                            new Claim(ClaimTypes.Role, nameof(Guest))
                        }),
                    Issuer = jwtIssuer,
                    Audience = jwtAudience,
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };
            }

            // Create and return the JWT token
            token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        public void Dispose()
        {
            Dispose();
        }
    }
}