﻿namespace Homework_5.Task_5._2
{
    public class Catalog
    {
        private Dictionary<string, Book> books;

        public Catalog()
        {
            books = new Dictionary<string, Book>();
        }

        public void AddBook(Book book)
        {
            var filteredISBN = book.ISBN.Replace("-", string.Empty);

            books.Add(filteredISBN, book);
        }

        public Book GetBook(string isbn)
        {
            var filteredISBN = isbn.Replace("-", string.Empty);
            if (books.ContainsKey(filteredISBN))
            {
                return books[filteredISBN];
            }
            return null;
        }

        public HashSet<string> GetTitlesSortedAlphabetically()
        {
            return books.Values
                .Select(b => b.Title)
                .OrderBy(t => t).ToHashSet();
        }

        public HashSet<Book> GetBooksWhichHaveAuthor(string author)
        {
            return books.Values
                .Where(b => b.Authors.Contains(author))
                .OrderBy(b => b.PublicationDate)
                .ToHashSet();
        }

        public HashSet<Tuple<string, int>> AuthorAndBookCount()
        {
            return books
                .SelectMany(book => book.Value.Authors)
                .GroupBy(author => author)
                .Select(group => new Tuple<string, int>(group.Key, group.Count()))
                .ToHashSet();
        }

    }
}
