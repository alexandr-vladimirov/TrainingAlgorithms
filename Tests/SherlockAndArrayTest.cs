using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SherlockAndArrayTest
    {
        [TestCase("1 2 3", false)]
        [TestCase("1 2 3 3", true)]
        [TestCase("1", true)]
        [TestCase("1 2", false)]
        [TestCase("1 1 -1", true)]
        [TestCase("1 -1 0", true)]
        [TestCase("1 -2 0", false)]
        public void ExistsMiddleElement(string numbersLine, bool expectedExists)
        {
            var numbers = numbersLine.Split(' ').Select(int.Parse).ToArray();
            Assert.AreEqual(expectedExists, Solution.ExistsMiddleElement(numbers));
        }
    }
}
