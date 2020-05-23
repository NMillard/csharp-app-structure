using System.Threading.Tasks;
using BookStore.Application;
using BookStore.Application.Events;
using BookStore.WebClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebClient.Controllers {
    
    [Route("api/[controller]/[action]")]
    public class AuthorsController : ControllerBase {
        private readonly GetAuthors getAuthors;
        private readonly CreateAuthor createAuthor;
        private readonly Dispatcher dispatcher;

        public AuthorsController(GetAuthors getAuthors, CreateAuthor createAuthor, Dispatcher dispatcher) {
            this.getAuthors = getAuthors;
            this.createAuthor = createAuthor;
            this.dispatcher = dispatcher;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAuthors() => Ok(await getAuthors.ExecuteAsync());

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAuthor(string id) {
            return Ok();
        }
        
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorModel model) {
            if (!ModelState.IsValid) return BadRequest();

            dispatcher.Dispatch(new CreateAuthorCommand {AuthorName = "Some author"});
            bool succeeded = await createAuthor.ExecuteAsync(model);
            if (!succeeded) return BadRequest("Could not create author");
            
            return Ok(new {Status = "Created"});
        }
    }
}