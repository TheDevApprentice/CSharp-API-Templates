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
    public class GuestDTO : UserDTO
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
        public GuestDTO(
            string token
        ) : base(token)
        {
            Token = token;
        }
    }
}