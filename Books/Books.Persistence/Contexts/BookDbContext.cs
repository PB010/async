using Books.Persistence.EntityConfiguration;
using Books.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Persistence.Contexts
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
        :base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
