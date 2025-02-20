using Book_LibraryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_LibraryManagement.BusinessLogic
{
    public class LibraryManager
    {
        private readonly LibraryRepository _repo;

        public LibraryManager()
        {
            _repo = new LibraryRepository(); 
        }

        public void AddNewBook(string title, string author)
        {
            var newBook = new Book
            {
                Id = GenerateNewId(),
                Title = title,
                Author = author
            };
            _repo.AddBook(newBook);
        }
        public List<Book> GetAllBooks()
        {
            return _repo.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _repo.GetBookById(id);
        }

        public void UpdateBook(int id, string newTitle, string newAuthor)
        {
            var book = _repo.GetBookById(id);
            if (book != null)
            {
                book.Title = newTitle;
                book.Author = newAuthor;
                _repo.UpdateBook(book);
            }
        }

        public void DeleteBook(int id)
        {
            _repo.DeleteBook(id);
        }

        private int GenerateNewId()
        {
            var allBooks = _repo.GetAllBooks();
            if (allBooks.Count == 0)
                return 1;
            return allBooks.Max(b => b.Id) + 1;
        }

    }
}
