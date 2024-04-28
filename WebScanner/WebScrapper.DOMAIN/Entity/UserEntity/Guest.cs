namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents a guest user.
    /// </summary>
    public class Guest : User
    {
        /// <summary>
        /// Indicates whether the guest is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Initializes a new instance of the Guest class.
        /// </summary>
        public Guest()
        {
            Active = true;
            UserType = nameof(Guest);
        }

        /// <summary>
        /// Initializes a new instance of the Guest class with the provided user information.
        /// </summary>
        /// <param name="user">The base user information.</param>
        public Guest(User user)
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

            // Set specific guest properties
            Active = true;
            UserType = nameof(Guest);
        }

        /// <summary>
        /// Represents the experience level of the guest.
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
    }
}