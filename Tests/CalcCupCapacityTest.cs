using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CalcCupCapacityTest
    {
        public int CalcCupCapacity(int[] heights)
        {
            var maxIndex = FindMaxIndex(heights);
            var leftPart = heights.Take(maxIndex + 1).ToArray();
            var rightPart = heights.Skip(maxIndex).ToArray();
            Array.Reverse(rightPart);
            var leftCapacity = CalcCupCapacityHelper(leftPart);
            var rightCapacity = CalcCupCapacityHelper(rightPart);
            return leftCapacity + rightCapacity;
        }

        private int CalcCupCapacityHelper(int[] heights)
        {
            var capacity = 0;
            var left = heights[0];
            for (var i = 1; i < heights.Length; i++)
                if (heights[i] > left)
                    left = heights[i];
                else
                    capacity += left - heights[i];
            return capacity;
        }

        private int FindMaxIndex(int[] arr)
        {
            var max = arr[0];
            var maxIndex = 0;
            for (var i = 1; i < arr.Length; i++)
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
            return maxIndex;
        }

        [TestCase("1", 0)]
        [TestCase("1 2", 0)]
        [TestCase("1 2 3", 0)]
        [TestCase("3 2 1", 0)]
        [TestCase("2 1 3", 1)]
        [TestCase("4 1 3", 2)]
        [TestCase("1 2 3 2 1", 0)]
        [TestCase("3 2 1 0 1 2 3", 9)]
        [TestCase("3 2 4 1 3", 3)]
        public void CalcCupCapacity(string heightsString, int expectedCapacity)
        {
            var heights = heightsString.Split(' ').Select(int.Parse).ToArray();
            var actualCapacity = CalcCupCapacity(heights);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
    }
}
