namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents header information associated with a request.
    /// </summary>
    public class HeaderInfos
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public string Id { get; set; } = "";

        /// <summary>
        /// Gets or sets the remote IP address.
        /// </summary>
        public string IpRemoteAddress { get; set; } = "";

        /// <summary>
        /// Gets or sets the remote port.
        /// </summary>
        public string IpRemotePort { get; set; } = "";

        /// <summary>
        /// Gets or sets the local IP address.
        /// </summary>
        public string IpLocalAddress { get; set; } = "";

        /// <summary>
        /// Gets or sets the client certificate.
        /// </summary>
        public string ClientCertificate { get; set; } = "";

        /// <summary>
        /// Gets or sets the user agent.
        /// </summary>
        public string UserAgent { get; set; } = "";

        /// <summary>
        /// Gets or sets the request method.
        /// </summary>
        public string Method { get; set; } = "";

        /// <summary>
        /// Gets or sets the request protocol.
        /// </summary>
        public string Protocol { get; set; } = "";

        /// <summary>
        /// Gets or sets the request scheme.
        /// </summary>
        public string Scheme { get; set; } = "";
    }
}