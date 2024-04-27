namespace WebScrapper.DOMAIN
{
    public class ReturnedUserNotConnectedInvalidTokenInfo
    {
        public string Token { get; set; } = "";
        public bool IsTokenValid { get; set; } = false;
        public string UniqueName { get; set; } = "";
        public bool IsUserConnected { get; set; } = false;
    }
}
