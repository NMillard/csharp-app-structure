using System.Collections.Generic;

namespace BookStore.Domain {
    public class Author {
        private readonly string id;
        private List<Book> books;

        public Author(string id, string name) {
            this.id = id;
            Name = name;
            books = new List<Book>();
        }
        
        public string Name { get; private set; }

        public IReadOnlyCollection<Book> Books => books;

        public static Author CreateNew(string name) {
            if (string.IsNullOrEmpty(name)) return new InvalidAuthor();
            
            return new Author(IdGenerator.GenerateNewId(), name);
        }
        
        public static Author CreateInvalid() => new InvalidAuthor();

        public class InvalidAuthor : Author {
            internal InvalidAuthor() : base("", "Invalid author") { }
        }
    }
}