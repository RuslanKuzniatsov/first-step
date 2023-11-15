using Microsoft.EntityFrameworkCore;
using web_first.EfStuff.DbModel;

namespace web_first.EfStuff
{
    public class WebContext : DbContext
    {
        public DbSet<Image> Images { get; set; }



        public WebContext(DbContextOptions options) : base(options)
        {
        }
    }
}
