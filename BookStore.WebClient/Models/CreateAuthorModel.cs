using BookStore.Application.Interfaces.Models;

namespace BookStore.WebClient.Models {
    public class CreateAuthorModel : ICreateAuthor {
        public string Name { get; set; }
    }
}