using System.Linq;
using NUnit.Framework;
using System.Numerics;

namespace Tests
{
    [TestFixture]
    public class CalcPerfectPermutationsTest
    {
        private BigInteger CalcPerfectPermutations(int n, int k)
        {
            if (n < 1 || k < 0 || k > n)
                return -1;
            var inversions = CalcInversions(n, k);
            var sum = inversions.Aggregate((res, x) => res += x);
            return sum;
        }

        /// <summary>
        /// Returns array of length (k + 1) where i-th element contains count of permutations with i inversions
        /// </summary>
        /// <param name="n">Permutation length</param>
        /// <param name="k">Max count of inversions</param>
        private BigInteger[] CalcInversions(int n, int k)
        {
            var result = new BigInteger[k + 1];
            result[0] = 1;

            for (int i = 2; i <= n; i++)
            {
                var buf = new BigInteger[k + 1];
                buf[0] = 1;
                for (int j = 1; j <= k; j++)
                {
                    buf[j] = buf[j - 1] + result[j];
                    if (j - i >= 0)
                        buf[j] -= result[j - i];
                }
                result = buf;
            }
            return result;
        }

        [TestCase(1, 0, new[] { 1 })]
        [TestCase(1, 1, new[] { 1, 0 })]
        [TestCase(2, 2, new[] { 1, 1, 0 })]
        [TestCase(3, 0, new[] { 1 })]
        [TestCase(3, 1, new[] { 1, 2 })]
        [TestCase(3, 3, new[] { 1, 2, 2, 1 })]
        [TestCase(4, 1, new[] { 1, 3 })]
        public void CalcInversionsTest(int n, int k, int[] expected)
        {
            var expectedBI = expected.Select(x => (BigInteger)x);
            var inversions = CalcInversions(n, k);
            CollectionAssert.AreEqual(expectedBI, inversions, string.Join(" ", inversions));
        }

        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 1)]
        [TestCase(2, 2, 2)]
        [TestCase(3, 0, 1)]
        [TestCase(3, 1, 3)]
        [TestCase(3, 3, 6)]
        [TestCase(4, 1, 4)]
        public void CalcPerfectPermutations(int n, int k, int expected)
        {
            Assert.AreEqual((BigInteger)expected, CalcPerfectPermutations(n, k));
        }
    }
}
