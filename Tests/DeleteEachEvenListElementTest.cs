using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DeleteEachEvenListElementTest
    {
        public Node<T> DeleteEachEvenListElement<T>(Node<T> root)
        {
            for (var node = root; node?.Next != null;)
            {
                node.Next = node.Next.Next;
                node = node.Next;
            }

            return root;
        }

        [Test]
        public void EmptyListTest()
        {
            Node<int> root = null;
            root = DeleteEachEvenListElement(root);
            Assert.IsNull(root);
        }

        [Test]
        public void ListWithOneElement()
        {
            var root = new Node<int> { Value = 1 };
            root = DeleteEachEvenListElement(root);
            Assert.AreEqual(1, root.Value);
        }

        [Test]
        public void ListWithTwoElements()
        {
            var root = new Node<int> { Value = 1 };
            root.Next = new Node<int> { Value = 2 };
            root = DeleteEachEvenListElement(root);
            Assert.AreEqual(1, root.Value);
            Assert.IsNull(root.Next);
        }
        
        [Test]
        public void ListWithThreeElements()
        {
            var root = new Node<int> { Value = 1 };
            root.Next = new Node<int> { Value = 2 };
            root.Next.Next = new Node<int> { Value = 3 };
            root = DeleteEachEvenListElement(root);
            Assert.AreEqual(1, root.Value);
            Assert.AreEqual(3, root.Next.Value);
        }
    }
}
