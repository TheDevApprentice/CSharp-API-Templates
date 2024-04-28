namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents information about a user who is not connected and has no token.
    /// </summary>
    public class ReturnedUserNotConnectedNoTokenInfo
    {
        /// <summary>
        /// Gets or sets a value indicating whether the user is connected.
        /// </summary>
        public bool IsUserConnected { get; set; } = false;
    }
}