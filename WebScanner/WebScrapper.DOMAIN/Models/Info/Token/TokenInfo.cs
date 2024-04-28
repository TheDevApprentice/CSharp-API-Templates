namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents information about a JWT token.
    /// </summary>
    public class TokenInfo
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public string Id { get; set; } = "";

        /// <summary>
        /// Gets or sets the JWT token.
        /// </summary>
        public string Token { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether the token is valid.
        /// </summary>
        public bool IsTokenValid { get; set; }

        /// <summary>
        /// Gets or sets the unique name associated with the token.
        /// </summary>
        public string UniqueName { get; set; } = "";

        /// <summary>
        /// Gets or sets the "Not Before" claim value of the token.
        /// </summary>
        public string Nbf { get; set; } = "";

        /// <summary>
        /// Gets or sets the "Expiration Time" claim value of the token.
        /// </summary>
        public string Exp { get; set; } = "";

        /// <summary>
        /// Gets or sets the "Issued At" claim value of the token.
        /// </summary>
        public string Iat { get; set; } = "";
    }
}