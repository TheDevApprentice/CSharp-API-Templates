using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebScrapper.DOMAIN;

namespace WebScanner.StartupBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerBuilderApi
    {
        private WebApplicationBuilder builder;
        private WebApplication app;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builders"></param>
        public SwaggerBuilderApi(WebApplicationBuilder builders)
        {
            builder = builders;
        }

        public WebApplicationBuilder Builder { get => builder; }
        public WebApplication App { get => app; set => app = value; }

        /// <summary>
        /// 
        /// </summary>
        public void BuildSwaggerGenConfiguration()
        {
            #region ENV

            string WEB_SCANNER_APP_SWAGGERDOC_VERSION = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_VERSION");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_VERSION);
            string WEB_SCANNER_APP_SWAGGERDOC_TITLE = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_TITLE");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_TITLE);
            string WEB_SCANNER_APP_SWAGGERDOC_DESCRIPTION = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_DESCRIPTION");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_DESCRIPTION);
            string WEB_SCANNER_APP_SWAGGERDOC_TERMOFSERVICE_URL = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_TERMOFSERVICE_URL");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_TERMOFSERVICE_URL);
            string WEB_SCANNER_APP_SWAGGERDOC_CONTACT_NAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_CONTACT_NAME");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_CONTACT_NAME);
            string WEB_SCANNER_APP_SWAGGERDOC_CONTACT_URL = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_CONTACT_URL");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_CONTACT_URL);
            string WEB_SCANNER_APP_SWAGGERDOC_LICENCE_NAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_LICENCE_NAME");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_LICENCE_NAME);
            string WEB_SCANNER_APP_SWAGGERDOC_LICENCE_URL = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_LICENCE_URL");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_LICENCE_URL);
            string WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_NAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_NAME");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_NAME);
            string WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_DESCRIPTION = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_DESCRIPTION");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_DESCRIPTION);
            string WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_NAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_NAME");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_NAME);
            string WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_SHEME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_SHEME");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_SHEME);
            string WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYREQUIREMENT_ID = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYREQUIREMENT_ID");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYREQUIREMENT_ID);
            #endregion

            // Swagger/OpenAPI Configuration
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                 "v3", 
                 new OpenApiInfo 
                 {
                     Title = "My API",
                     Version = "v3",
                     Description = "API Description",
                     TermsOfService = new Uri("https://example.com/terms"),
                     Contact = new OpenApiContact
                     {
                         Name = "John Doe",
                         Email = "john.doe@example.com",
                         Url = new Uri("https://example.com")
                     },
                     License = new OpenApiLicense
                     {
                         Name = "MIT License",
                         Url = new Uri("https://opensource.org/licenses/MIT")
                     },
                     //Extensions = new Dictionary<string, IOpenApiExtension>
                     //{
                     //   {
                     //        "x-my-extension",
                     //        new MyCustomExtension()
                     //   }
                     //}
                 });

                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    Description = "Basic authentication header"
                });

                c.AddSecurityDefinition("apiKey", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "API Key authentication header"
                });

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://example.com/oauth2/authorize"),
                            Scopes = new Dictionary<string, string>
                        {
                            { "read", "Lire les données" },
                            { "write", "Ecrire les données" }
                        }
                        }
                    }
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basicAuth"
                            }
                        },
                        new string[] {}
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "apiKey"
                            }
                        },
                        new string[] {}
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            }
                        },
                        new[] { "read", "write" }
                    }
                });
            });

            //builder.Services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API", Version = "v2" });

            //    c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
            //    {
            //        Type = SecuritySchemeType.Http,
            //        Scheme = "basic",
            //        Description = "Basic authentication header"
            //    });

            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "basicAuth"
            //                }
            //            },
            //            new string[] {}
            //        }
            //    });
            //});

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(WEB_SCANNER_APP_SWAGGERDOC_VERSION,
                             new OpenApiInfo
                             {
                                 Title = WEB_SCANNER_APP_SWAGGERDOC_TITLE,
                                 Version = WEB_SCANNER_APP_SWAGGERDOC_VERSION,
                                 Description = WEB_SCANNER_APP_SWAGGERDOC_DESCRIPTION,
                                 TermsOfService = new Uri(WEB_SCANNER_APP_SWAGGERDOC_TERMOFSERVICE_URL),
                                 Contact = new OpenApiContact
                                 {
                                     Name = WEB_SCANNER_APP_SWAGGERDOC_CONTACT_NAME,
                                     Url = new Uri(WEB_SCANNER_APP_SWAGGERDOC_CONTACT_URL)
                                 },
                                 License = new OpenApiLicense
                                 {
                                     Name = WEB_SCANNER_APP_SWAGGERDOC_LICENCE_NAME,
                                     Url = new Uri(WEB_SCANNER_APP_SWAGGERDOC_LICENCE_URL)
                                 }, 
                             });
                c.AddSecurityDefinition(
                 WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_NAME,
                 new OpenApiSecurityScheme
                 {
                     Description = WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_DESCRIPTION + ". Example: \"{token}\"",
                     Name = WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_NAME,
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.Http,
                     Scheme = WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_SHEME
                     //BearerFormat="
                 });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                                {
                                    {
                                        new OpenApiSecurityScheme
                                        {
                                            Reference = new OpenApiReference
                                            {
                                                Type = ReferenceType.SecurityScheme,
                                                Id = WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYREQUIREMENT_ID
                                            }
                                        },
                                        new List<string>()
                                }});

                c.OperationFilter<JwtTokenOperationFilter>();

                //c.AddServer(new OpenApiServer
                //{
                //    Url = "{protocol}://{hostpath}",
                //    Variables = new Dictionary<string, OpenApiServerVariable>
                //        {
                //            { "protocol", new OpenApiServerVariable { Default = "http", Enum = new List<string> { "http", "https" } } },
                //            { "hostpath", new OpenApiServerVariable { Default = "localhost:8787" } }
                //        }
                //});

                c.UseOneOfForPolymorphism();
                c.UseAllOfForInheritance();
                c.UseInlineDefinitionsForEnums();
                c.UseOneOfForPolymorphism();
                c.UseAllOfToExtendReferenceSchemas();
                c.SupportNonNullableReferenceTypes();
                c.SelectSubTypesUsing(t =>
                {
                    if (t.IsInterface)
                    {
                        return t.GetInterfaces();
                    }
                    return Enumerable.Empty<Type>();
                });

                // Enable XML comments
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), true);
                c.DescribeAllParametersInCamelCase();
            });
        }
    }
}