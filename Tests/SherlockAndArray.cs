using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/sherlock-and-array
    /// </summary>
    class Solution
    {
        public static void Main(String[] args)
        {
            var T = int.Parse(Console.ReadLine());
            for (var t = 0; t < T; t++)
            {
                var n = int.Parse(Console.ReadLine());
                var numbers = Console.ReadLine().Split(' ').ToList().Select(int.Parse).ToArray();
                var exists = ExistsMiddleElement(numbers);
                Console.WriteLine(exists ? "YES" : "NO");
            }
        }

        public static bool ExistsMiddleElement(int[] numbers)
        {
            var leftSum = 0;
            var rightSum = numbers.Skip(1).Sum();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (leftSum == rightSum)
                    return true;
                
                leftSum += numbers[i];
                if (i + 1 < numbers.Length)
                    rightSum -= numbers[i + 1];
            }

            return false;
        }
    }
}
