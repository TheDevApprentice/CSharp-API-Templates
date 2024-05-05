using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrapper.DOMAIN;
using WebScrapper.DOMAIN.Interfaces.DatabaseFactory;

namespace WebScrapper.INFRA.Repos
{
    public class DatabaseContextFactoryRepo : IDatabaseFactoryRepo
    {
        private readonly IConfiguration _configuration;
        private DatabaseContextFactoryDbContext _db_client;

        public DatabaseContextFactoryRepo(IConfiguration configuration, DatabaseContextFactoryDbContext db_client)
        {
            _configuration = configuration;
            _db_client = db_client;
        }

        public DbContext GetContextForClient(string clientId)
        {
            string connectionString = GetConnectionStringForClient(clientId);

            return new DatabaseContextFactoryDbContext(connectionString);
        }

        protected string GetConnectionStringForClient(string clientId)
        {
            string connectionString = $"Server={"DB_SERVER_PROD"},{"DB_PORT_PORT"};" +
                                      $"Database={"DB_NAME_PROD"};" +
                                      $"User id={"DB_USER_PROD"};" +
                                      $"Pwd={"DB_PASSWORD_PROD"};" +
                                      $"TrustServerCertificate={"DB_TRUST_CERTIFICATE_SERVER_PROD"}"; 

            return connectionString;
        }
    }
}
