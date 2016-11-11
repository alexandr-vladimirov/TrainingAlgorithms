using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class FindMinSegmentWithMaxOrTest
    {
        public class Segment
        {
            public int LeftBorder { get; set; }
            public int RightBorder { get; set; }
            public int Length => RightBorder - LeftBorder;
        }

        public Segment FindMinSegmentWithMaxOr(int[] arr)
        {
            var maxOr = arr.Aggregate((res, cur) => res | cur);
            if (maxOr == 0)
                return new Segment { LeftBorder = 0, RightBorder = 0 };

            var maxOrBits = ToBitArray(maxOr);
            Segment minSegment = null;
            var start = 0;
            while (true)
            {
                var segment = FindNextSegmentWithMaxOr(start, arr, maxOrBits);
                if (segment == null)
                    break;
                if (minSegment == null || minSegment.Length > segment.Length)
                    minSegment = segment;
                start = minSegment.RightBorder + 1;
            }

            return minSegment;
        }

        private Segment FindNextSegmentWithMaxOr(int start, int[] arr, bool[] bitmap)
        {
            var bitCounts = new int[bitmap.Length];

            var right = start;
            while (right < arr.Length && !AllBitsExist(bitmap, bitCounts))
            {
                bitCounts = AddBits(arr[right], bitCounts);
                right++;
            }
            right--;

            if (!AllBitsExist(bitmap, bitCounts))
                return null;

            var left = start;
            while (AllBitsExist(bitmap, bitCounts))
            {
                bitCounts = RemoveBits(arr[left], bitCounts);
                left++;
            }
            left--;

            return new Segment { LeftBorder = left, RightBorder = right };
        }

        private int[] RemoveBits(int value, int[] bitCounts)
        {
            var bits = ToBitArray(value);
            for (var i = 0; i < bits.Length; i++)
                if (bits[i])
                    bitCounts[i]--;
            return bitCounts;
        }

        private int[] AddBits(int value, int[] bitCounts)
        {
            var bits = ToBitArray(value);
            for (var i = 0; i < bits.Length; i++)
                if (bits[i])
                    bitCounts[i]++;
            return bitCounts;
        }

        private bool AllBitsExist(bool[] bitmap, int[] bitCounts)
        {
            for (var i = 0; i < bitmap.Length; i++)
                if (bitmap[i] && bitCounts[i] == 0)
                    return false;
            return true;
        }

        private bool[] ToBitArray(int value)
        {
            var bits = new bool[32];
            var bit = 1;
            for (var i = 1; i < bits.Length; i++)
            {
                bits[i] = (value & bit) > 0;
                bit <<= 1;
            }
            return bits;
        }

        [TestCase("1 2 4", 0, 2)]
        [TestCase("1 2 4 3", 0, 2)]
        [TestCase("4 2 1 2 4 8 2", 2, 5)]
        [TestCase("0", 0, 0)]
        [TestCase("1 2 4 7", 3, 3)]
        public void FirstTest(string arrString, int leftBorder, int rightBorder)
        {
            var arr = arrString.Split(' ').Select(int.Parse).ToArray();
            var segment = FindMinSegmentWithMaxOr(arr);
            Assert.AreEqual(leftBorder, segment.LeftBorder);
            Assert.AreEqual(rightBorder, segment.RightBorder);
        }
    }
}
