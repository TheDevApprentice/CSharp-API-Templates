namespace WebScrapper.DOMAIN
{
    public class HeaderInfos
    {
        public string Id { get; set; } = "";
        public string IpRemoteAddress { get; set; } = "";
        public string IpRemotePort { get; set; } = "";
        public string IpLocalAddress { get; set; } = "";
        public string ClientCertificate { get; set; } = "";
        public string UserAgent { get; set; } = "";
        public string Method { get; set; } = "";
        public string Protocol { get; set; } = "";
        public string Scheme { get; set; } = "";
    }
}
