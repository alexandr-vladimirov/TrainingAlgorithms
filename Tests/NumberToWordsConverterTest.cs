using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class NumberToWordsConverterTest
    {
        [TestCase(0, "zero")]
        [TestCase(1, "one")]
        [TestCase(-1, "minus one")]
        [TestCase(10, "ten")]
        [TestCase(20, "twenty")]
        [TestCase(22, "twenty-two")]
        [TestCase(101, "one hundred and one")]
        [TestCase(1000, "one thousand")]
        [TestCase(1011, "one thousand and eleven")]
        [TestCase(1100, "one thousand, one hundred")]
        [TestCase(1112, "one thousand, one hundred and twelve")]
        [TestCase(1000001000, "one billion, one thousand")]
        [TestCase(1234567890, "one billion, two hundred and thirty-four million, five hundred and sixty-seven thousand, eight hundred and ninety")]
        public void Convert(int number, string britishExpected)
        {
            var americanActual = NumberToWordsConverter.Convert(number, Culture.American);
            var britishActual = NumberToWordsConverter.Convert(number, Culture.British);
            var americanExpected = britishExpected.Replace(" and", "");
            Assert.AreEqual(britishExpected, britishActual);
            Assert.AreEqual(americanExpected, americanActual);
        }
    }
}
