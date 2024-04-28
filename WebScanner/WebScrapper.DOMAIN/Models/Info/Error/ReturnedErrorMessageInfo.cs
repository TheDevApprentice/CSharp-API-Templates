namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents information about a returned error message.
    /// </summary>
    public class ReturnedErrorMessageInfo
    {
        /// <summary>
        /// Gets or sets the title of the error message.
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// Gets or sets the type of the error message.
        /// </summary>
        public string Type { get; set; } = "Error";

        /// <summary>
        /// Gets or sets the error message content.
        /// </summary>
        public string ErrorMessage { get; set; } = "";

        /// <summary>
        /// Initializes a new instance of the ReturnedErrorMessageInfo class with specified title and error message.
        /// </summary>
        /// <param name="title">The title of the error message.</param>
        /// <param name="error">The error message content.</param>
        public ReturnedErrorMessageInfo(string title, string error)
        {
            Title = title;
            ErrorMessage = error;
        }
    }
}