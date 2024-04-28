namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents an administrator user.
    /// </summary>
    public class Administrator : User
    {
        /// <summary>
        /// Indicates whether the administrator is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Initializes a new instance of the Administrator class with the provided user information.
        /// </summary>
        /// <param name="user">The base user information.</param>
        public Administrator(User user)
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

            // Set specific administrator properties
            Active = true;
            UserType = nameof(Guest);
        }

        /// <summary>
        /// Initializes a new instance of the Administrator class.
        /// </summary>
        public Administrator()
        {
            UserType = nameof(Administrator);
        }
    }
}