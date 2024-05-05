using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using WebScanner.DOMAIN;
using WebScrapper.DOMAIN;
using static System.Net.WebRequestMethods;

namespace WebScanner.StartupBuilder
{
    public class AuthentificationBuilderApi
    {
        WebApplicationBuilder builder;

        public WebApplicationBuilder Builder { get => builder; set => builder = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builders"></param>
        public AuthentificationBuilderApi(WebApplicationBuilder builders)
        {
            builder = builders;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BuildAuthentification()
        {
            #region ENV

            var jwtIssuer = Environment
                .GetEnvironmentVariable("JWT_ISSUER");
            ValidityCheck.VerifyNullValue(jwtIssuer);
            var jwtAudience = Environment
                .GetEnvironmentVariable("JWT_AUDIENCE");
            ValidityCheck.VerifyNullValue(jwtAudience);
            var jwtKey = Environment
                .GetEnvironmentVariable("JWT_KEY");
            ValidityCheck.VerifyNullValue(jwtKey);

            #endregion

            // Configuration de l'authentification JWT

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        //Choose the authentification method you desire for your api.

                        /// https://www.keycloak.org
                        /// https://www.keycloak.org/documentation
                        #region Keycloak JWT Authentification 

                        // Keycloak JWT Authentification 

                        //options.Authority = "http://localhost:8080/auth/realms/myapp";
                        //options.MetadataAddress = "http://localhost:8080/auth/realms/myapp/.well-known/openid-configuration";
                        //options.RequireHttpsMetadata = true;

                        //options.TokenValidationParameters = new TokenValidationParameters
                        //{
                        //    NameClaimType = ClaimTypes.Name,
                        //    RoleClaimType = ClaimTypes.Role,
                        //    ValidateIssuer = true,
                        //    ValidateAudience = true,
                        //    ValidateLifetime = true,
                        //    ValidateIssuerSigningKey = true,
                        //    ValidIssuer = jwtIssuer,
                        //    ValidAudience = jwtAudience,
                        //    ValidIssuers = new[] { "http://localhost:8080/auth/realms/myapp" },
                        //    ValidAudiences = new[] { "frontend", "mobile", "swagger", },

                        //    IssuerSigningKey = new SymmetricSecurityKey(
                        //Encoding.UTF8.GetBytes(jwtKey))
                        //};

                        #endregion

                        #region C# Custom JWT Authentification 

                        // Configuring JWT authentication with custom role-based claims handling

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtIssuer,
                            ValidAudience = jwtAudience,

                            IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtKey))
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnTokenValidated = context =>
                            {
                                var userService = context.HttpContext.RequestServices
                                    .GetRequiredService<IRoleService>();

                                var userId = context.Principal.Identity.Name;

                                var userRoles = userService
                                    .GetUserRoles();

                                var claims = new List<Claim>();

                                foreach (var role in userRoles)
                                {
                                    claims
                                        .Add(new Claim(ClaimTypes.Name, role.Name));

                                    claims
                                        .Add(new Claim(ClaimTypes.Role, role.Name));
                                }

                                var appIdentity = new ClaimsIdentity(claims);
                                context.Principal
                            .AddIdentity(appIdentity);

                                return Task.CompletedTask;
                            }
                        };

                        #endregion

                    });

            builder.Services.AddAuthorization();

            builder.Services.AddDataProtection();
        }
    }
}