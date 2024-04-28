namespace WebScrapper.DOMAIN.DTO
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
    public class LoginDTO : UserDTO
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";

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
        public LoginDTO(
            string token,
            string username,
            string password,
            string cookie = ""
        ) : base(token, cookie)
        {
            Token = token;
            Cookie = cookie;
            UserName = username;
            Password = password;
        }
    }
}