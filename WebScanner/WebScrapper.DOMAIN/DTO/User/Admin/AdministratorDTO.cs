namespace WebScrapper.DOMAIN
{
    public class AdministratorDTO : UserDTO
    {
        public AdministratorDTO()
        {
        }

        public AdministratorDTO(
            string token,
            string cookie
        ) : base(token, cookie)
        {
        }

        public AdministratorDTO(
            string token,
            string cookie,
            string username
        ) : base(token, cookie, username)
        {
        }
    }
}