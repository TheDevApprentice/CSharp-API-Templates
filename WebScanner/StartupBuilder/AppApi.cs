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
                ValidityCheck.VerifyNullValue(WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_NAME);
                string WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_AREANAME = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_AREANAME");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_AREANAME);
                string WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_PATTERN = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_PATTERN");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_PATTERN);
                string WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_CONTROLLER = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_CONTROLLER");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_CONTROLLER);
                string WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_ACTION = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_ACTION");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_MAP_AREA_CONTROLLER_ROUTE_DEFAULTS_ACTION);
                string WEB_SCANNER_USE_SWAGGER_ROUTETEMPLATE = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_ROUTETEMPLATE");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_USE_SWAGGER_ROUTETEMPLATE);
                bool serializeAsV2 = false;
                string WEB_SCANNER_USE_SWAGGER_SERIALIZEASV2 = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_SERIALIZEASV2");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_USE_SWAGGER_SERIALIZEASV2);
                if (!string.IsNullOrEmpty(WEB_SCANNER_USE_SWAGGER_SERIALIZEASV2))
                {
                    if (!bool.TryParse(WEB_SCANNER_USE_SWAGGER_SERIALIZEASV2, out serializeAsV2))
                    {
                        serializeAsV2 = false;
                    }
                }

                string WEB_SCANNER_USE_SWAGGER_UI_ROUTEPREFIX = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_ROUTEPREFIX");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_USE_SWAGGER_UI_ROUTEPREFIX);
                string WEB_SCANNER_USE_SWAGGER_UI_DOCUMENTTITLE = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_DOCUMENTTITLE");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_USE_SWAGGER_UI_DOCUMENTTITLE);
                string WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL = Environment

                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL);
                string WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME);

                string WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL_V2 = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL_V2");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL_V2);
                string WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME_V2 = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME_V2");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME_V2);

                string WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL_V3 = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL_V3");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL_V3);
                string WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME_V3 = Environment
                    .GetEnvironmentVariable("WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME_V3");
                ValidityCheck.VerifyNullValue(WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME_V3);

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

                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = WEB_SCANNER_USE_SWAGGER_UI_ROUTEPREFIX;
                    c.DocumentTitle = WEB_SCANNER_USE_SWAGGER_UI_DOCUMENTTITLE;
                    c.SwaggerEndpoint(
                        WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL_V2,
                        WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME_V2);
                });

                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = WEB_SCANNER_USE_SWAGGER_UI_ROUTEPREFIX;
                    c.DocumentTitle = WEB_SCANNER_USE_SWAGGER_UI_DOCUMENTTITLE;
                    c.SwaggerEndpoint(
                        WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_URL_V3,
                        WEB_SCANNER_USE_SWAGGER_UI_SWAGGERENDPOINT_NAME_V3);
                });
                //WelcomePage
                //app.UseWelcomePage();
            }
            #endregion

            #region Production
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
            ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_USECORS_POLICYNAME);
            app.UseCors(WEB_SCANNER_APP_USECORS_POLICYNAME);
            #endregion

            #region Auth
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion

            app.UseCookiePolicy();

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