using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Api
{
    /// <summary>
    /// Represent the entry point class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the project
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create the host builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
