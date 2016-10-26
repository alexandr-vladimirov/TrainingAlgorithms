using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ReverseSingleLinkedListTest
    {
        [Test]
        public void ReverseEmptyList()
        {
            var list = new SingleLinkedList<int>();
            list.Reverse();
        }

        [Test]
        public void ReverseListWithOneElement()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Reverse();
        }

        [Test]
        public void ReverseListWithTwoElements()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Reverse();
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(1, list[1]);
        }

        [Test]
        public void ReverseListWithFourElements()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Reverse();
            Assert.AreEqual(4, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(1, list[3]);
        }
    }
}
