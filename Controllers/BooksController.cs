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
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var books =_bookServie.GetAllbooks();
            return Ok(books);
        }
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book =_bookServie.GetBook(id);
            return Ok(book);
        }
        [HttpPut("update-book-by-id{bookId}")]
        public IActionResult UpdateBook(int bookId,[FromBody] BookVM book)
        {
            var updatedBook = _bookServie.UpdateBook(bookId,book);
            return Ok(updatedBook);
        }
        [HttpDelete("delete-book{bookId}")]
        public IActionResult DeleteBook(int bookId)
        {
         _bookServie.DeleteBook(bookId);
         return Ok();


        }
    }
}