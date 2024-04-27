using Microsoft.EntityFrameworkCore;
using WebScrapper.DOMAIN;

public static class RoleSeedData
{
    public static ModelBuilder Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role()
            {
                Id = 1,
                Name = nameof(Guest),
            },
            new Role()
            {
                Id = 2,
                Name = nameof(Administrator),
            },
            new Role()
            {
                Id = 3,
                Name = nameof(RegistreredUser),
            }
        );
        return modelBuilder;
    }
}
