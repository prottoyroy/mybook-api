using bookapi.Data.Services;
using bookapi.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookapi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorsService _authorService;
        public AuthorController(AuthorsService authorService)
        {
            _authorService = authorService;

        }
        [HttpPost("add-author")]
        public IActionResult AddAuthor( AuthorVM authorVM)
        {
            _authorService.AddAuthor(authorVM);
            return Ok();
        }
    }
}