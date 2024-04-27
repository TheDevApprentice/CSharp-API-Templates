namespace WebScrapper.DOMAIN
{
    public class ReturnedUserNotConnectedRegistrationUserAlreadyExist
    {
        public string Token { get; set; } = "";
        public bool IsUserConnected { get; set; } = false;
        public bool IsRegistrationOK { get; set; } = false;

        public ReturnedUserNotConnectedRegistrationUserAlreadyExist(User user)
        {
            IsUserConnected = false;
            IsRegistrationOK = true;
            Token = user.Token;
        }
    }
}
