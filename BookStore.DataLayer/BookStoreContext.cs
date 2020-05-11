using BookStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataLayer {
    public class BookStoreContext : DbContext {
        internal BookStoreContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreContext).Assembly);
        }
    }
}