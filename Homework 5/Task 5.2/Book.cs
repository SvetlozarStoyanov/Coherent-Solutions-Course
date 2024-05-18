using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Homework_5.Task_5._2
{
    public class Book
    {
        private string title;
        private string isbn;
        private DateTime? publicationDate;
        private HashSet<string> authors;
        private Regex regexWithHyphons = new Regex(@"[0-9]{3}[-][0-9]{1}[-][0-9]{2}[-][0-9]{6}[-][0-9]{1}");
        private Regex regexNoHyphons = new Regex(@"[0-9]{13}");

        [SetsRequiredMembers]
        public Book(string title,
            string isbn,
            DateTime? publicationDate,
            HashSet<string> authors)
        {
            Title = title;
            ISBN = isbn;
            PublicationDate = publicationDate;
            Authors = authors;
            if (Authors == null)
            {
                Authors = new HashSet<string?>();
            }
        }

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
        public required string ISBN
        {
            get => isbn;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("ISBN is required!");
                }
                if ((!regexWithHyphons.IsMatch(value)
                     && !regexNoHyphons.IsMatch(value))
                    )
                {
                    throw new ArgumentException("ISBN is invalid");
                }
                isbn = value;
            }
        }
        public DateTime? PublicationDate
        {
            get => publicationDate;
            set => publicationDate = value;
        }

        public HashSet<string> Authors
        {
            get => authors;
            set => authors = value;
        }

        public override string ToString()
        {
            return $"Name: {Title}, ISBN: ${ISBN}," +
                $"Publication Date: {(PublicationDate != null ?  PublicationDate.Value.Date.ToShortDateString() : "Unknown")}," +
                $" Authors: {string.Join(", ",Authors)}";
        }
    }
}
