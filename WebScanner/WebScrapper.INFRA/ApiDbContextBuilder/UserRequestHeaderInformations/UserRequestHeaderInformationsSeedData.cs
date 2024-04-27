using Microsoft.EntityFrameworkCore;

namespace WebScrapper.INFRA
{
    public static class UserRequestHeaderInformationsSeedData
    {
        public static ModelBuilder Seed(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserRequestHeaderInformation>().HasData(
            //              new UserRequestHeaderInformation()
            //              {
            //                  UserRequestHeaderInformationId = 1,
            //                  UserId = 1,
            //                  ConnectionId = "ConnectionId1",
            //                  IpLocalAddress = "127.0.0.1"
            //              },
            //              new UserRequestHeaderInformation()
            //              {
            //                  UserRequestHeaderInformationId = 2,
            //                  UserId = 2,
            //                  ConnectionId = "ConnectionId2",
            //                  IpLocalAddress = "127.0.0.1"

            //              },
            //              new UserRequestHeaderInformation()
            //              {
            //                  UserRequestHeaderInformationId = 3,
            //                  UserId = 3,
            //                  ConnectionId = "ConnectionId3",
            //                  IpLocalAddress = "127.0.0.1",
            //              }
            //          );

            return modelBuilder;
        }
    }
}
