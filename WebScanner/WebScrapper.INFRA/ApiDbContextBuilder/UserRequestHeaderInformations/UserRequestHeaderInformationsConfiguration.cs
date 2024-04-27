using Microsoft.EntityFrameworkCore;
using WebScrapper.DOMAIN;

namespace WebScrapper.INFRA
{
    public static class UserRequestHeaderInformationsConfiguration
    {
        public static ModelBuilder Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRequestHeaderInformation>(entity =>
            {
                entity.HasKey(k => k.UserRequestHeaderInformationId);
                entity.Property(p => p.UserRequestHeaderInformationId)
                    .ValueGeneratedOnAdd();

                entity.Property(p => p.ConnectionId);
                entity.Property(p => p.IpLocalAddress);
                entity.Property(p => p.IpRemoteAddress);
                entity.Property(p => p.IpRemotePort);
                entity.Property(p => p.ContentType);
                entity.Property(p => p.Method);
                entity.Property(p => p.ClientCertificate);
                entity.Property(p => p.Scheme);
                entity.Property(p => p.Protocol);
                entity.Property(p => p.UserAgent);
                entity.Property(p => p.Token);
                entity.Property(p => p.Host);
                entity.Property(p => p.Path);
                entity.Property(p => p.QueryString);
                entity.Property(p => p.Referer);
                entity.Property(p => p.RequestBody);

                // Définition de la relation un à un avec User
                entity.HasOne(p => p.User)
                      .WithOne(p => p.UserRequestHeaderInformation)
                      .HasForeignKey<User>(h => h.UserRequestHeaderInformationId);
            });


            return modelBuilder;
        }
    }
}
