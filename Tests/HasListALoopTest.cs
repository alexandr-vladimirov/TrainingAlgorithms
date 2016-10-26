using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class HasListALoopTest
    {
        public bool HasListALoop<T>(Node<T> root)
        {
            if (root == null)
                return false;
            var hashset = new HashSet<Node<T>>();
            var currentNode = root;
            do
            {
                if (hashset.Contains(currentNode))
                    return true;
                hashset.Add(currentNode);
                currentNode = currentNode.Next;
            } while (currentNode != null);
            return false;
        }

        [Test]
        public void EmptyListTest()
        {
            Node<int> root = null;
            Assert.IsFalse(HasListALoop(root));
        }

        [Test]
        public void ListWithOneElementTest()
        {
            var root = new Node<int> { Value = 1 };
            Assert.IsFalse(HasListALoop(root));
        }

        [Test]
        public void ListWithTwoElementsWithoutLoop()
        {
            var root = new Node<int> { Value = 1 };
            root.Next = new Node<int> { Value = 2 };
            Assert.IsFalse(HasListALoop(root));
        }
        
        [Test]
        public void ListWithTwoElementsWithLoop()
        {
            var root = new Node<int> { Value = 1 };
            root.Next = root;
            Assert.IsTrue(HasListALoop(root));
        }

        [Test]
        public void ListWithThreeElementsWithLoop()
        {
            var root = new Node<int> { Value = 1 };
            var node2 = new Node<int> { Value = 2 };
            var node3 = new Node<int> { Value = 3 };
            root.Next = node2;
            node2.Next = node3;
            node3.Next = node2;
            Assert.IsTrue(HasListALoop(root));
        }
    }
}
