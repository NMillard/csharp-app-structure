using System.Threading.Tasks;
using BookStore.Application.Interfaces;
using BookStore.Application.Interfaces.Models;
using BookStore.Application.Validators;
using BookStore.Domain;

namespace BookStore.Application.Events {
    public class CreateAuthor : IAsyncCommand<bool, ICreateAuthor> {
        private readonly IAuthorRepository repository;
        private readonly ValidateCreateAuthorInput validator;
        private readonly ApplicationEventTriggers eventTriggers;

        public CreateAuthor(IAuthorRepository repository, ValidateCreateAuthorInput validator, ApplicationEventTriggers eventTriggers) {
            this.repository = repository;
            this.validator = validator;
            this.eventTriggers = eventTriggers;
        }
        
        public async Task<bool> ExecuteAsync(ICreateAuthor input) {
            if (!validator.ValidateInput(input)) return false;

            var author = Author.CreateNew(input.Name);
            if (author is Author.InvalidAuthor) return false;

            await repository.AddAuthor(author);
            eventTriggers.OnAuthorAdded(this);
            
            return true;
        }
    }
}