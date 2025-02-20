using Book_LibraryManagement.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

using Newtonsoft.Json;
namespace Book_LibraryManagement.DataAccess
{
    public class LibraryRepository
    {
        private readonly string _filePath = "books.json";

        public void AddBook(Book book)
        {
            var allBooks = GetAllBooks();
            allBooks.Add(book);
            SaveAllBooks(allBooks);
        }

        public List<Book> GetAllBooks()
        {
            var jsonData = File.ReadAllText(_filePath);
            var books = JsonConvert.DeserializeObject<List<Book>>(jsonData)
                        ?? new List<Book>();
            return books;
        }

        public Book GetBookById(int id)
        {
            var allBooks = GetAllBooks();
            return allBooks.FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBook(Book updatedBook)
        {
            var allBooks = GetAllBooks();
            var existingBook = allBooks.FirstOrDefault(b => b.Id == updatedBook.Id);

            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                // If you had more properties, update them here as well.

                SaveAllBooks(allBooks);
            }
        }

        public void DeleteBook(int id)
        {
            var allBooks = GetAllBooks();
            var bookToRemove = allBooks.FirstOrDefault(b => b.Id == id);

            if (bookToRemove != null)
            {
                allBooks.Remove(bookToRemove);
                SaveAllBooks(allBooks);
            }
        }

        private void SaveAllBooks(List<Book> books)
        {
            var jsonData = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
