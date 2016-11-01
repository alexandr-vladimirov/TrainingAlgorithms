using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class FindLongestLineSegmentTest
    {
        public static int FindLongestLineSegment(int[,] arr)
        {
            var n = (int)arr.GetLongLength(0);
            var hSegments = MaxHorizontalSegments(arr, n);
            var vSegments = MaxVerticalSegments(arr, n);

            int max = -1;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (arr[i, j] == 0)
                    {
                        var left = GetValue(hSegments, i, j - 1, n);
                        var right = GetValue(hSegments, i, j + 1, n);
                        var top = GetValue(vSegments, i - 1, j, n);
                        var bottom = GetValue(vSegments, i + 1, j, n);
                        var h = left + 1 + right;
                        var v = top + 1 + bottom;
                        max = Math.Max(max, h);
                        max = Math.Max(max, v);
                    }

            if (max == -1)
                return n;

            return max;
        }

        private static int[,] MaxVerticalSegments(int[,] arr, int n)
        {
            var vertSegments = new int[n, n];

            for (int j = 0; j < n; j++)
            {
                var first0 = -1;
                for (int second0 = 0; second0 <= n; second0++)
                    if (second0 == n || arr[second0, j] == 0)
                    {
                        for (int i = first0 + 1; i < second0; i++)
                            vertSegments[i, j] = second0 - first0 - 1;
                        first0 = second0;
                    }
            }
            return vertSegments;
        }

        private static int[,] MaxHorizontalSegments(int[,] arr, int n)
        {
            var horizSegments = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var first0 = -1;
                for (int second0 = 0; second0 <= n; second0++)
                    if (second0 == n || arr[i, second0] == 0)
                    {
                        for (int j = first0 + 1; j < second0; j++)
                            horizSegments[i, j] = second0 - first0 - 1;
                        first0 = second0;
                    }
            }
            return horizSegments;
        }

        public static int GetValue(int[,] arr, int i, int j, int n)
        {
            if (i < 0 || n <= i || j < 0 || n <= j)
                return 0;
            return arr[i, j];
        }

        [Test]
        public void FirstTest()
        {
            int[,] arr = new int[1, 1];

            arr[0, 0] = 1;
            Assert.AreEqual(1, FindLongestLineSegment(arr));

            arr[0, 0] = 0;
            Assert.AreEqual(1, FindLongestLineSegment(arr));
        }

        [Test]
        public void SecondTest()
        {
            int[,] arr = { { 1, 1 }, { 1, 1 } };
            Assert.AreEqual(2, FindLongestLineSegment(arr));
        }

        [Test]
        public void ThirdTest()
        {
            int[,] arr = { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
            Assert.AreEqual(3, FindLongestLineSegment(arr));
        }
    }
}
