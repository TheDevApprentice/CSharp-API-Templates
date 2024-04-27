namespace WebScanner.StartupBuilder.Builder.SERVERS
{
    public class ServerBuilder
    {
        WebApplicationBuilder builder;

        public WebApplicationBuilder Builder { get => builder; set => builder = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builders"></param>
        public ServerBuilder(WebApplicationBuilder builders)
        {
            builder = builders;
        }

        /// <summary>
        /// 
        /// </summary>
        public void buildServices()
        {

        }
    }
}
