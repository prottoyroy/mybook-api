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
        public void AddBookWithAuthor (BookVM book)
        {
            var _book = new Book()
            {
                Title =book.Title,
                Description=book.Description,
                IsRead =book.IsRead,
                DateRead=book.IsRead?book.DateRead.Value:null,
                Rate=book.IsRead?book.Rate.Value:null,
                Genre=book.Genre,
                CoverUrl=book.CoverUrl,
                PublisherId=book.PublisherId,
                DateAdded=DateTime.Now
                
           };
           _context.Books.Add(_book);
           _context.SaveChanges();
           foreach(var id in book.AuthorIds)
           {
               var book_author = new Book_Author()
               {
                   BookId = _book.Id,
                   AuthorId =id
               };
               _context.Book_Authors.Add(book_author);
               _context.SaveChanges();
           }
        }
        
        public List<Book> GetAllbooks() =>_context.Books.ToList();
        // public Book GetBook(int bookId) =>_context.Books.FirstOrDefault(b =>b.Id ==bookId);
         public BookWithAuthorVM GetBook(int bookId)
         {
             var _bookWithAuthorVM = _context.Books.Where(n =>n.Id==bookId).Select(book =>new BookWithAuthorVM()
             {
                Title =book.Title,
                Description=book.Description,
                IsRead =book.IsRead,
                DateRead=book.IsRead?book.DateRead.Value:null,
                Rate=book.IsRead?book.Rate.Value:null,
                Genre=book.Genre,
                CoverUrl=book.CoverUrl,
                PublisherName =book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n =>n.Author.FullName).ToList() 
             }).FirstOrDefault();
             return _bookWithAuthorVM;
         }

        public Book UpdateBook (int bookId,BookVM book)
        {
            var _book =_context.Books.FirstOrDefault(b =>b.Id==bookId);
            if(_book != null)
            {
                _book.Title =book.Title;
                _book.Description=book.Description;
                _book.IsRead =book.IsRead;
                _book.DateRead=book.IsRead?book.DateRead.Value:null;
                _book.Rate=book.IsRead?book.Rate.Value:null;
                _book.Genre=book.Genre;
                _book.CoverUrl=book.CoverUrl;
                _context.SaveChanges();
            }
            return _book;
        }
        public void DeleteBook(int bookId)
        {
            var _book =_context.Books.FirstOrDefault(b =>b.Id==bookId);
            if(_book!=null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
        // public List<Book> GetAllbooks()
        // {
        //     var allbooks = _context.books.ToList();
        //     return allbooks;
        // }
           
        
        
    }
}