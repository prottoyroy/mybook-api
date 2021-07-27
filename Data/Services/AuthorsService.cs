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
    }
}