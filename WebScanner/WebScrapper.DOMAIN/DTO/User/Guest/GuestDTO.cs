namespace WebScrapper.DOMAIN
{
    public class GuestDTO : UserDTO
    {
        public GuestDTO(
            string token
        ) : base(token)
        {
            Token = token;
        }
    }
}