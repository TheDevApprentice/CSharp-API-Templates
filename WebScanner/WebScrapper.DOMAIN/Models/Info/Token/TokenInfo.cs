namespace WebScrapper.DOMAIN
{
    public class TokenInfo
    {
        public string Id { get; set; } = "";
        public string Token { get; set; } = "";
        public bool IsTokenValid { get; set; }
        public string UniqueName { get; set; } = "";
        public string Nbf { get; set; } = "";
        public string Exp { get; set; } = "";
        public string Iat { get; set; } = "";
    }
}
