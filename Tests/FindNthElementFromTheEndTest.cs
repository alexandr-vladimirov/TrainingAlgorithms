using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class FindNthElementFromTheEndTest
    {
        public Node<T> FindNthElementFromTheEnd<T>(Node<T> root, int n)
        {
            if (n < 1)
                return null;

            var first = root;
            for (int i = 0; i < n - 1 && first != null; i++)
                first = first.Next;

            if (first == null)
                return null;

            var second = root;
            while (first.Next != null)
            {
                first = first.Next;
                second = second.Next;
            }

            return second;
        }

        [Test]
        public void EmptyList()
        {
            Node<int> root = null;
            Assert.IsNull(FindNthElementFromTheEnd(root, 1));
        }

        [Test]
        public void IncorrectN()
        {
            var root = new Node<int> { Value = 1 };
            Assert.IsNull(FindNthElementFromTheEnd(root, 0));
        }

        [Test]
        public void ListWithOneElement_FindFirstFromEnd_ReturnRoot()
        {
            var root = new Node<int> { Value = 1 };
            Assert.AreSame(root, FindNthElementFromTheEnd(root, 1));
        }

        [Test]
        public void ListWithOneElement_FindSecondFromEnd_ReturnNull()
        {
            var root = new Node<int> { Value = 1 };
            Assert.IsNull(FindNthElementFromTheEnd(root, 2));
        }

        [Test]
        public void ListWithTwoElements_FindFirstFromEnd()
        {
            var root = new Node<int> { Value = 1 };
            root.Next = new Node<int> { Value = 2 };
            var nthFromEnd = FindNthElementFromTheEnd(root, 1);
            Assert.AreEqual(2, nthFromEnd.Value);
        }

        [Test]
        public void ListWithTwoElements_FindSecondFromEnd()
        {
            var root = new Node<int> { Value = 1 };
            root.Next = new Node<int> { Value = 2 };
            var nthFromEnd = FindNthElementFromTheEnd(root, 2);
            Assert.AreEqual(1, nthFromEnd.Value);
        }
    }
}
