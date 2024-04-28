using System.Text.Json.Serialization;

namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents a registered user.
    /// </summary>
    public class RegistreredUser : User
    {
        /// <summary>
        /// Initializes a new instance of the RegistreredUser class with the provided user information.
        /// </summary>
        /// <param name="user">The base user information.</param>
        public RegistreredUser(User user)
        {
            // Copy base user information
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.Email;
            Password = user.Password;
            UserType = user.UserType;
            Token = user.Token;
            UserPasswordHashed = user.UserPasswordHashed;
            UserRequestHeaderInformation = user.UserRequestHeaderInformation;
            TeamId = user.TeamId;

            // Set specific registered user properties
            Active = true;
            UserType = nameof(RegistreredUser);
        }

        /// <summary>
        /// Initializes a new instance of the RegistreredUser class.
        /// </summary>
        public RegistreredUser()
        {
            Active = true;
            UserType = nameof(RegistreredUser);
        }

        /// <summary>
        /// Represents the experience level of the registered user.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Experience EmployeeExperience { get; set; }

        /// <summary>
        /// Represents the possible experience levels of the registered user.
        /// </summary>
        public enum Experience
        {
            /// <summary>
            /// Junior experience level.
            /// </summary>
            JUNIOR,

            /// <summary>
            /// Senior experience level.
            /// </summary>
            SENIOR
        }

        /// <summary>
        /// Indicates whether the registered user is active.
        /// </summary>
        public bool Active { get; set; }
    }
}