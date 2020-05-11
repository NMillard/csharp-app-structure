using System.Threading.Tasks;
using BookStore.Application.Events;
using BookStore.WebClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebClient.Controllers {
    
    [Route("api/[controller]/[action]")]
    public class AuthorsController : ControllerBase {
        private readonly GetAuthors getAuthors;
        private readonly CreateAuthor createAuthor;

        public AuthorsController(GetAuthors getAuthors, CreateAuthor createAuthor) {
            this.getAuthors = getAuthors;
            this.createAuthor = createAuthor;
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

            bool succeeded = await createAuthor.ExecuteAsync(model);
            if (!succeeded) return BadRequest("Could not create author");
            
            return Ok(new {Status = "Created"});
        }
    }
}