using System.Text.Json.Serialization;

namespace WebScrapper.DOMAIN
{
    public class UserRequestHeaderInformation
    {

        public string ConnectionId { get; set; } = "";
        public string? IpRemoteAddress { get; set; }
        public string? IpRemotePort { get; set; } = "";
        public string? IpLocalAddress { get; set; } = "";
        public string? ClientCertificate { get; set; } = "";
        public string? UserAgent { get; set; } = "";
        public string? ContentType { get; set; } = "";
        public string? Method { get; set; } = "";
        public string? Protocol { get; set; } = "";
        public string? Scheme { get; set; } = "";
        public string? Token { get; set; } = "";
        public string? Host { get; set; }
        public string? Path { get; set; }
        public string? QueryString { get; set; }
        public string? Referer { get; set; }
        public string? RequestBody { get; set; }
        //public Stream? Body { get; set; }
        //public PipeReader? BodyReader { get; set; }


        [JsonIgnore]
        public int UserRequestHeaderInformationId { get; set; }

        [JsonIgnore]
        public int? UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}
