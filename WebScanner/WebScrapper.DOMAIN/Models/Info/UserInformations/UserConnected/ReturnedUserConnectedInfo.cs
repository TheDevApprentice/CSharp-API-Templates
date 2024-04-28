namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents information about a connected user.
    /// </summary>
    public class ReturnedUserConnectedInfo
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
        /// Gets or sets the unique name of the user.
        /// </summary>
        public string UniqueName { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether the user is connected.
        /// </summary>
        public bool IsUserConnected { get; set; } = true;

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        public string UserType { get; set; }
    }
}