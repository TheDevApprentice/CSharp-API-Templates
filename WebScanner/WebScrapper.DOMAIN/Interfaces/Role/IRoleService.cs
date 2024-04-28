namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents a service for managing user roles.
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Gets the roles assigned to a user.
        /// </summary>
        /// <returns>The list of user roles.</returns>
        public List<Role> GetUserRoles();
    }
}
