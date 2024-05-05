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

        public DatabaseContextFactoryRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbContext GetContextForClient(string clientId)
        {
            // Récupérer la chaîne de connexion en fonction de l'identifiant du client
            string connectionString = GetConnectionStringForClient(clientId);

            // Créer et retourner le contexte de base de données en fonction de la chaîne de connexion
            return new DatabaseContextFactoryDbContext(connectionString);
        }

        private string GetConnectionStringForClient(string clientId)
        {
            // Logique pour récupérer la chaîne de connexion à partir de la configuration en fonction de l'ID client
            // Vous pouvez stocker les informations de connexion dans appsettings.json ou dans une autre source de configuration
            // Pour cet exemple, supposons que vous avez une configuration de type "ConnectionStrings" dans appsettings.json
            return _configuration.GetConnectionString(clientId);
        }
    }
}
