namespace WebScrapper.DOMAIN;

public class RoleService : IRoleService
{
    private IRoleRepo _repoRole;

    public RoleService(IRoleRepo repoRole)
    {
        _repoRole = repoRole;
    }

    public List<Role> GetUserRoles()
    {
        return _repoRole
                .GetUserRoles();
    }
}