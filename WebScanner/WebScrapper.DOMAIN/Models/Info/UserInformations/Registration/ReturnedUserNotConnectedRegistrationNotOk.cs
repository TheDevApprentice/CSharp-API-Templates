namespace WebScrapper.DOMAIN
{
    public class ReturnedUserNotConnectedRegistrationNotOk
    {
        public string Token { get; set; } = "";
        public bool IsUserConnected { get; set; } = false;
        public bool IsRegistrationOK { get; set; } = false;

        public ReturnedUserNotConnectedRegistrationNotOk(User user)
        {
            IsUserConnected = false;
            IsRegistrationOK = false;
            Token = user.Token;
        }
    }
}
