using Homework_6.Contracts;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Homework_6.Services
{
    public class XMLRepository : IRepository
    {
        public void WriteToFile<T>(T obj, string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var streamWriter = new StreamWriter(path, false, Encoding.UTF8);
            xmlSerializer.Serialize(streamWriter, obj);
            streamWriter.Close();
        }

        public T DeserializeToObject<T>(string path)
        {
            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("Catalog"));
            var streamReader = new StreamReader(path, Encoding.UTF8);
            var result = (T)serializer.Deserialize(streamReader);
            streamReader.Close();
            return result;
        }

    }
}
