using Microsoft.EntityFrameworkCore;
using WebScrapper.DOMAIN;

public static class RoleConfiguration
{
    public static ModelBuilder Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>()
            .HasKey(k => k.Id);
        modelBuilder.Entity<Role>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Role>()
            .Property(p => p.Name);

        return modelBuilder;
    }
}