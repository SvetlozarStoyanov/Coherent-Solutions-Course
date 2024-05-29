using Homework_6.Contracts;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Homework_6.Models
{
    [XmlRoot(ElementName = "Book")]
    [Serializable]
    public class Book : IXMLSerializable
    {
        private string title;
        private string isbn;
        private DateTime? publicationDate;
        private HashSet<Author> authors;
        private Regex regexWithHyphons = new Regex(@"[0-9]{3}[-][0-9]{1}[-][0-9]{2}[-][0-9]{6}[-][0-9]{1}");
        private Regex regexNoHyphons = new Regex(@"[0-9]{13}");

        public Book()
        {
            
        }

        [SetsRequiredMembers]
        public Book(string title,
            string isbn,
            DateTime? publicationDate,
            HashSet<Author> authors)
        {
            Title = title;
            ISBN = isbn;
            PublicationDate = publicationDate;
            Authors = authors;
            if (Authors == null)
            {
                Authors = new HashSet<Author?>();
            }
        }
        [XmlElement(ElementName = "Title")]
        public required string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title cannot be null or empty!");
                }
                title = value;
            }
        }

        [XmlElement(ElementName = "ISBN")]
        public required string ISBN
        {
            get => isbn;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("ISBN is required!");
                }
                if (!regexWithHyphons.IsMatch(value)
                     && !regexNoHyphons.IsMatch(value)
                    )
                {
                    throw new ArgumentException("ISBN is invalid");
                }
                isbn = value;
            }
        }

        [XmlElement(ElementName = "PublicationDate")]
        public DateTime? PublicationDate
        {
            get => publicationDate;
            set => publicationDate = value;
        }

        [XmlArray(ElementName = "Authors")]
        public HashSet<Author> Authors
        {
            get => authors;
            set => authors = value;
        }

        public override string ToString()
        {
            return $"Name: {Title}, ISBN: ${ISBN}," +
                $"Publication Date: {(PublicationDate != null ? PublicationDate.Value.Date.ToShortDateString() : "Unknown")}," +
                $" Authors: {string.Join(", ", Authors)}";
        }

        public XElement SerializeToXml()
        {
            var xml = new XElement("Book",
                new XElement("Title", Title),
                new XElement("ISBN", ISBN),
                new XElement("PublicationDate", PublicationDate),
                new XElement("Authors", authors.Select(a =>  a.SerializeToXml())));

            return xml;
        }
    }
}
