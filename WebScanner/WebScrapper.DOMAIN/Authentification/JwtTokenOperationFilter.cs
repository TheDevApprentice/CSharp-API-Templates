using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebScrapper.DOMAIN
{
    public class JwtTokenOperationFilter : IOperationFilter
    {
        public void Apply(
            OpenApiOperation operation,
            OperationFilterContext context
        )
        {
            #region ENV

            string WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYREQUIREMENT_ID = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYREQUIREMENT_ID");
            if (WEB_SCANNER_APP_SWAGGERDOC_ADDSERCURITYREQUIREMENT_ID == null) { throw new Exception("NullValue"); }
            else
            {
            }

            #endregion

            var authAttributes = context.MethodInfo.DeclaringType
                                .GetCustomAttributes(true)
                                .Union(context.MethodInfo
                                .GetCustomAttributes(true))
                                .OfType<AuthorizeAttribute>();

            if (authAttributes.Any())
            {
                operation.Responses
                    .Add(
                        "401",
                        new OpenApiResponse
                        {

                            Description = "Unauthorized"

                        });

                operation.Responses
                    .Add(
                        "403",
                        new OpenApiResponse
                        {

                            Description = "Forbidden"

                        });

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
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
                        }
                    }
                };
            }
        }
    }

}
