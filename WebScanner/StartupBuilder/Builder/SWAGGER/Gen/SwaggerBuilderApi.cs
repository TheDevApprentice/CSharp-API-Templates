﻿using Microsoft.OpenApi.Models;
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
            if (WEB_SCANNER_APP_SWAGGERDOC_VERSION == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_TITLE = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_TITLE");
            if (WEB_SCANNER_APP_SWAGGERDOC_TITLE == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_DESCRIPTION = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_DESCRIPTION");
            if (WEB_SCANNER_APP_SWAGGERDOC_DESCRIPTION == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_TERMOFSERVICE_URL = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_TERMOFSERVICE_URL");
            if (WEB_SCANNER_APP_SWAGGERDOC_TERMOFSERVICE_URL == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_CONTACT_NAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_CONTACT_NAME");
            if (WEB_SCANNER_APP_SWAGGERDOC_CONTACT_NAME == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_CONTACT_URL = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_CONTACT_URL");
            if (WEB_SCANNER_APP_SWAGGERDOC_CONTACT_URL == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_LICENCE_NAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_LICENCE_NAME");
            if (WEB_SCANNER_APP_SWAGGERDOC_LICENCE_NAME == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_LICENCE_URL = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_LICENCE_URL");
            if (WEB_SCANNER_APP_SWAGGERDOC_LICENCE_URL == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_NAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_NAME");
            if (WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_NAME == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_DESCRIPTION = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_DESCRIPTION");
            if (WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_DESCRIPTION == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_NAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_NAME");

            if (WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_NAME == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_SHEME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_SHEME");
            if (WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYDEFINITION_SHEME_SHEME == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYREQUIREMENT_ID = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYREQUIREMENT_ID");
            if (WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYREQUIREMENT_ID == null) { throw new Exception("NullValue"); }
            else
            {
            }
            #endregion

            // Swagger/OpenAPI Configuration
            builder.Services.AddEndpointsApiExplorer();

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
                                 }
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
                c.SelectSubTypesUsing(t =>
                {
                    if (t.IsInterface)
                    {
                        return t.GetInterfaces();
                    }
                    return Enumerable.Empty<Type>();
                });

                c.UseInlineDefinitionsForEnums();
                c.UseOneOfForPolymorphism();
                c.UseAllOfToExtendReferenceSchemas();
                c.SupportNonNullableReferenceTypes();

                // Enable XML comments
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), true);
                c.DescribeAllParametersInCamelCase();
            });
        }
    }
}