using Microsoft.EntityFrameworkCore;
using WebScrapper.DOMAIN;

namespace WebScrapper.DOMAIN.Interfaces.DatabaseFactory;

public interface IDatabaseFactoryRepo
{
    public DbContext GetContextForClient(string clientId);
}

