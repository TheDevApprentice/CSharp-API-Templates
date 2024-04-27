using Microsoft.EntityFrameworkCore;
using WebScrapper.DOMAIN;

namespace WebScrapper.INFRA
{
    public static class UserConfiguration
    {
        public static ModelBuilder Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(k => k.UserId);
            modelBuilder.Entity<User>()
                    .Property(p => p.UserId)
                    .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                    .Property(p => p.TeamId);
            modelBuilder.Entity<User>()
                    .Property(p => p.FirstName);
            modelBuilder.Entity<User>()
                    .Property(p => p.LastName);
            modelBuilder.Entity<User>()
                    .Property(p => p.Email);
            modelBuilder.Entity<User>()
                    .Property(p => p.Password);
            modelBuilder.Entity<User>()
                    .Property(p => p.UserType);
            modelBuilder.Entity<User>()
                    .Property(p => p.Points);
            modelBuilder.Entity<User>()
                   .HasOne(u => u.UserRequestHeaderInformation)
                   .WithOne(h => h.User)
                   .HasForeignKey<UserRequestHeaderInformation>(h => h.UserId);

            modelBuilder.Entity<User>()
                .HasDiscriminator(p => p.UserType)
                .HasValue<User>("User")
                .HasValue<Administrator>(nameof(Administrator))
                .HasValue<RegistreredUser>(nameof(RegistreredUser))
                .HasValue<Guest>(nameof(Guest))
                .IsComplete(false);

            return modelBuilder;
        }
    }
}
