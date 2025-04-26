using Final.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.DAL.Repository;

namespace Final.Service
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }
        

        public Book? GetBookById(int id) 
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id), "id cannot be negativ");
            }
            return _bookRepository.GetAllBooks()
              .FirstOrDefault(b => b.Id == id);
        }


        public Book? GetBookByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException(nameof(title), "title cannot be null");
            }
            return _bookRepository.GetAllBooks()
                .FirstOrDefault(b => b.Title == title);
        }
        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
        }
        public void DeleteBook(Book book)
        {
            _bookRepository.Delete(book);
        }
    }
}
