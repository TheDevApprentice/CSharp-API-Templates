using Microsoft.Extensions.Configuration;
using WebScrapper.DOMAIN.Models.Helper.TokenHelper;

namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents information about a successful user login and connection.
    /// </summary>
    public class ReturnedUserConnectedLoginOk
    {
        /// <summary>
        /// Gets or sets the JWT token associated with the user.
        /// </summary>
        public string Token { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether the login was successful.
        /// </summary>
        public bool IsLoginOK { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the user is connected.
        /// </summary>
        public bool IsUserConnected { get; set; } = false;

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        public string UserType { get; set; } = "";

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string UserEmail { get; set; } = "";

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; } = "";

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; } = "";

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; } = "";

        /// <summary>
        /// Initializes a new instance of the ReturnedUserConnectedLoginOk class with the specified user information and configuration.
        /// </summary>
        /// <param name="user">The user information.</param>
        /// <param name="configuration">The configuration for generating the JWT token.</param>
        public ReturnedUserConnectedLoginOk(User user, IConfiguration configuration)
        {
            TokenGenerator tokenGenerator = new TokenGenerator(configuration);

            IsUserConnected = true;
            IsLoginOK = true;
            Token = tokenGenerator.GenerateJwtToken(user.UserType);
            UserType = user.UserType;

            // Connection information
            UserEmail = user.Email; // We will verify users by token, not by email, for added security with username hashing
            Username = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}