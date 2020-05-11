using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataLayer.ModelConfigurations {
    public class AuthorConfig : IEntityTypeConfiguration<Author> {
        private const string AuthorPrimaryKeyName = "id";
        
        public void Configure(EntityTypeBuilder<Author> builder) {
            builder.ToTable("Authors");

            builder.Property(AuthorPrimaryKeyName);
            builder.HasKey(AuthorPrimaryKeyName);

            builder.Property(author => author.Name).HasMaxLength(150);

            builder.HasMany<Book>(nameof(Author.Books))
                .WithOne()
                .IsRequired();
        }
    }
}