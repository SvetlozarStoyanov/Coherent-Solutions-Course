namespace Homework_3.Contracts
{
    public interface ICustomQueue<T> where T : struct
    {
        void Enqueue(T item);

        T Dequeue();

        bool IsEmpty();
    }
}
