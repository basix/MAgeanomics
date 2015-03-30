
namespace Mageanomics.Collections
{
    public class Node<T>
    {
        public Node(T data, Node<T> next = null, Node<T> previous = null)
        {
            this.Next = next;
            this.Previous = previous;
            this.Data = data;
        }

        public Node<T> Previous
        {
            get;
            set;
        }

        public Node<T> Next
        {
            get;
            set;
        }

        public T Data
        {
            get;
            set;
        }
    }
}
