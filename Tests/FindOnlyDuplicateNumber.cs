using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    static class FindOnlyDuplicateNumber
    {
        public static int InArbitraryArray(int[] arr)
        {
            var hashset = new HashSet<int>();
            foreach (var value in arr)
            {
                if (hashset.Contains(value))
                    return value;
                hashset.Add(value);
            }
            throw new ArgumentException("There is no duplicate number");
        }

        /// <summary>
        /// Find duplicate number where numbers in range [1, M] and array length is M + 1
        /// </summary>
        public static int WhereNumbersInRange_1_ArrayLengthMinus1(int[] arr)
        {
            var maxValue = arr.Length - 1;
            var duplicate = arr.Sum() - maxValue * (maxValue + 1) / 2;
            return duplicate;
        }

        /// <summary>
        /// Find duplicate number where numbers in range [1, M] and array length is M
        /// </summary>
        public static int WhereNumbersInRange_1_ArrayLength(int[] arr)
        {
            var maxValue = arr.Length;
            var diff1 = arr.Sum() - maxValue * (maxValue + 1) / 2;
            var dist = Math.Abs(diff1);
            Func<int, bool> numberInEvenPart = x => (int)(1.0 * x / dist) % 2 == 0;
            var s1 = arr.Where(numberInEvenPart).Sum();
            var s2 = Enumerable.Range(1, maxValue).Where(numberInEvenPart).Sum();
            var diff2 = s1 - s2;
            return diff2 > 0 ? diff2 : diff1 - diff2;
        }
    }
}
