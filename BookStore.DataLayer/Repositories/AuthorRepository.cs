using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataLayer.Repositories {
    internal class AuthorRepository : IAuthorRepository {
        private readonly BookStoreContext context;

        public AuthorRepository(BookStoreContext context) {
            this.context = context;
        }

        public async Task<bool> AddAuthor(Author author) {
            if (author is null) return false;

            try {
                await context.Authors.AddAsync(author);
                await context.SaveChangesAsync();

                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<IEnumerable<Author>> GetAuthors() => await context.Authors
            .ToListAsync();

        /// <summary>
        /// Get an <see cref="Author"/> with the provided id. <br />
        /// If no Author is found, an <see cref="Author.InvalidAuthor"/> is returned. 
        /// </summary>
        public async Task<Author> GetAuthorById(string authorId) => await context.Authors
            .SingleOrDefaultAsync(author => EF.Property<string>(author, "id") == authorId)
        ?? Author.CreateInvalid(); // make sure to ALWAYS return an Author
    }
}