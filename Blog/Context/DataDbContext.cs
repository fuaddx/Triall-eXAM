using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options){}
        public DbSet<Slider>Sliders { get; set; }
        public DbSet<Image>Image {  get; set; }
        
    }
}
