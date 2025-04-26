using Final.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL.Repository
{
    public class BookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books;
        }
        
        
        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        
        
        public void AddRange(List<Book> books)
        {
            _context.Books.AddRange(books);
            _context.SaveChanges();
        }


        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        
        
        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void DeleteRange(List<Book> books)
        {
            _context.Books.RemoveRange(books);
            _context.SaveChanges();
        }
    }

}
