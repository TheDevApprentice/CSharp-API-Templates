namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents information about an invalid token for a user who is not connected.
    /// </summary>
    public class ReturnedUserNotConnectedInvalidTokenInfo
    {
        /// <summary>
        /// Gets or sets the JWT token associated with the user.
        /// </summary>
        public string Token { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether the JWT token is valid.
        /// </summary>
        public bool IsTokenValid { get; set; } = false;

        /// <summary>
        /// Gets or sets the unique name of the user.
        /// </summary>
        public string UniqueName { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether the user is connected.
        /// </summary>
        public bool IsUserConnected { get; set; } = false;
    }
}