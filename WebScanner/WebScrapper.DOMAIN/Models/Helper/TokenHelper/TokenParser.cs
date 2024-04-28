using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebScrapper.DOMAIN.Models.Helper.TokenHelper
{
    /// <summary>
    /// Provides methods for parsing JWT tokens and extracting claims.
    /// </summary>
    public static class TokenParser
    {
        /// <summary>
        /// Parses a JWT token and extracts its claims.
        /// </summary>
        /// <param name="token">The JWT token to parse.</param>
        /// <returns>A dictionary containing the token's claims.</returns>
        public static Dictionary<string, string> ParseToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

            if (jwtToken == null)
            {
                throw new ArgumentException("Invalid token");
            }

            Dictionary<string, string> claims = new Dictionary<string, string>();

            foreach (Claim claim in jwtToken.Claims)
            {
                claims[claim.Type] = claim.Value;
            }

            return claims;
        }
    }
}