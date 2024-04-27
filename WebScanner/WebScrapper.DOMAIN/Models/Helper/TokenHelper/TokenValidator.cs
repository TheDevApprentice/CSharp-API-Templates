using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebScrapper.DOMAIN.Models.Helper.TokenHelper
{
    public static class TokenValidator
    {
        public static bool IsTokenValid(
            string token,
            string secretKey,
            string issuer,
            string audiance
        )
        {
            try
            {
                TokenValidationParameters tokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audiance,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8
                        .GetBytes(secretKey))
                };

                JwtSecurityTokenHandler tokenHandler = new();

                tokenHandler
                    .ValidateToken(
                        token,
                        tokenValidationParameters,
                        out SecurityToken validatedToken);

                if (validatedToken is JwtSecurityToken jwtSecurityToken &&
                    jwtSecurityToken.Header
                    .Alg.Equals(
                        SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase)
                )
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string message = ex.Message;

                Console
                    .WriteLine($"Exception: {message}");
                Console
                    .WriteLine($"Audiance: {audiance}");

                return false;
            }
        }

        public static bool ValidateToken(
            string token,
            string secretKey,
            string issuer,
            string audience
        )
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII
                         .GetBytes(secretKey);

            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                                   Encoding.UTF8
                                   .GetBytes(secretKey)
                                   )
            };

            try
            {
                SecurityToken securityToken;
                tokenHandler.ValidateToken(
                    token,
                    tokenValidationParameters,
                    out securityToken);

                if (securityToken is JwtSecurityToken jwtSecurityToken &&
                    jwtSecurityToken.Header.Alg.Equals(
                            SecurityAlgorithms.HmacSha256,
                            StringComparison.InvariantCultureIgnoreCase
                        )
                )
                {
                    return true;
                }
            }
            catch (SecurityTokenException)
            {
                return false;
            }

            return false;
        }
    }
}
