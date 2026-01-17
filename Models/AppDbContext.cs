using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CitrusMicroblog.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<NewsTopic> topics { get; set; }
        public DbSet<FormMessage> messages { get; set; }
    }
}
