using Microsoft.EntityFrameworkCore;
using WebScrapper.DOMAIN;
namespace WebScrapper.INFRA
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(
            DbContextOptions<ApiDbContext> options
        ) : base(options)
        {

        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
        }

        public DbSet<Role> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRequestHeaderInformation> UserRequestHeaderInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(RoleSeedData
                                .Seed(RoleConfiguration
                                .Configure(UsersSeedData
                                .Seed(UserConfiguration
                                .Configure(UserRequestHeaderInformationsSeedData
                                .Seed(UserRequestHeaderInformationsConfiguration
                                .Configure(modelBuilder))
                                )
                              )
                            )
                          )
                );
        }
    }
}