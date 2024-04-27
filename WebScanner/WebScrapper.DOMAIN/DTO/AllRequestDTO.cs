namespace WebScrapper.DOMAIN
{
    public class AllRequestDTO
    {
        public string Token { get; set; } = "";
        public string Cookie { get; set; } = "";

        public AllRequestDTO()
        {
        }

        public AllRequestDTO(
            string token
        )
        {
            Token = token;
        }

        public AllRequestDTO(
            string token,
            string cookie
        )
        {
            Token = token;
            Cookie = cookie;
        }
    }
}
