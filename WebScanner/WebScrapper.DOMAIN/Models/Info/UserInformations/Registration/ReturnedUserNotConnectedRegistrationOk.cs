namespace WebScrapper.DOMAIN
{
    public class ReturnedUserNotConnectedRegistrationOk
    {
        public string Token { get; set; } = "";
        public bool IsTokenValid { get; set; } = true;
        public bool IsRegistrationOK { get; set; } = true;
        public string UserType { get; set; } = "";
        public bool IsUserConnected { get; set; } = true;

        public ReturnedUserNotConnectedRegistrationOk(User? user)
        {
            IsUserConnected = false;
            IsRegistrationOK = true;
            Token = user.Token;
        }
    }
}
