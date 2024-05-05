using Microsoft.EntityFrameworkCore;
using WebScrapper.DOMAIN;

namespace WebScrapper.INFRA;

public class DatabaseContextFactoryDbContext : DbContext
{
    private readonly string _connectionString;

    public DatabaseContextFactoryDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Utiliser la chaîne de connexion passée lors de la création du contexte
        optionsBuilder.UseSqlServer(_connectionString);
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