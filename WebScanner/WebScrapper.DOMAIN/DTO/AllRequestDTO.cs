using Newtonsoft.Json;
using NJsonSchema.NewtonsoftJson.Converters;

namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <returns></returns>
    /// 
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// 
    [JsonConverter(typeof(JsonInheritanceConverter), "type")]
    public class AllRequestDTO
    {
        public string Token { get; set; } = "";
        public string Cookie { get; set; } = "";

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <returns></returns>
        /// 
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        public AllRequestDTO()
        {
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <returns></returns>
        /// 
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        public AllRequestDTO(
            string token
        )
        {
            Token = token;
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <returns></returns>
        /// 
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        public AllRequestDTO(
            string token,
            string cookie
        )
        {
            Token = token;
            Cookie = cookie;
        }
    }
}
