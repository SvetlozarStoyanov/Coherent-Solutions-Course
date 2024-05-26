namespace Homework_6.Contracts
{
    public interface IRepository<T>
    {
        void WriteToFile(T obj, string path);

        T DeserializeToObject<T>(string path);
    }
}
