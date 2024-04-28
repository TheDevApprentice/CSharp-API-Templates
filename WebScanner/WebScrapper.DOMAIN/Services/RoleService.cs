namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Service class for managing user roles.
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _repoRole;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="repoRole">The repository for user roles.</param>
        public RoleService(IRoleRepo repoRole)
        {
            _repoRole = repoRole;
        }

        /// <summary>
        /// Retrieves user roles from the repository.
        /// </summary>
        /// <returns>A list of user roles.</returns>
        public List<Role> GetUserRoles()
        {
            return _repoRole.GetUserRoles();
        }
    }
}
