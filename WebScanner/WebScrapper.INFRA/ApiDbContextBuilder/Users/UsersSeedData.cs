using Microsoft.EntityFrameworkCore;

namespace WebScrapper.INFRA
{
    public static class UsersSeedData
    {
        public static ModelBuilder Seed(
            ModelBuilder modelBuilder
        )
        {
            //  modelBuilder.Entity<Guest>().HasData(
            //    new Guest
            //    {
            //        UserId = 1,
            //        TeamId = 3,
            //        Active = false,
            //        Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikd1ZXN0Iiwicm9sZSI6Ikd1ZXN0IiwibmJmIjoxNzEwNjg2Mzg3LCJleHAiOjE3MTEyOTExODcsImlhdCI6MTcxMDY4NjM4NywiaXNzIjoieW91cl9Jc3N1ZXIiLCJhdWQiOiJ5b3VyX0F1ZGlhbmNlIn0.QHiXv4LyVK6fV1_rBHAK1u1WN8vkuKtcAcAq1pEkqR4",
            //        UserType = nameof(Guest)
            //    }
            //);

            //  modelBuilder.Entity<RegistreredUser>().HasData(
            //      new RegistreredUser
            //      {
            //          UserId = 2,
            //          TeamId = 1,
            //          FirstName = "Mamadou Moustapha",
            //          LastName = "Diallo",
            //          UserName = "thelegend",
            //          Email = "support@exemple.com",
            //          Token = "",
            //          Points = 0,
            //          Active = false,
            //          UserType = nameof(RegistreredUser),
            //          /*IpAddress = "172.169.20.10",*/
            //          /* Password = "012345",*/
            //          UserPasswordHashed = "6zCukyxmhfF3it8NtH3IQi8vWLOwbtAZlZbFt+p8tjw="
            //      }
            //  );

            //  modelBuilder.Entity<Administrator>().HasData(
            //      new Administrator
            //      {
            //          UserId = 3,
            //          TeamId = 2,
            //          FirstName = "Hugo",
            //          LastName = "Abric",
            //          UserName = "misterdevops",
            //          Email = "admin@exemple.com",
            //          Token = "",
            //          Points = 0,
            //          Active = false,
            //          UserType = nameof(Administrator),
            //          /* IpAddress = "172.169.20.15",*/
            //          /*Password = "123456789",*/
            //          UserPasswordHashed = "kEoVlKzatiT2IfaoTaJO6ub/d+K79qMW4+Ow72oyndE="
            //      }
            //  );

            return modelBuilder;
        }
    }
}