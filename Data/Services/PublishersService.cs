using System;
using System.Linq;
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
        public PublisherWithBooksAndAuthorsVM GetPublisherWithBooksAndAuthors(int publisherId)
        {
            var _publisher = _context.Publishers.Where(n =>n.Id==publisherId).Select(n =>new PublisherWithBooksAndAuthorsVM()
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(n =>new BookAuthorVM()
                {
                   BookName =n.Title,
                   BookAuthors =n.Book_Authors.Select(n =>n.Author.FullName).ToList() 
                }).ToList()

            }).FirstOrDefault();
            return _publisher;
        }

        public void DeletePublisherByPublisherId(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n =>n.Id==id);
            if(_publisher!=null)
            {
                _context.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}