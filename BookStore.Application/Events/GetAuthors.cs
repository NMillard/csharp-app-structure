using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Application.Interfaces;
using BookStore.Domain;

namespace BookStore.Application.Events {
    public class GetAuthors : IAsyncCommand<IEnumerable<Author>> {
        private readonly IAuthorRepository repository;

        public GetAuthors(IAuthorRepository repository) {
            this.repository = repository;
        }

        public async Task<IEnumerable<Author>> ExecuteAsync() => await repository.GetAuthors();
    }
}