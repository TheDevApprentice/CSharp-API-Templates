namespace WebScanner.StartupBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class CorsBuilderApi
    {
        WebApplicationBuilder builder;

        public WebApplicationBuilder Builder { get => builder; set => builder = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builders"></param>
        public CorsBuilderApi(WebApplicationBuilder builders)
        {
            builder = builders;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BuildCors()
        {
            #region ENV

            string WEB_SCANNER_APP_USECORS_POLICYNAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_USECORS_POLICYNAME");
            if (WEB_SCANNER_APP_USECORS_POLICYNAME == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_ADDCORS_POLICYNAME2 = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_ADDCORS_POLICYNAME2");
            if (WEB_SCANNER_APP_ADDCORS_POLICYNAME2 == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_ADDCORS_WITHMETHOD_PARAMS1 = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_ADDCORS_WITHMETHOD_PARAMS1");
            if (WEB_SCANNER_APP_ADDCORS_WITHMETHOD_PARAMS1 == null) { throw new Exception("NullValue"); }
            else
            {
            }
            string WEB_SCANNER_APP_ADDCORS_POLICYNAME2_PARAMS2 = Environment
                .GetEnvironmentVariable("WEB_SCANNER_APP_ADDCORS_POLICYNAME2_PARAMS2");
            if (WEB_SCANNER_APP_ADDCORS_POLICYNAME2_PARAMS2 == null) { throw new Exception("NullValue"); }
            else
            {
            }
            #endregion

            // CORS Configuration
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(WEB_SCANNER_APP_USECORS_POLICYNAME, builder =>
                {
                    builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
                //options.AddPolicy(WEB_SCANNER_APP_ADDCORS_POLICYNAME2,
                //    builder =>
                //    builder.AllowAnyOrigin()
                //    .WithMethods(WEB_SCANNER_APP_ADDCORS_WITHMETHOD_PARAMS1, WEB_SCANNER_APP_ADDCORS_POLICYNAME2_PARAMS2)
                //    .AllowAnyHeader());
            });

        }
    }
}