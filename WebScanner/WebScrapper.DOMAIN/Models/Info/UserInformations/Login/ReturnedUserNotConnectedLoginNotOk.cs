namespace WebScrapper.DOMAIN
{
    public class ReturnedUserNotConnectedLoginNotOk
    {
        public string Token { get; set; } = "";
        public bool IsLoginOK { get; set; } = false;
        public bool IsUserConnected { get; set; } = false;

        public ReturnedUserNotConnectedLoginNotOk(User user)
        {
            IsUserConnected = false;
            IsLoginOK = false;
            Token = user.Token;
        }
    }
}
