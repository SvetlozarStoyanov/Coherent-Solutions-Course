using Homework_6.Contracts;
using Newtonsoft.Json;
using System.Text;

namespace Homework_6.Services
{
    public class JSONRepository : IRepository
    {
        public void WriteToFile<T>(T obj, string path)
        {
            var serializer = new JsonSerializer();
            var streamWriter = new StreamWriter(path, false, Encoding.UTF8);
            var jsonWriter = new JsonTextWriter(streamWriter);

            jsonWriter.Formatting = Formatting.Indented;

            serializer.Serialize(jsonWriter, obj);
            streamWriter.Close();
        }

        public T DeserializeToObject<T>(string path)
        {
            var streamReader = new StreamReader(path);
            var result =
                JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());

            return result;
        }
    }
}
