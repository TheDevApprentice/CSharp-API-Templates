using DotNetEnv;
using WebScanner.StartupBuilder;

namespace WebScanner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string value = Environment
            .GetEnvironmentVariable("env");

            Env.Load();

            BuilderApi builderApi = new BuilderApi(builder);
            builderApi.BuildBuilder();

            var appToRun = builderApi.Builder.Build();

            AppApi app = new AppApi(appToRun);
            app.Build();

            app.App.Run();
        }
    }
}