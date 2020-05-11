using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Application.Interfaces.Models;
using BookStore.Domain;

namespace BookStore.Application.Interfaces {
    public interface IAuthorRepository {

        Task<bool> AddAuthor(Author author);
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> GetAuthorById(string authorId);
    }
}