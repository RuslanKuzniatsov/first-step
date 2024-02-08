using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using web_first.EfStuff.DbModel;
using web_first.EfStuff.Repositores;

namespace web_first.EfStuff
{
    public static class ExtentionSeed
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {

                SeedImage(scope);
            }
            return host;
        }


        private static void SeedImage(IServiceScope scope)
        {
            var imageRepository = scope.ServiceProvider.GetService<ImageRepository>();


            if (!imageRepository.Any())
            {
                var image = new Image()
                {
                    Name = "qwe",
                    Url = "qwe",
                    Rate = 99
                };
                imageRepository.Save(image);
            }
        }
    }
}
