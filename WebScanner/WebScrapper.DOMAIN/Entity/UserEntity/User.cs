using System.Text.Json.Serialization;

namespace WebScrapper.DOMAIN
{
    public class User
    {
        public User()
        {
        }

        public User(
            string? password,
            string userType
        )
        {
            Password = password;
            UserType = userType;
        }

        public User(
            int userId,
            string? firstName,
            string? lastName,
            string? userName,
            string? email,
            string? password,
            string userType,
            string token,
            string? userPasswordEncrypt,
            int userRequestHeaderInformationId,
            UserRequestHeaderInformation? userRequestHeaderInformation
        //int? teamId,
        //Team? team
        )
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Password = password;
            UserType = userType;
            Token = token;
            UserPasswordHashed = userPasswordEncrypt;
            UserRequestHeaderInformationId = userRequestHeaderInformationId;
            UserRequestHeaderInformation = userRequestHeaderInformation;
            //TeamId = teamId;
            //Team = team;
        }

        public int UserId { get; set; }
        public int? TeamId { get; set; }

        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";
        public string? UserName { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? Password { get; set; } = "";
        public int? Points { get; set; } = 0;

        public string UserType { get; set; } = "";
        public string Token { get; set; } = "";

        [JsonIgnore]
        public string? UserPasswordHashed { get; set; } = "";

        [JsonIgnore]
        public int UserRequestHeaderInformationId { get; set; }

        [JsonIgnore]
        public UserRequestHeaderInformation? UserRequestHeaderInformation { get; set; }
    }
}