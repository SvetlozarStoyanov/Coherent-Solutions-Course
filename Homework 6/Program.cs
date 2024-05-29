using Homework_6.Models;
using Homework_6.Services;
using Homework_6.ViewModels;
using Newtonsoft.Json;
using System.Text;
using System.Xml.Linq;

namespace Homework_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var authors = new List<Author>()
            {
                new Author("J.K","Rowling", new DateOnly(1960,5,16)),
                new Author("George R.R", "Martin", new DateOnly(1968,3,12)),
                new Author("Ivan", "Vazov", new DateOnly(1850,7,9)),
                new Author("Kass", "Morgan", new DateOnly(1850,7,9)),
                new Author("Danielle", "Page", new DateOnly(1850,7,9)),
            };
            var books = new List<Book>()
            {
                new Book("Harry Potter One","1234567890123",new DateTime(1998,07,16),new HashSet<Author>()
                {
                    authors[0]
                }),
                new Book("Harry Potter Two","1234567890122",new DateTime(1998,11,27),new HashSet<Author>()
                {
                    authors[0]
                }),
                new Book("A Song of Ice and Fire","1234562891122",new DateTime(1996,8,2),new HashSet<Author>()
                {
                    authors[1]
                }),
                new Book("Pod Igoto","1334562820122",new DateTime(1894,2,2),new HashSet<Author>()
                {
                    authors[2]
                }),
                new Book("Chichovci","1384562820122",new DateTime(1885,2,3),new HashSet<Author>()
                {
                    authors[2]
                }),
                new Book("The Monarchs","1234567890332",new DateTime(2022,1,11),new HashSet<Author>()
                {
                    authors[3],
                    authors[4],
                })
            };
            var catalog = new Catalog();
            foreach (var book in books)
            {
                catalog.AddBook(book);
            }
            var xmlDirectory = "../../../Serialized XML/";
            CreateDirectory(xmlDirectory);
            var xmlFilePath = xmlDirectory + "catalog.xml";
            var xmlRepository = new XMLRepository();
            var catalogXml = catalog.SerializeToXml();
            xmlRepository.WriteToFile(catalogXml, xmlFilePath);
            var catalogParsed = xmlRepository.DeserializeToObject<CatalogViewModel>(xmlFilePath);
            Console.WriteLine();

            var jsonFilePath = "../../../Serialized JSON/";
            CreateDirectory(jsonFilePath);
            var jsonRepository = new JSONRepository();
            var authorsAndBooks = catalog.AuthorsAndBooks();
            foreach (var item in authorsAndBooks)
            {
                var path = jsonFilePath + $"{(item.FirstName + " " + item.LastName).Trim()}.json";
                jsonRepository.WriteToFile(item, path);
            }
            var jsonFiles = GetFilesFromDirectory(jsonFilePath);
            var authorsAndBooksDeserialized = new HashSet<AuthorViewModel>();
            foreach (var item in jsonFiles)
            {
                var deserialized = jsonRepository.DeserializeToObject<AuthorViewModel>(item);
                authorsAndBooksDeserialized.Add(deserialized);
            }
            Console.WriteLine();
        }

        private static void CreateDirectory(string path)
        {
            bool directoryExists = Directory.Exists(path);
            if (directoryExists)
            {
                Directory.Delete(path, true);
            }

            Directory.CreateDirectory(path);
        }

        private static string[] GetFilesFromDirectory(string path)
        {
            var files = Directory.GetFiles(path);
            return files;
        }
    }
}
