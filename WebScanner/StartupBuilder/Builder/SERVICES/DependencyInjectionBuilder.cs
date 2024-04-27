using WebScrapper.DOMAIN;
using WebScrapper.INFRA;

namespace WebScanner.StartupBuilder
{
    /// <summary>
    /// This class is use to configure your dependency injection across your application
    /// </summary>
    public class DependencyInjectionBuilder
    {
        WebApplicationBuilder builder;

        public WebApplicationBuilder Builder { get => builder; set => builder = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builders"></param>
        public DependencyInjectionBuilder(WebApplicationBuilder builders)
        {
            builder = builders;
        }

        /// <summary>
        /// Utilisation de l'injection de dépendance
        /// </summary>
        public void buildServices()
        {
            //builder.Services.AddSingleton<IWebHostEnvironment>(new FunctionHostingEnvironment());

            // Add services to the container.
            builder.Services.AddControllers();

            // Enregistrement des services

            builder.Services
                .AddTransient<IRoleService, RoleService>();

            builder.Services
                .AddTransient<IUserService, UserService>();

            //builder.Services
            //    .AddTransient<IChallengeService, ChallengeService>();

            //builder.Services
            //    .AddTransient<ITeamService, TeamService>();

            // Enregistrement des d�p�ts

            builder.Services
                .AddTransient<IRoleRepo, RoleRepo>();

            builder.Services
                .AddScoped<IUserRepo, UserRepo>();

            //builder.Services
            //    .AddTransient<IChallengeRepo, ChallengeRepo>();

            //builder.Services
            //    .AddTransient<ITeamRepo, TeamRepo>();
        }
    }
}
