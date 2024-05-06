using Homework_3.Contracts;

namespace Homework_3
{
    public class CustomQueue<T> : ICustomQueue<T>
    {
        private LinkedList<T> linkedList;
        public CustomQueue()
        {
            linkedList = new LinkedList<T>();
        }
        public void Enqueue(T item)
        {
            linkedList.AddLast(item);
        }
        public T Dequeue()
        {
            if (linkedList.Count > 0)
            {
                var removedElement = linkedList.First.Value;
                linkedList.RemoveFirst();
                return removedElement;
            }
            else
            {
                throw new InvalidOperationException("Queue is empty! Cannot remove element");
            }
        }

        public bool IsEmpty()
        {
            return linkedList.Count == 0;
        }
    }
}
