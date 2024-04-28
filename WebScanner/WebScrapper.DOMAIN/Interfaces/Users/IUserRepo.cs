namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents a repository for managing users.
    /// </summary>
    public interface IUserRepo
    {
        /// <summary>
        /// Gets a user by their username.
        /// </summary>
        /// <param name="name">The username of the user.</param>
        /// <returns>The user with the specified username.</returns>
        User GetUserByUserName(string name);

        /// <summary>
        /// Verifies if a user exists based on their token.
        /// </summary>
        /// <param name="token">The token of the user.</param>
        /// <returns>The user if it exists; otherwise, null.</returns>
        User VerifyUserExist(string token);

        /// <summary>
        /// Gets a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>The user with the specified email address.</returns>
        User GetUserByEmail(string email);

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <returns>The added user.</returns>
        User AddUser(User user);

        /// <summary>
        /// Modifies an existing user.
        /// </summary>
        /// <param name="user">The user to modify.</param>
        /// <returns>The modified user.</returns>
        User ModifyUser(User user);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        List<User> GetAllUsers();
    }
}