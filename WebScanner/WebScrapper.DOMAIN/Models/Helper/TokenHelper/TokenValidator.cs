using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebScrapper.DOMAIN.Models.Helper.TokenHelper
{
    /// <summary>
    /// Provides methods for validating JWT tokens.
    /// </summary>
    public static class TokenValidator
    {
        /// <summary>
        /// Validates the authenticity and integrity of a JWT token.
        /// </summary>
        /// <param name="token">The JWT token to validate.</param>
        /// <param name="secretKey">The secret key used for token validation.</param>
        /// <param name="issuer">The issuer of the token.</param>
        /// <param name="audience">The intended audience of the token.</param>
        /// <returns>True if the token is valid, otherwise false.</returns>
        public static bool IsTokenValid(string token, string secretKey, string issuer, string audience)
        {
            try
            {
                TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

                if (validatedToken is JwtSecurityToken jwtSecurityToken &&
                    jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log and handle exceptions
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Audience: {audience}");

                return false;
            }
        }

        /// <summary>
        /// Validates the authenticity and integrity of a JWT token.
        /// </summary>
        /// <param name="token">The JWT token to validate.</param>
        /// <param name="secretKey">The secret key used for token validation.</param>
        /// <param name="issuer">The issuer of the token.</param>
        /// <param name="audience">The intended audience of the token.</param>
        /// <returns>True if the token is valid, otherwise false.</returns>
        public static bool ValidateToken(string token, string secretKey, string issuer, string audience)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secretKey);

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            try
            {
                SecurityToken securityToken;
                tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

                if (securityToken is JwtSecurityToken jwtSecurityToken &&
                    jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            catch (SecurityTokenException)
            {
                // Token validation failed
                return false;
            }

            return false;
        }
    }
}