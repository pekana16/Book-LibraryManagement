using Book_LibraryManagement.BusinessLogic;

namespace Book_LibraryManagement_Tests
{
    [TestFixture]
    public class LibraryManagerTests
    {

        // LibraryManager from the BusinessLogic layer
        private LibraryManager _manager;

        [SetUp]
        public void Setup()
        {
            // this is something which runs before each test
            _manager = new LibraryManager();

        }

        // test for adding new books
        [Test]
        public void AddNewBook_ShouldIncreaseBookCount()
        {
            // Arrange
            var initialCount = _manager.GetAllBooks().Count;

            // Act
            _manager.AddNewBook("Test Book", "Test Author");
            var newCount = _manager.GetAllBooks().Count;

            // Assert
            Assert.That(newCount, Is.EqualTo(initialCount + 1));
        }

        // test for getting the books with their ID
        [Test]
        public void GetBookById_ShouldReturnCorrectBook()
        {
            // Arrange
            _manager.AddNewBook("Some Title", "Some Author");
            var lastBook = _manager.GetAllBooks().LastOrDefault();
            var lastId = lastBook?.Id ?? -1;

            // Act
            var foundBook = _manager.GetBookById(lastId);

            // Assert
            Assert.That(foundBook, Is.Not.Null);
            Assert.That(foundBook.Title, Is.EqualTo("Some Title"));
        }

        // test for deleting the book
        [Test]
        public void DeleteBook_ShouldRemoveBookFromCollection()
        {
            // Arrange
            _manager.AddNewBook("Delete Me", "Temp Author");
            var lastBook = _manager.GetAllBooks().LastOrDefault();
            var lastId = lastBook?.Id ?? -1;

            // Act
            _manager.DeleteBook(lastId);
            var deletedBook = _manager.GetBookById(lastId);

            // Assert
            Assert.That(deletedBook, Is.Null);
        }
    }
}