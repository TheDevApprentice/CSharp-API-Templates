namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents information about a user registration attempt where the user already exists.
    /// </summary>
    public class ReturnedUserNotConnectedRegistrationUserAlreadyExist
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
        /// Gets or sets a value indicating whether the registration was successful.
        /// </summary>
        public bool IsRegistrationOK { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the ReturnedUserNotConnectedRegistrationUserAlreadyExist class with the specified user information.
        /// </summary>
        /// <param name="user">The user information.</param>
        public ReturnedUserNotConnectedRegistrationUserAlreadyExist(User user)
        {
            IsUserConnected = false;
            IsRegistrationOK = true;
            Token = user.Token;
        }
    }
}