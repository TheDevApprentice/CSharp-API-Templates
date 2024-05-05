using WebScrapper.DOMAIN;

namespace WebScrapper.INFRA
{
    public class ClientRepo : IRoleRepo
    {
        private DatabaseContextFactoryDbContext _db_client;

        public ClientRepo(
            DatabaseContextFactoryDbContext db_client
        )
        {
            _db_client = db_client;
        }

        List<Role> IRoleRepo.GetUserRoles()
        {
            return _db_client.UserRoles
                    .ToList();
        }
    }
}
