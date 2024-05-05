using Microsoft.EntityFrameworkCore;

namespace WebScrapper.DOMAIN;

public interface IDatabaseFactoryService
{
    public DbContext GetContextForClient(string clientId);
}
