using Microsoft.Extensions.Configuration;
using WebScrapper.DOMAIN.Models.Helper.TokenHelper;

namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents a model for creating a guest user.
    /// </summary>
    public class CreateUserGuestModel
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Gets the created user.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Initializes a new instance of the CreateUserGuestModel class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="clientInformationScanner">The client information scanner.</param>
        /// <param name="returnInformation">The return information.</param>
        public CreateUserGuestModel(
            IConfiguration configuration,
            IUserService userService,
            UserRequestHeaderInformation clientInformationScanner,
            out Dictionary<string, object> returnInformation
        )
        {
            _configuration = configuration;
            _userService = userService;

            // Generate token
            TokenGenerator tokenGenerator = new TokenGenerator(_configuration);
            string tokenFromHandshake = tokenGenerator.GenerateJwtToken();

            // Parse and validate token
            Dictionary<string, string> informationFromToken = TokenParser.ParseToken(tokenFromHandshake);
            TokenInfo tokenInfoEncrypted = new TokenInfo { Token = tokenFromHandshake };
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
            tokenInfoEncrypted.IsTokenValid = TokenValidator.IsTokenValid(tokenInfoEncrypted.Token, jwtKey, jwtIssuer, jwtAudience);
            tokenInfoEncrypted.UniqueName = informationFromToken["unique_name"];
            tokenInfoEncrypted.Nbf = informationFromToken["nbf"];
            tokenInfoEncrypted.Exp = informationFromToken["exp"];
            tokenInfoEncrypted.Iat = informationFromToken["iat"];

            // Prepare return information
            returnInformation = new Dictionary<string, object>
            {
                { "TokenInfo", tokenInfoEncrypted }
            };

            // Create and add new guest user
            Guest newUser = new Guest
            {
                Token = tokenInfoEncrypted.Token,
                UserRequestHeaderInformation = clientInformationScanner,
            };
            User = _userService.AddUser(newUser);
        }
    }
}
