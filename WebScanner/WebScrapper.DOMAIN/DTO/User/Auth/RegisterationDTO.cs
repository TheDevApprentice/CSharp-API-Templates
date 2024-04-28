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
    public class RegisterationDTO : UserDTO
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string PasswordVerification { get; set; } = "";

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
        public RegisterationDTO(
            string token,
            string cookie,
            string firstName,
            string lastname,
            string username,
            string email,
            string password,
            string passwordVerification
        ) : base(token, cookie, username)
        {
            Token = token;
            Cookie = cookie;
            FirstName = firstName;
            LastName = lastname;
            UserName = username;
            Email = email;
            Password = password;
            PasswordVerification = passwordVerification;
        }
    }
}
