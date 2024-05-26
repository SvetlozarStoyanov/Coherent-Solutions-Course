using Homework_6.Contracts;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Homework_6.Models
{
    [XmlRoot(ElementName = "Catalog")]
    [Serializable]
    public class Catalog : IXMLSerializable
    {
        [XmlArray(ElementName = "Books")]
        [XmlArrayItem(typeof(Book))]
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

        public HashSet<Book> GetBooksWhichHaveAuthor(string authorName)
        {
            return books.Values
                .Where(b => b.Authors.Any(an => $"{an.FirstName} + {an.LastName}" == authorName))
                .OrderBy(b => b.PublicationDate)
                .ToHashSet();
        }

        public HashSet<Tuple<string, int>> AuthorAndBookCount()
        {
            var authors = new Dictionary<string, int>();
            foreach (var book in books)
            {
                foreach (var author in book.Value.Authors)
                {
                    if (!authors.ContainsKey(author.FullName))
                    {
                        authors[author.FullName] = 0;
                    }
                    authors[author.FullName]++;
                }
            }
            return authors
                .Select(a => new Tuple<string, int>(a.Key, a.Value))
                .ToHashSet();
        }

        public XElement SerializeToXml()
        {
            XElement xml = new XElement("Catalog",
                new XElement("Books",
                from kvp in books
                select kvp.Value.SerializeToXml()
            ));
            return xml;
        }
    }
}