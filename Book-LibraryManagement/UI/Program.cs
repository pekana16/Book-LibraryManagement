using Book_LibraryManagement.BusinessLogic;
using System;

namespace Book_LibraryManagement.UI

{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryManager manager = new LibraryManager();
            bool running = true;

            while (running)
            {
                Console.Clear();  // simple to clear the console to get that "fresh" menu
                Console.WriteLine("=== Book Management System ===");
                Console.WriteLine("1) Add Book");
                Console.WriteLine("2) List All Books");
                Console.WriteLine("3) Search Book by ID");
                Console.WriteLine("4) Update Book");
                Console.WriteLine("5) Delete Book");
                Console.WriteLine("0) Exit");
                Console.Write("Enter choice: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBookFlow(manager);
                        break;
                    case "2":
                        ListAllBooksFlow(manager);
                        break;
                    case "3":
                        SearchBookFlow(manager);
                        break;
                    case "4":
                        UpdateBookFlow(manager);
                        break;
                    case "5":
                        DeleteBookFlow(manager);
                        break;
                    case "0":
                        running = false;
                        break;

                    // in case the wrong option number was chosen - check line 164 - 170
                    default:
                        Console.WriteLine("Invalid choice. Press ENTER to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // option number 1 -> adding a book
        private static void AddBookFlow(LibraryManager manager)
        {
            Console.Clear();
            Console.WriteLine("=== Add Book ===");
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();

            manager.AddNewBook(title, author);
            Console.WriteLine("Book has been added successfully!");
            Console.WriteLine("Press ENTER to return to menu.");
            Console.ReadLine();
        }

        // option number 2 -> listing all the books
        private static void ListAllBooksFlow(LibraryManager manager)
        {
            Console.Clear();
            Console.WriteLine("=== All Books ===");
            var books = manager.GetAllBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
            }
            else
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
                }
            }
            Console.WriteLine("Press ENTER to return to menu.");
            Console.ReadLine();
        }

        // option number 3 -> searching the book by its ID
        private static void SearchBookFlow(LibraryManager manager)
        {
            Console.Clear();
            Console.WriteLine("=== Search Book ===");
            Console.Write("Enter Book ID: ");
            if (int.TryParse(Console.ReadLine(), out int searchId))
            {
                var foundBook = manager.GetBookById(searchId);
                if (foundBook != null)
                {
                    Console.WriteLine($"Found: ID: {foundBook.Id}, Title: {foundBook.Title}, Author: {foundBook.Author}");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID input.");
            }
            Console.WriteLine("Press ENTER to return to menu.");
            Console.ReadLine();
        }

        // option number 4 -> updating the book
        private static void UpdateBookFlow(LibraryManager manager)
        {
            Console.Clear();
            Console.WriteLine("=== Update Book ===");
            Console.Write("Enter Book ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int updateId))
            {
                var existingBook = manager.GetBookById(updateId);
                if (existingBook != null)
                {
                    Console.Write($"New Title (old: {existingBook.Title}): ");
                    string newTitle = Console.ReadLine();
                    Console.Write($"New Author (old: {existingBook.Author}): ");
                    string newAuthor = Console.ReadLine();

                    manager.UpdateBook(updateId, newTitle, newAuthor);
                    Console.WriteLine("Book updated successfully!");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID input.");
            }
            Console.WriteLine("Press ENTER to return to menu.");
            Console.ReadLine();
        }

        // option number 5 -> deleting a book
        private static void DeleteBookFlow(LibraryManager manager)
        {
            Console.Clear();
            Console.WriteLine("=== Delete Book ===");
            Console.Write("Enter Book ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int deleteId))
            {
                manager.DeleteBook(deleteId);
                Console.WriteLine("Book deleted (if existed).");
            }

            // what happens in case invalid "option-number" was chosen - for example 6,7,8 etc..
            else
            {
                Console.WriteLine("Invalid ID input.");
            }
            Console.WriteLine("Press ENTER to return to menu.");
            Console.ReadLine();
        }
    }
}
