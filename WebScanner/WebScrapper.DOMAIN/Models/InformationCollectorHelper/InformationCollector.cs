using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Helper class for collecting client header information.
    /// </summary>
    public static class InformationCollector
    {
        /// <summary>
        /// Collects header information from the client's HTTP context and request.
        /// </summary>
        /// <param name="HttpContext">The HTTP context of the request.</param>
        /// <param name="Request">The HTTP request.</param>
        /// <param name="returnInformation">Additional return information.</param>
        /// <returns>The collected header information.</returns>
        public static UserRequestHeaderInformation ClientHeaderInformationRecolter(
            HttpContext HttpContext,
            HttpRequest Request,
            out Dictionary<string, object> returnInformation
        )
        {
            // Initialize a new instance of UserRequestHeaderInformation
            UserRequestHeaderInformation informationDictionary = new();

            // If HttpContext is not null, collect connection-related information
            if (HttpContext != null)
            {
                informationDictionary.ConnectionId = HttpContext.Connection.Id;
                informationDictionary.IpRemoteAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                informationDictionary.IpRemotePort = HttpContext.Connection.RemotePort.ToString();
                informationDictionary.IpLocalAddress = HttpContext.Connection.LocalIpAddress?.ToString();
                informationDictionary.ClientCertificate = HttpContext.Connection.ClientCertificate?.ToString();
            }

            // If Request is not null, collect request-related information
            if (Request != null)
            {
                informationDictionary.UserAgent = Request.Headers["User-Agent"].ToString();
                informationDictionary.ContentType = Request.ContentType;
                informationDictionary.Method = Request.Method;
                informationDictionary.Protocol = Request.Protocol;
                informationDictionary.Scheme = Request.Scheme;
                informationDictionary.Host = Request.Host.ToString();
                informationDictionary.Path = Request.Path;
                informationDictionary.QueryString = Request.QueryString.ToString();
                informationDictionary.Referer = Request.Headers["Referer"].ToString();
                informationDictionary.Token = Request.Headers["Authorization"];

                // If the HTTP method is POST, additional data such as form data and request body can be collected
                if (Request.Method == "POST")
                {
                    // Code for collecting form data and request body can be added here
                }
            }

            // Initialize a new dictionary to store return information
            returnInformation = new Dictionary<string, object>
            {
                { "ClientInfo", informationDictionary }
            };

            // Return the collected header information
            return informationDictionary;
        }
    }
}