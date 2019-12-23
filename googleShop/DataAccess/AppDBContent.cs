using Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCartItem> ShopCourseItems { get; set; }
        public DbSet<FileModel> Files { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDitail> OrderDitails { get; set; }

        public DbSet<AvatarFileModel> AvatarFiles { get; set; }
    }
}
