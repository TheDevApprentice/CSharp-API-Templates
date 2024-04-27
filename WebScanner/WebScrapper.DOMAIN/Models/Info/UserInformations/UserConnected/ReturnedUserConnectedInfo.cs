namespace WebScrapper.DOMAIN
{
    public class ReturnedUserConnectedInfo
    {
        public string Token { get; set; } = "";
        public bool IsTokenValid { get; set; } = true;
        public string UniqueName { get; set; } = "";
        public bool IsUserConnected { get; set; } = true;
        public string UserType { get; set; }
    }
}
