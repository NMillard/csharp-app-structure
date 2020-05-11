using BookStore.Application.Interfaces.Models;

namespace BookStore.Application.Validators {
    public class ValidateCreateAuthorInput {
        public bool ValidateInput(ICreateAuthor createAuthor) {
            if (createAuthor is null) return false;
            if (string.IsNullOrEmpty(createAuthor.Name)) return false;
            
            return true;
        }
    }
}