using Homework_5.Task_5._2;

namespace Homework_5_Unit_Tests.CatalogTests
{
    [TestFixture]
    public class CatalogTests
    {
        private Catalog catalog;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var bookOne = new Book("Harry Potter One", "1234556667778", new DateTime(1995, 5, 15), new HashSet<string?>() { "J.K Rowling" });
            var bookTwo = new Book("Harry Potter Two", "1234556657777", new DateTime(1996, 2, 10), new HashSet<string?>() { "J.K Rowling" });
            var bookThree = new Book("Lord of the Rings: Fellowship of the ring", "2234556657759", new DateTime(1954, 7, 29), new HashSet<string?>() { "J. R. R. Tolkien" });
            var bookFour = new Book("Lord of the Rings: The Two towers", "1234556657758", new DateTime(1954, 11, 11), new HashSet<string?>() { "J. R. R. Tolkien" });
            catalog = new Catalog();
            catalog.AddBook(bookOne);
            catalog.AddBook(bookTwo);
            catalog.AddBook(bookThree);
            catalog.AddBook(bookFour);
        }

        [Test]
        public void TestGetTitlesSortedAlphabeticallyReturnsCorrectTitles()
        {
            var result = catalog.GetTitlesSortedAlphabetically();
            var resultAsList = result.ToList();
            Assert.That(result.Count == 4);
            Assert.That(resultAsList[0] == "Harry Potter One");
            Assert.That(resultAsList[1] == "Harry Potter Two");
            Assert.That(resultAsList[2] == "Lord of the Rings: Fellowship of the ring");
            Assert.That(resultAsList[3] == "Lord of the Rings: The Two towers");
        }

        [Test]
        public void TestGetBooksWhichHaveAuthorCorrectBooks()
        {
            var result = catalog.GetBooksWhichHaveAuthor("J.K Rowling");
            Assert.That(result.Count == 2);
            Assert.That(result.All(b => b.Authors.Contains("J.K Rowling")));
            result = catalog.GetBooksWhichHaveAuthor("J. R. R. Tolkien");
            Assert.That(result.Count == 2);
            Assert.That(result.All(b => b.Authors.Contains("J. R. R. Tolkien")));

        }

        [Test]
        public void TestAuthorAndBookCountReturnsCorrectAuthorsWithBookCount()
        {
            var result = catalog.AuthorAndBookCount();
            var resultAsList = result.ToList();
            Assert.That(result.Count == 2);
            Assert.That(resultAsList[0].Item2 == 2);
            Assert.That(resultAsList[1].Item2 == 2);
        }
    }
}
