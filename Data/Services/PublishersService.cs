using bookapi.Data.Models;
using bookapi.Data.ViewModels;

namespace bookapi.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;

        }
         public void AddPublisher (PublisherVM publisherVM)
        {
            var _publisher = new Publisher()
            {
                Name = publisherVM.Name
                
            };
           _context.Publishers.Add(_publisher);
           _context.SaveChanges();
        }
    }
}