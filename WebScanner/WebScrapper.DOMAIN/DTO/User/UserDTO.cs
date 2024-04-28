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
    public class UserDTO : AllRequestDTO
    {
        public string UserName { get; set; } = "";


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
        public UserDTO()
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
        public UserDTO(
            string token
        ) : base(token)
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
        public UserDTO(
            string token,
            string cookie
        ) : base(token, cookie)
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
        public UserDTO(
            string token,
            string cookie,
            string username
        ) : base(token, cookie)
        {
            UserName = username;
        }
    }
}
