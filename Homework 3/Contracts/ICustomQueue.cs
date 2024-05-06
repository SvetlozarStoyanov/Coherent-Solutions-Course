namespace Homework_3.Contracts
{
    public interface ICustomQueue<T>
    {
        void Enqueue(T item);

        T Dequeue();

        bool IsEmpty();
    }
}
