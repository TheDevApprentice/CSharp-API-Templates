namespace WebScrapper.DOMAIN
{
    public class ReturnedErrorMessageInfo
    {
        public string Title { get; set; } = "";
        public string Type { get; set; } = "Error";
        public string ErrorMessage { get; set; } = "";

        public ReturnedErrorMessageInfo(string title, string error)
        {
            Title = title;
            ErrorMessage = error;
        }
    }
}
