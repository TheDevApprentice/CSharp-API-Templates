namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents information about a failed user login attempt.
    /// </summary>
    public class ReturnedUserNotConnectedLoginNotOk
    {
        /// <summary>
        /// Gets or sets the JWT token associated with the user.
        /// </summary>
        public string Token { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether the login attempt was successful.
        /// </summary>
        public bool IsLoginOK { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the user is connected.
        /// </summary>
        public bool IsUserConnected { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the ReturnedUserNotConnectedLoginNotOk class with the specified user information.
        /// </summary>
        /// <param name="user">The user information.</param>
        public ReturnedUserNotConnectedLoginNotOk(User user)
        {
            IsUserConnected = false;
            IsLoginOK = false;
            Token = user.Token;
        }
    }
}