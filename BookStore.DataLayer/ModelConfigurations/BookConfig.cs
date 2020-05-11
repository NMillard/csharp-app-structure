using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataLayer.ModelConfigurations {
    public class BookConfig : IEntityTypeConfiguration<Book> {
        private const string BookPrimaryKeyName = "id";
        
        public void Configure(EntityTypeBuilder<Book> builder) {
            builder.ToTable("Books");

            builder.Property(BookPrimaryKeyName);
            builder.HasKey(BookPrimaryKeyName);

            builder.Property(book => book.Title)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}