namespace Homework_6.Contracts
{
    public interface IRepository
    {
        void WriteToFile<T>(T obj, string path);

        T DeserializeToObject<T>(string path);
    }
}
