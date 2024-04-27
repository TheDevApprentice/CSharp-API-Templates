using Microsoft.AspNetCore.Antiforgery;

namespace WebScanner.StartupBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class AppApi
    {
        private WebApplication app;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apps"></param>
        public AppApi(WebApplication apps)
        {
            app = apps;
        }

        public WebApplication App { get => app; set => app = value; }

        /// <summary>
        /// 
        /// </summary>
        public void Build()
        {
            #region IsDevelopment
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                #region ENV

                string WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_NAME = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_NAME");
                if (WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_NAME == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_AREANAME = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_AREANAME");
                if (WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_AREANAME == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_PATTERN = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_PATTERN");
                if (WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_PATTERN == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_CONTROLLER = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_CONTROLLER");
                if (WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_CONTROLLER == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_ACTION = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_ACTION");
                if (WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_ACTION == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string WEB_SCANNER_USE_SWAGGER_ROUTETEMPLATE = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_ROUTETEMPLATE");
                if (WEB_SCANNER_USE_SWAGGER_ROUTETEMPLATE == null) { throw new Exception("NullValue"); }
                else
                {
                }
                bool serializeAsV2 = false;
                string WEB_SCANNER_USE_SWAGGER_SERIALIZEASV2 = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_SERIALIZEASV2");
                if (WEB_SCANNER_USE_SWAGGER_SERIALIZEASV2 == null) { throw new Exception("NullValue"); }
                else
                {
                }
                if (!string.IsNullOrEmpty(WEB_SCANNER_USE_SWAGGER_SERIALIZEASV2))
                {
                    if (!bool.TryParse(WEB_SCANNER_USE_SWAGGER_SERIALIZEASV2, out serializeAsV2))
                    {
                        serializeAsV2 = false;
                    }
                }

                string WEB_SCANNER_USE_SWAGGER_UI_ROUTEPREFIX = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_ROUTEPREFIX");
                if (WEB_SCANNER_USE_SWAGGER_UI_ROUTEPREFIX == null) { throw new Exception("NullValue"); }
                else {
                }
                string WEB_SCANNER_USE_SWAGGER_UI_DOCUMENTTITLE = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_DOCUMENTTITLE");
                if (WEB_SCANNER_USE_SWAGGER_UI_DOCUMENTTITLE == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL");
                if (WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME");
                if (WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME == null) { throw new Exception("NullValue"); }
                else
                {
                }

                #endregion

                app.UseOpenApi();
                app.UseWebSockets();
                //app.UseDeveloperExceptionPage();
                app.MapAreaControllerRoute(
                    name: WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_NAME,
                    areaName: WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_AREANAME,
                    pattern: WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_PATTERN, // #spell-check-ignore-line
                    defaults: new { controller = WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_CONTROLLER, action = WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_ACTION });

                app.UseSwagger(options =>
                {
                    options.RouteTemplate = WEB_SCANNER_USE_SWAGGER_ROUTETEMPLATE;
                    options.SerializeAsV2 = serializeAsV2;
                });

                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = WEB_SCANNER_USE_SWAGGER_UI_ROUTEPREFIX;
                    c.DocumentTitle = WEB_SCANNER_USE_SWAGGER_UI_DOCUMENTTITLE;
                    c.SwaggerEndpoint(
                        WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL,
                        WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME);
                });

                //WelcomePage
                //app.UseWelcomePage();
            }
            #endregion

            #region Production
            else
            {
                //app.UseExceptionHandler("/Home/Error");
            }
            #endregion

            #region Routing
            app.UseHttpsRedirection();
            app.UseHttpLogging();
            app.UseRouting();
            #endregion

            #region Cors
            string WEB_SCANNER_APP_USECORS_POLICYNAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_USECORS_POLICYNAME");
            if (WEB_SCANNER_APP_USECORS_POLICYNAME == null) { throw new Exception("NullValue"); }
            else
            {
            }
            app.UseCors(WEB_SCANNER_APP_USECORS_POLICYNAME);
            #endregion

            #region Auth
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion

            #region Anti forgery
            // https://learn.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-8.0

            var antiforgery = app.Services.GetRequiredService<IAntiforgery>();
            app.Use((context, next) =>
            {
                var requestPath = context.Request.Path.Value;

                if (string.Equals(requestPath, "/", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(requestPath, "/index.html", StringComparison.OrdinalIgnoreCase))
                {
                    var tokenSet = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("\"XSRF-TOKEN\"", tokenSet.RequestToken!,
                        new CookieOptions { HttpOnly = false });
                }

                return next(context);
            });

            //app.UseHealthChecks("/healthz");

            app.MapGet("antiforgery/token", (IAntiforgery forgeryService, HttpContext context) =>
            {
                var tokens = forgeryService.GetAndStoreTokens(context);
                context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!,
                        new CookieOptions { HttpOnly = false });

                return Results.Ok();
            }).RequireAuthorization();
            #endregion

            #region Controllers
            app.MapControllers();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion
        }
    }
}
