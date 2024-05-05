using WebScanner.DOMAIN;

namespace WebScanner.StartupBuilder;
/// <summary>
/// 
/// </summary>
public class HttpsBuilderApi
{
    WebApplicationBuilder builder;

    public WebApplicationBuilder Builder { get => builder; set => builder = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builders"></param>
    public HttpsBuilderApi(WebApplicationBuilder builders)
    {
        builder = builders;
    }

    /// <summary>
    /// 
    /// </summary>
    public void buildHTTPS()
    {
        #region ENV

        string WEB_SCANNER_APP_HTTPSPORT = Environment
            .GetEnvironmentVariable("WEB_SCANNER_APP_HTTPSPORT");
        ValidityCheck.VerifyNullValue(WEB_SCANNER_APP_HTTPSPORT);
        int appHttpPort;

        if (!string.IsNullOrEmpty(WEB_SCANNER_APP_HTTPSPORT))
        {
            if (!int.TryParse(WEB_SCANNER_APP_HTTPSPORT, out appHttpPort))
            {
                // La conversion a échoué, gérer l'erreur ou définir une valeur par défaut
                // Par exemple, si vous voulez une valeur par défaut de 0 :
                appHttpPort = 0;
            }
        }
        #endregion

        // HTTPS Redirection
        //builder.Services.AddHttpsRedirection(options =>
        //{
        //    options.HttpsPort = appHttpPort;
        //});
    }
}