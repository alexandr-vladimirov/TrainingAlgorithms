using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class HaveTwoListsCommonItemsTest
    {
        public bool HaveTwoListsCommonItem<T>(Node<T> root1, Node<T> root2)
        {
            var hashset = new HashSet<T>();
            for (var node = root1; node != null; node = node.Next)
                hashset.Add(node.Value);

            for (var node = root2; node != null; node = node.Next)
                if (hashset.Contains(node.Value))
                    return true;

            return false;
        }

        [Test]
        public void TwoEmptyListsTest()
        {
            Node<int> root1 = null;
            Node<int> root2 = null;
            Assert.IsFalse(HaveTwoListsCommonItem(root1, root2));
        }

        [Test]
        public void EmptyAndNotEmptyListsTest()
        {
            Node<int> root1 = null;
            var root2 = new Node<int> { Value = 1 };
            Assert.IsFalse(HaveTwoListsCommonItem(root1, root2));
        }

        [Test]
        public void ListsWithoutCommonItems()
        {
            var root1 = new Node<int> { Value = 1 };
            root1.Next = new Node<int> { Value = 2 };
            var root2 = new Node<int> { Value = 10 };
            root2.Next = new Node<int> { Value = 20 };
            Assert.IsFalse(HaveTwoListsCommonItem(root1, root2));
        }

        [Test]
        public void ListsWithCommonItems()
        {
            var root1 = new Node<int> { Value = 1 };
            root1.Next = new Node<int> { Value = 2 };
            var root2 = new Node<int> { Value = 10 };
            root2.Next = new Node<int> { Value = 1 };
            Assert.IsTrue(HaveTwoListsCommonItem(root1, root2));
        }

        [Test]
        public void FirstListWithDuplicatesSecondWithoutCommonItems()
        {
            var root1 = new Node<int> { Value = 1 };
            root1.Next = new Node<int> { Value = 2 };
            root1.Next.Next = new Node<int> { Value = 2 };
            var root2 = new Node<int> { Value = 10 };
            root2.Next = new Node<int> { Value = 20};
            Assert.IsFalse(HaveTwoListsCommonItem(root1, root2));
        }
    }
}
