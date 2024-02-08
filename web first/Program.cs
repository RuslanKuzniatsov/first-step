using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Hosting;

using web_first.EfStuff;


namespace web_first
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            CreateHostBuilder(args).Build().Seed().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        

        

        
    }
}
