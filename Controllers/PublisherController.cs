using bookapi.Data.Services;
using bookapi.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PublisherController : ControllerBase
    {
        private readonly PublishersService _publisherService;
        public PublisherController(PublishersService publisherService)
        {
            _publisherService = publisherService;

        }
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher(PublisherVM publisherVM)
        {
            _publisherService.AddPublisher(publisherVM);
            return Ok();
        }
        [HttpGet("publisher-with-book-authors-by-id/{id}")]
        public IActionResult GetPublisherWithBookAuthors(int id)
        {
            var response =_publisherService.GetPublisherWithBooksAndAuthors(id);
            return Ok(response);
        }
        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            _publisherService.DeletePublisherByPublisherId(id);
            return Ok();
        }
    }
}