using System;
using System.Collections.Generic;
using System.Linq;
using bookapi.Data.Models;
using bookapi.Data.ViewModels;

namespace bookapi.Data.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;

        }
        public void AddBook (BookVM book)
        {
            var _book = new Book()
            {
                Title =book.Title,
                Description=book.Description,
                IsRead =book.IsRead,
                DateRead=book.IsRead?book.DateRead.Value:null,
                Rate=book.IsRead?book.Rate.Value:null,
                Genre=book.Genre,
                Author=book.Author,
                CoverUrl=book.CoverUrl,
                DateAdded=DateTime.Now
                
           };
           _context.books.Add(_book);
           _context.SaveChanges();
        }
        
        public List<Book> GetAllbooks() =>_context.books.ToList();
        public Book GetBook(int bookId) =>_context.books.FirstOrDefault(b =>b.Id ==bookId);

        
        // public List<Book> GetAllbooks()
        // {
        //     var allbooks = _context.books.ToList();
        //     return allbooks;
        // }
           
        
        
    }
}