using Microsoft.Extensions.Configuration;
using WebScrapper.DOMAIN.Models.Helper.TokenHelper;

namespace WebScrapper.DOMAIN
{
    public class CreateUserGuestModel
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public User User { get; }

        public CreateUserGuestModel(
            IConfiguration configuration,
            IUserService userService,
            UserRequestHeaderInformation clientInformationScanner,
            out Dictionary<string, object> returnInformation
        )
        {
            _configuration = configuration;
            _userService = userService;

            TokenGenerator _tokenGenerator = new(_configuration);

            string tokenFromHandshake = _tokenGenerator
                                         .GenerateJwtToken();

            Dictionary<string, string> informationFromToken = TokenParser
                                        .ParseToken(tokenFromHandshake);

            TokenInfo tokenInfoEncrypted = new()
            {
                Token = tokenFromHandshake
            };

            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");

            tokenInfoEncrypted.IsTokenValid = TokenValidator
                                              .IsTokenValid(
                                                tokenInfoEncrypted.Token,
                                                jwtKey,
                                                jwtIssuer,
                                                jwtAudience);

            tokenInfoEncrypted.UniqueName = informationFromToken["unique_name"];
            tokenInfoEncrypted.Nbf = informationFromToken["nbf"];
            tokenInfoEncrypted.Exp = informationFromToken["exp"];
            tokenInfoEncrypted.Iat = informationFromToken["iat"];

            returnInformation = new()
            {
                { "TokenInfo", tokenInfoEncrypted }
            };

            Guest newUser = new()
            {
                Token = tokenInfoEncrypted.Token,
                UserRequestHeaderInformation = clientInformationScanner,
            };

            User = _userService
                    .AddUser(newUser);
        }
    }
}
