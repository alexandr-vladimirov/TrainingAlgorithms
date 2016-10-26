using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }

    public class SingleLinkedList<T>
    {
        private Node<T> root = null;

        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node<T>();
                root.Value = value;
                return;
            }

            var node = root;
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = new Node<T> { Value = value };
        }

        public void Reverse()
        {
            if (root?.Next == null)
                return;
            var previous = root;
            var current = previous.Next;

            do
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            } while (current != null);

            root = previous;
        }

        public T this[int index]
        {
            get
            {
                var node = root;
                for (var i = 0; i < index && node != null; i++)
                {
                    node = node.Next;
                }
                if (node == null)
                {
                    throw new IndexOutOfRangeException();
                }
                return node.Value;
            }
        }
    }
}
