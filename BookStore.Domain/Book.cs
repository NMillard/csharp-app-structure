namespace BookStore.Domain {
    public class Book {
        private readonly string id;

        public Book(string id, string title) {
            this.id = id;
            Title = title;
        }
        
        public string Title { get; private set; }
    }
}