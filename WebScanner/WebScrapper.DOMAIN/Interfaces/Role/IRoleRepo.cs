namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents a repository for managing user roles.
    /// </summary>
    public interface IRoleRepo
    {
        /// <summary>
        /// Gets the roles assigned to a user.
        /// </summary>
        /// <returns>The list of user roles.</returns>
        public List<Role> GetUserRoles();
    }
}