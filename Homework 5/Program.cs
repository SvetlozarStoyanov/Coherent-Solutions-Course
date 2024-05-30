using Homework_5.Task_5._1;
using Homework_5.Task_5._2;

namespace Homework_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Task 4.1
            //var sparseMatrix = new SparseMatrix(10, 10);
            //sparseMatrix[0, 0] = 1;
            //sparseMatrix[0, 9] = 2;
            //sparseMatrix[9, 0] = 3;
            //sparseMatrix[9, 9] = 4;
            //foreach (var item in sparseMatrix)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(sparseMatrix.GetCount(0));
            //Console.WriteLine(sparseMatrix.GetCount(2));
            //Console.WriteLine(sparseMatrix.GetCount(3));
            //Console.WriteLine(sparseMatrix.GetCount(4));
            //Console.WriteLine(sparseMatrix.ToString());

            ////Task 5.2
            var bookOne = new Book("Harry Potter One", "1234556667778", new DateTime(1995, 5, 15), new HashSet<string?>() { "J.K Rowling" });
            var bookTwo = new Book("Harry Potter Two", "1234556657777", new DateTime(1996, 2, 10), new HashSet<string?>() { "J.K Rowling" });
            var bookThree = new Book("Lord of the Rings: Fellowship of the ring", "2234556657759", new DateTime(1954, 7, 29), new HashSet<string?>() { "J. R. R. Tolkien" });
            var bookFour = new Book("Lord of the Rings: The Two towers", "1234556657758", new DateTime(1954, 11, 11), new HashSet<string?>() { "J. R. R. Tolkien" });
            var catalog = new Catalog();
            catalog.AddBook(bookOne);
            catalog.AddBook(bookTwo);
            catalog.AddBook(bookThree);
            catalog.AddBook(bookFour);
            //Console.WriteLine(string.Join(", ", catalog.GetTitlesSortedAlphabetically()));
            //Console.WriteLine(string.Join(", ", catalog.AuthorAndBookCount()));
            Console.WriteLine(string.Join(",\n", catalog.GetBooksWhichHaveAuthor("J.K Rowling")));
        }
    }
}
