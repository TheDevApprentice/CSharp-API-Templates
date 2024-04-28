namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents information about a failed user registration attempt.
    /// </summary>
    public class ReturnedUserNotConnectedRegistrationNotOk
    {
        /// <summary>
        /// Gets or sets the JWT token associated with the user.
        /// </summary>
        public string Token { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether the user is connected.
        /// </summary>
        public bool IsUserConnected { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the registration attempt was successful.
        /// </summary>
        public bool IsRegistrationOK { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the ReturnedUserNotConnectedRegistrationNotOk class with the specified user information.
        /// </summary>
        /// <param name="user">The user information.</param>
        public ReturnedUserNotConnectedRegistrationNotOk(User user)
        {
            IsUserConnected = false;
            IsRegistrationOK = false;
            Token = user.Token;
        }
    }
}