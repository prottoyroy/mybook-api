using System.Linq;
using bookapi.Data.Models;
using bookapi.Data.ViewModels;

namespace bookapi.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;

        }
        public void AddAuthor (AuthorVM authorVM)
        {
            var _author = new Author()
            {
                FullName = authorVM.FullName
                
            };
           _context.Authors.Add(_author);
           _context.SaveChanges();
        }
        public AuthorWithBookVM GetAuthorWithBookTitle(int authorId)
        {
            var _author = _context.Authors.Where(n =>n.Id==authorId).Select(a =>new AuthorWithBookVM()
            {
                FullName =a.FullName,
                BookTitles = a.Book_Authors.Select(s =>s.Book.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}