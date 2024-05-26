using Homework_6.Models;
using System.Xml.Serialization;

namespace Homework_6.ViewModels
{
    [XmlRoot(ElementName = "Catalog")]
    public class CatalogViewModel
    {
        [XmlArray(ElementName = "Books")]
        [XmlArrayItem(typeof(Book))]
        public Book[] Books { get; set; }
    }
}
