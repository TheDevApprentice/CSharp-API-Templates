namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
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
    public class AdministratorDTO : UserDTO
    {
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <returns>Return a TodoItem.</returns>
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
        public AdministratorDTO()
        {
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <returns>Return a TodoItem.</returns>
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
        public AdministratorDTO(
            string token,
            string cookie
        ) : base(token, cookie)
        {
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <returns>Return a TodoItem.</returns>
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
        public AdministratorDTO(
            string token,
            string cookie,
            string username
        ) : base(token, cookie, username)
        {
        }
    }
}