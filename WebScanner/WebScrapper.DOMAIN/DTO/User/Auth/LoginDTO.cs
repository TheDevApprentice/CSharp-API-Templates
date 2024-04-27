namespace WebScrapper.DOMAIN.DTO
{
    public class LoginDTO : UserDTO
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";

        public LoginDTO(
            string token,
            string username,
            string password,
            string cookie = ""
        ) : base(token, cookie)
        {
            Token = token;
            Cookie = cookie;
            UserName = username;
            Password = password;
        }
    }
}