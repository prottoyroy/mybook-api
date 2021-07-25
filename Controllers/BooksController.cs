using bookapi.Data.Services;
using bookapi.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _bookServie;
        public BooksController(BooksService bookServie)
        {
            _bookServie = bookServie;

        }
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookServie.AddBook(book);
            return Ok();
        }
    }
}