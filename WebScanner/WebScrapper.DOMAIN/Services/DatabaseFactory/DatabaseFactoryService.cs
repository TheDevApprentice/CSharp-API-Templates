using Microsoft.EntityFrameworkCore;
using WebScrapper.DOMAIN;

namespace WebScrapper.DOMAIN;

public class DatabaseFactoryService : IDatabaseFactoryService
{
    private readonly IDatabaseFactoryService _repoRole;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleService"/> class.
    /// </summary>
    /// <param name="repoRole">The repository for user roles.</param>
    public DatabaseFactoryService(IDatabaseFactoryService repoRole)
    {
        _repoRole = repoRole;
    }

    public DbContext GetContextForClient(string clientId)
    {
        throw new NotImplementedException();
    }
}
