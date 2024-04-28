using Microsoft.AspNetCore.Mvc;
using YamlDotNet.Core.Tokens;

namespace WebScanner.StartupBuilder
{
    public class AntiForgeryBuilderApi
    {
        WebApplicationBuilder builder;

        public WebApplicationBuilder Builder { get => builder; set => builder = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builders"></param>
        public AntiForgeryBuilderApi(WebApplicationBuilder builders)
        {
            builder = builders;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BuildAntiForgery()
        {
            #region ENV

            string WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_FORMFIELDNAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_FORMFIELDNAME");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_FORMFIELDNAME);

            string WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_XCSRFTOKENHEADERNAME = Environment
                .GetEnvironmentVariable("WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_XCSRFTOKENHEADERNAME");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_XCSRFTOKENHEADERNAME);

            string WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_SUPRESSXFRAMEOPTIONHEADER = Environment
                .GetEnvironmentVariable("WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_SUPRESSXFRAMEOPTIONHEADER");
            ValidityCheck.VerifyNullValue(WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_SUPRESSXFRAMEOPTIONHEADER); 
           
            bool suppressXFrameOptionsHeader = false;
            if (!string.IsNullOrEmpty(WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_SUPRESSXFRAMEOPTIONHEADER))
            {
                if (!bool.TryParse(WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_SUPRESSXFRAMEOPTIONHEADER, out suppressXFrameOptionsHeader))
                {
                    suppressXFrameOptionsHeader = false;
                }
            }

            #endregion

            // Anti-Forgery
            // https://learn.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-7.0

            builder.Services.AddAntiforgery(options =>
            {
                // Set Cookie properties using CookieBuilder properties
                options.FormFieldName = WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_FORMFIELDNAME;
                options.HeaderName = WEB_SCANNER_ANTI_FORGERY_BUILDER_ADDANTIFORGERY_XCSRFTOKENHEADERNAME;
                options.SuppressXFrameOptionsHeader = suppressXFrameOptionsHeader;
            });
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
        }
    }
}
