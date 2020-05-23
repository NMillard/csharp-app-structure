using BookStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataLayer {
    internal class BookStoreContext : DbContext {
        public BookStoreContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreContext).Assembly);
        }
    }
}