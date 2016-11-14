using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class FindOnlyDuplicateNumberTest
    {
        [TestCase("1 1 2 3", 1)]
        [TestCase("-1 1 2 -1", -1)]
        public void InArbitraryArray(string numbersString, int duplicate)
        {
            var numbers = numbersString.Split(' ').Select(int.Parse).ToArray();
            Assert.AreEqual(duplicate, FindOnlyDuplicateNumber.InArbitraryArray(numbers));
        }

        [TestCase("1 1 2 3", 1)]
        [TestCase("1 2 3 3", 3)]
        public void WhereNumbersInRange_1_ArrayLengthMinus1(string numbersString, int duplicate)
        {
            var numbers = numbersString.Split(' ').Select(int.Parse).ToArray();
            Assert.AreEqual(duplicate, FindOnlyDuplicateNumber.WhereNumbersInRange_1_ArrayLengthMinus1(numbers));
        }

        [TestCase("1 1 3", 1)]
        [TestCase("2 2 3", 2)]
        [TestCase("2 3 4 4", 4)]
        [TestCase("1 1 2 4", 1)]
        public void WhereNumbersInRange_1_ArrayLength(string numbersString, int duplicate)
        {
            var numbers = numbersString.Split(' ').Select(int.Parse).ToArray();
            Assert.AreEqual(duplicate, FindOnlyDuplicateNumber.WhereNumbersInRange_1_ArrayLength(numbers));
        }
    }
}
