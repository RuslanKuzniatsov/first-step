using Microsoft.EntityFrameworkCore;
using web_first.EfStuff.DbModel;

namespace web_first.EfStuff
{
    public class WebContext : DbContext
    {
        public DbSet<Image> Images { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<ImageComment> ImageComments { get; set; }

        public WebContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasMany(image => image.Comments)
                .WithOne(comment => comment.Image);




            base.OnModelCreating(modelBuilder);
        }
    }
}
