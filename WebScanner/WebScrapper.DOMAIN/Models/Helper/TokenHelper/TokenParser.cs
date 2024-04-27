using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebScrapper.DOMAIN.Models.Helper.TokenHelper
{
    public static class TokenParser
    {
        public static Dictionary<string, string> ParseToken(
            string token
        )
        {
            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler
                                        .ReadToken(token);

            if (jwtToken == null)
            {
                throw new ArgumentException("Invalid token");
            }

            Dictionary<string, string> claims = new();

            foreach (Claim claim in jwtToken.Claims)
            {
                claims[claim.Type] = claim.Value;
            }

            return claims;
        }
    }
}
