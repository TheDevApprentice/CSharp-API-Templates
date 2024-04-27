using Microsoft.AspNetCore.Http;

namespace WebScrapper.DOMAIN
{
    public static class InformationCollector
    {
        public static UserRequestHeaderInformation ClientHeaderInformationRecolter(
            HttpContext HttpContext,
            HttpRequest Request,
            out Dictionary<string, object> returnInformation
        )
        {
            UserRequestHeaderInformation informationDictionary = new();

            if (HttpContext != null)
            {
                informationDictionary.ConnectionId = HttpContext.Connection.Id;
                informationDictionary.IpRemoteAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                informationDictionary.IpRemotePort = HttpContext.Connection.RemotePort.ToString();
                informationDictionary.IpLocalAddress = HttpContext.Connection.LocalIpAddress?.ToString();
                informationDictionary.ClientCertificate = HttpContext.Connection.ClientCertificate?.ToString();
            }
            if (Request != null)
            {
                informationDictionary.UserAgent = Request.Headers["User-Agent"].ToString();
                informationDictionary.ContentType = Request.ContentType;
                informationDictionary.Method = Request.Method;
                informationDictionary.Protocol = Request.Protocol;
                informationDictionary.Scheme = Request.Scheme;
                //informationDictionary.Body = Request.Body; 
                //informationDictionary.BodyReader = Request.BodyReader;
                informationDictionary.Host = Request.Host.ToString();
                informationDictionary.Path = Request.Path;
                informationDictionary.QueryString = Request.QueryString.ToString();
                informationDictionary.Referer = Request.Headers["Referer"].ToString();
                informationDictionary.Token = Request.Headers["Authorization"]; // Ajoutez la logique pour récupérer le token si nécessaire


                // Si la méthode HTTP est POST, collecte des données de formulaire et du corps de la requête
                if (Request.Method == "POST")
                {
                    //informationDictionary.FormData.Fields = new Dictionary<string, string>();
                    //foreach (var formData in Request.Form)
                    //{
                    //    informationDictionary.FormData.Fields.Add(formData.Key, formData.Value.ToString());
                    //}

                    //// Lecture du corps de la requête
                    //using (StreamReader reader = new StreamReader(Request.Body))
                    //{
                    //    informationDictionary.RequestBody = reader.ReadToEnd();
                    //}
                }
            }

            //// Collecte des en-têtes de la requête
            //informationDictionary.Headers = new Dictionary<string, string>();
            //foreach (var header in Request.Headers)
            //{
            //    informationDictionary.Headers.Add(header.Key, header.Value.ToString());
            //}

            //// Collecte des paramètres de la requête
            //informationDictionary.QueryParameters = new Dictionary<string, string>();
            //foreach (var queryParameter in Request.Query)
            //{
            //    informationDictionary.QueryParameters.Add(queryParameter.Key, queryParameter.Value.ToString());
            //}


            returnInformation = new Dictionary<string, object>
            {
                { "ClientInfo", informationDictionary }
            };


            return informationDictionary;
        }
    }
}
