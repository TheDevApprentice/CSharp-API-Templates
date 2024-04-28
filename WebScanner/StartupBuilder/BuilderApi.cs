using Microsoft.AspNetCore.CookiePolicy;

namespace WebScanner.StartupBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class BuilderApi
    {
        private WebApplicationBuilder builder;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builders"></param>
        public BuilderApi(WebApplicationBuilder builders)
        {
            builder = builders;
        }

        public WebApplicationBuilder Builder { get => builder; }

        /// <summary>
        /// 
        /// </summary>
        public void BuildBuilder()
        {
            DependencyInjectionBuilder services = new DependencyInjectionBuilder(builder);
            services.buildServices();

            SwaggerBuilderApi swaggerBuilderApi = new SwaggerBuilderApi(services.Builder);
            swaggerBuilderApi.BuildSwaggerGenConfiguration();

            HttpsBuilderApi httpsBuilderApi = new HttpsBuilderApi(swaggerBuilderApi.Builder); // Action is commented inside the class
            httpsBuilderApi.buildHTTPS();

            CorsBuilderApi corsBuilderApi = new CorsBuilderApi(httpsBuilderApi.Builder);
            corsBuilderApi.BuildCors();

            DatabaseApiBuilder databaseBuilderApi = new DatabaseApiBuilder(corsBuilderApi.Builder);
            databaseBuilderApi.BuildDbContext();

            AuthentificationBuilderApi authentificationBuilderApi = new AuthentificationBuilderApi(corsBuilderApi.Builder);
            authentificationBuilderApi.BuildAuthentification();

            AntiForgeryBuilderApi antiForgeryBuilderApi = new AntiForgeryBuilderApi(authentificationBuilderApi.Builder);
            antiForgeryBuilderApi.BuildAntiForgery();

            builder = antiForgeryBuilderApi.Builder;

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.Secure = CookieSecurePolicy.Always;
                options.HttpOnly = HttpOnlyPolicy.Always; 
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }
    }
}