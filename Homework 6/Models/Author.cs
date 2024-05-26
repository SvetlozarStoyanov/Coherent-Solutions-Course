using Homework_6.Contracts;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Homework_6.Models
{
    [XmlRoot(ElementName = "Author")]
    [Serializable]
    public class Author : IXMLSerializable
    {
        private string firstName;
        private string lastName;

        public Author()
        {

        }

        [SetsRequiredMembers]
        public Author(string firstName, string lastName, DateOnly dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        [XmlElement(ElementName = "FirstName")]
        public required string FirstName
        {
            get => firstName;
            set
            {
                if (value.Length > 200)
                {
                    throw new ArgumentException("Name cannot be above 200 symbols");
                }
                firstName = value;
            }
        }

        [XmlElement(ElementName = "LastName")]
        public required string LastName
        {
            get => lastName;
            set
            {
                if (value.Length > 200)
                {
                    throw new ArgumentException("Name cannot be above 200 symbols");
                }
                lastName = value;
            }
        }

        [XmlElement(ElementName = "DateOfBirth")]
        public DateOnly DateOfBirth { get; set; }

        [XmlIgnore]
        public string FullName => $"{FirstName} + {LastName}";

        public XElement SerializeToXml()
        {
            var xml = new XElement("Author",
                new XElement("FirstName", FirstName),
                new XElement("LastName", LastName),
                new XElement("DateOfBirth", DateOfBirth));
            return xml;
        }
    }
}
