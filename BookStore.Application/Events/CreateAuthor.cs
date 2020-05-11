using System.Threading.Tasks;
using BookStore.Application.Interfaces;
using BookStore.Application.Interfaces.Models;
using BookStore.Application.Validators;
using BookStore.Domain;

namespace BookStore.Application.Events {
    public class CreateAuthor : IAsyncCommand<Task<bool>, ICreateAuthor> {
        private readonly IAuthorRepository repository;
        private readonly ValidateCreateAuthorInput validator;

        public CreateAuthor(IAuthorRepository repository, ValidateCreateAuthorInput validator) {
            this.repository = repository;
            this.validator = validator;
        }
        
        public async Task<bool> ExecuteAsync(ICreateAuthor input) {
            if (!validator.ValidateInput(input)) return false;

            var author = Author.CreateNew(input.Name);
            if (author is Author.InvalidAuthor) return false;

            await repository.AddAuthor(author);
            
            return true;
        }
    }
}