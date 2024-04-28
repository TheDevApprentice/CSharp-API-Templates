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
    public class EncryptedTokenFromCookieDTO
    {
        public string EncryptedToken { get; set; } = "";
    }
}
