namespace WebScrapper.DOMAIN
{
    public class RegisterationDTO : UserDTO
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string PasswordVerification { get; set; } = "";

        public RegisterationDTO(
            string token,
            string cookie,
            string firstName,
            string lastname,
            string username,
            string email,
            string password,
            string passwordVerification
        ) : base(token, cookie, username)
        {
            Token = token;
            Cookie = cookie;
            FirstName = firstName;
            LastName = lastname;
            UserName = username;
            Email = email;
            Password = password;
            PasswordVerification = passwordVerification;
        }
    }
}
