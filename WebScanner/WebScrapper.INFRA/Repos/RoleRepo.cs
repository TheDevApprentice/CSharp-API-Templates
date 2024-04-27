using WebScrapper.DOMAIN;

namespace WebScrapper.INFRA
{
    public class RoleRepo : IRoleRepo
    {
        private ApiDbContext _dbapi_cba_ctf;

        public RoleRepo(
            ApiDbContext dbapi_cba_ctf
        )
        {
            _dbapi_cba_ctf = dbapi_cba_ctf;
        }

        List<Role> IRoleRepo.GetUserRoles()
        {
            return _dbapi_cba_ctf.UserRoles
                    .ToList();
        }
    }
}
