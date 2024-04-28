using Newtonsoft.Json;
using NJsonSchema.NewtonsoftJson.Converters;

namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    /// 
    [JsonConverter(typeof(JsonInheritanceConverter), "type")]
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the User class with the provided password and user type.
        /// </summary>
        /// <param name="password">The user's password.</param>
        /// <param name="userType">The type of user.</param>
        public User(string? password, string userType)
        {
            Password = password;
            UserType = userType;
        }

        /// <summary>
        /// Initializes a new instance of the User class with the provided information.
        /// </summary>
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
        }

        /// <summary>
        /// The unique identifier of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The ID of the team the user belongs to.
        /// </summary>
        public int? TeamId { get; set; }

        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string? FirstName { get; set; } = "";

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string? LastName { get; set; } = "";

        /// <summary>
        /// The username of the user.
        /// </summary>
        public string? UserName { get; set; } = "";

        /// <summary>
        /// The email address of the user.
        /// </summary>
        public string? Email { get; set; } = "";

        /// <summary>
        /// The password of the user.
        /// </summary>
        public string? Password { get; set; } = "";

        /// <summary>
        /// The points of the user.
        /// </summary>
        public int? Points { get; set; } = 0;

        /// <summary>
        /// The type of user.
        /// </summary>
        public string UserType { get; set; } = "";

        /// <summary>
        /// The token associated with the user.
        /// </summary>
        public string Token { get; set; } = "";

        /// <summary>
        /// The hashed password of the user (excluded from serialization).
        /// </summary>
        [JsonIgnore]
        public string? UserPasswordHashed { get; set; } = "";

        /// <summary>
        /// The ID of the user request header information associated with the user (excluded from serialization).
        /// </summary>
        [JsonIgnore]
        public int UserRequestHeaderInformationId { get; set; }

        /// <summary>
        /// The user request header information associated with the user (excluded from serialization).
        /// </summary>
        [JsonIgnore]
        public UserRequestHeaderInformation? UserRequestHeaderInformation { get; set; }
    }
}