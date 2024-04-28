namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents information about a successful user registration without immediate connection.
    /// </summary>
    public class ReturnedUserNotConnectedRegistrationOk
    {
        /// <summary>
        /// Gets or sets the JWT token associated with the user.
        /// </summary>
        public string Token { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether the JWT token is valid.
        /// </summary>
        public bool IsTokenValid { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the registration was successful.
        /// </summary>
        public bool IsRegistrationOK { get; set; } = true;

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        public string UserType { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether the user is connected.
        /// </summary>
        public bool IsUserConnected { get; set; } = true;

        /// <summary>
        /// Initializes a new instance of the ReturnedUserNotConnectedRegistrationOk class with the specified user information.
        /// </summary>
        /// <param name="user">The user information.</param>
        public ReturnedUserNotConnectedRegistrationOk(User? user)
        {
            IsUserConnected = false;
            IsRegistrationOK = true;
            Token = user.Token;
        }
    }
}