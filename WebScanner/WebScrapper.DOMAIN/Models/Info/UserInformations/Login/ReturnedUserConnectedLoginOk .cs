using Microsoft.Extensions.Configuration;
using WebScrapper.DOMAIN.Models.Helper.TokenHelper;

namespace WebScrapper.DOMAIN
{
    public class ReturnedUserConnectedLoginOk
    {
        public string Token { get; set; } = "";
        public bool IsLoginOK { get; set; } = false;
        public bool IsUserConnected { get; set; } = false;
        public string UserType { get; set; } = "";
        public string UserEmail { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Username { get; set; } = "";

        public ReturnedUserConnectedLoginOk(User user, IConfiguration configuration)
        {
            TokenGenerator tokenGenerator = new TokenGenerator(configuration);

            IsUserConnected = true;
            IsLoginOK = true;
            Token = tokenGenerator.GenerateJwtToken(user.UserType);
            UserType = user.UserType;

            /* Information de connection  */
            UserEmail = user.Email; // on feras en sorte de ne pas vérifier les userPar email. vraiment par token comme ca on peut utiliser le username de manière sécure avec le hashing 
            Username = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}
