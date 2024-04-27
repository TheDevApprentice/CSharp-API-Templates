namespace WebScrapper.DOMAIN
{
    public class UserDTO : AllRequestDTO
    {
        public string UserName { get; set; } = "";

        public UserDTO()
        {
        }

        public UserDTO(
            string token
        ) : base(token)
        {
        }

        public UserDTO(
            string token,
            string cookie
        ) : base(token, cookie)
        {
        }

        public UserDTO(
            string token,
            string cookie,
            string username
        ) : base(token, cookie)
        {
            UserName = username;
        }
    }
}
