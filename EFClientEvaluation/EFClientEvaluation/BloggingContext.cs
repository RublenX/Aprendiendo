using Microsoft.EntityFrameworkCore;

namespace EFClientEvaluation
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasData(
                    new Blog { BlogId = 1, Url = @"https://devblogs.microsoft.com/dotnet", Rating = 5, DeleteDateTime = null },
                    new Blog { BlogId = 2, Url = @"https://mytravelblog.com/", Rating = 4, DeleteDateTime = new System.DateTime(2010, 11, 16, 21, 59, 36) });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=EFQuerying.ClientEvaluation;Trusted_Connection=True");
        }
    }
}
