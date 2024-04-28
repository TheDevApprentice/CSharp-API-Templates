using System.Text.Json.Serialization;

namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents information about a user request header.
    /// </summary>
    public class UserRequestHeaderInformation
    {
        /// <summary>
        /// The unique identifier of the connection.
        /// </summary>
        public string ConnectionId { get; set; } = "";

        /// <summary>
        /// The remote IP address of the user.
        /// </summary>
        public string? IpRemoteAddress { get; set; }

        /// <summary>
        /// The remote port of the user.
        /// </summary>
        public string? IpRemotePort { get; set; } = "";

        /// <summary>
        /// The local IP address of the user.
        /// </summary>
        public string? IpLocalAddress { get; set; } = "";

        /// <summary>
        /// The client certificate.
        /// </summary>
        public string? ClientCertificate { get; set; } = "";

        /// <summary>
        /// The user agent string.
        /// </summary>
        public string? UserAgent { get; set; } = "";

        /// <summary>
        /// The content type of the request.
        /// </summary>
        public string? ContentType { get; set; } = "";

        /// <summary>
        /// The HTTP method of the request.
        /// </summary>
        public string? Method { get; set; } = "";

        /// <summary>
        /// The protocol used for the request.
        /// </summary>
        public string? Protocol { get; set; } = "";

        /// <summary>
        /// The scheme of the request.
        /// </summary>
        public string? Scheme { get; set; } = "";

        /// <summary>
        /// The token associated with the request.
        /// </summary>
        public string? Token { get; set; } = "";

        /// <summary>
        /// The host of the request.
        /// </summary>
        public string? Host { get; set; }

        /// <summary>
        /// The path of the request.
        /// </summary>
        public string? Path { get; set; }

        /// <summary>
        /// The query string of the request.
        /// </summary>
        public string? QueryString { get; set; }

        /// <summary>
        /// The referer header of the request.
        /// </summary>
        public string? Referer { get; set; }

        /// <summary>
        /// The body of the request.
        /// </summary>
        public string? RequestBody { get; set; }

        // Les propriétés suivantes sont exclues de la sérialisation JSON.

        /// <summary>
        /// The unique identifier of the UserRequestHeaderInformation.
        /// </summary>
        [JsonIgnore]
        public int UserRequestHeaderInformationId { get; set; }

        /// <summary>
        /// The ID of the user associated with the request.
        /// </summary>
        [JsonIgnore]
        public int? UserId { get; set; }

        /// <summary>
        /// Navigation property to the associated User.
        /// </summary>
        [JsonIgnore]
        public User? User { get; set; }
    }
}