using BookStore.Application;
using Xunit;

namespace Application.Tests {
    
    /*
     * Just some test cases to make method calls easier.
     * Not providing real functionality tests.
     */
    public class DispatcherShould {
        [Fact]
        public void CreateAuthor() {
            var dispatcher = new Dispatcher();
            dispatcher.Dispatch(new CreateAuthorCommand());
        }
    }
}