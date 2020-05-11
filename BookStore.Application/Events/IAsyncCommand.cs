using System.Threading.Tasks;

namespace BookStore.Application.Events {
    public interface IAsyncCommand<TReturn, TInput> {
        TReturn ExecuteAsync(TInput input);
    }
    
    public interface IAsyncCommand<TReturn> {
        Task<TReturn> ExecuteAsync();
    }
}