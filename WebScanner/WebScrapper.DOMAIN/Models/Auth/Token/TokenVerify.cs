using Microsoft.Extensions.Configuration;
using WebScrapper.DOMAIN.Models.Helper.TokenHelper;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using NJsonSchema.Converters;
using NJsonSchema.NewtonsoftJson.Converters;
namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Provides methods to validate the validity of JWT tokens.
    /// </summary>
    /// 
    public static class TokenVerify
    {
        /// <summary>
        /// Validates the validity of a JWT token.
        /// </summary>
        /// <param name="configuration">The configuration containing JWT settings.</param>
        /// <param name="token">The JWT token to validate.</param>
        /// <returns>TokenInfo containing information about the token's validity.</returns>
        public static TokenInfo ValidateTokenValidity(IConfiguration configuration, string token)
        {
            TokenInfo tokenInfo = new();

            if (!string.IsNullOrEmpty(token))
            {
                var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
                var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
                var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");

                // Parse and validate the token
                var informationFromTokenToVerify = TokenParser.ParseToken(token);
                tokenInfo.Token = token;
                tokenInfo.IsTokenValid = TokenValidator.IsTokenValid(
                    tokenInfo.Token,
                    jwtKey,
                    jwtIssuer,
                    jwtAudience
                );

                // Extract token information
                tokenInfo.UniqueName = informationFromTokenToVerify["unique_name"];
                tokenInfo.Nbf = informationFromTokenToVerify["nbf"];
                tokenInfo.Exp = informationFromTokenToVerify["exp"];
                tokenInfo.Iat = informationFromTokenToVerify["iat"];
            }

            return tokenInfo;
        }
    }
}
