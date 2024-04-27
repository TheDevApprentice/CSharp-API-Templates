using Microsoft.Extensions.Configuration;
using WebScrapper.DOMAIN.Models.Helper.TokenHelper;

namespace WebScrapper.DOMAIN
{
    public static class TokenVerify
    {
        public static TokenInfo ValidateTokenValidity(
            IConfiguration configuration,
            string token
        )
        {
            TokenInfo tokenInfo = new();

            if (!string.IsNullOrEmpty(token))
            {
                var informationFromTokenToVerify = TokenParser
                                                   .ParseToken(token);
                tokenInfo.Token = token;
                tokenInfo.IsTokenValid = TokenValidator
                                        .IsTokenValid(
                                           tokenInfo.Token,
                                           configuration["Jwt:Key"],
                                           configuration["Jwt:Issuer"],
                                           configuration["Jwt:Audiance"]);

                tokenInfo.UniqueName = informationFromTokenToVerify["unique_name"];
                tokenInfo.Nbf = informationFromTokenToVerify["nbf"];
                tokenInfo.Exp = informationFromTokenToVerify["exp"];
                tokenInfo.Iat = informationFromTokenToVerify["iat"];
            }

            return tokenInfo;
        }
    }
}
