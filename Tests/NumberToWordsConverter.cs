using System;

namespace Tests
{
    public enum Culture
    {
        American,
        British
    }

    public static class NumberToWordsConverter
    {
        public static string Convert(int number, Culture culture = Culture.American)
        {
            if (number == 0) return "zero";
            if (number < 0) return "minus " + Convert(-number, culture);

            var words = "";
            var digitsCount = (int)Math.Truncate(Math.Log10(number)) + 1;
            var threeDigitBlocksCount = (int)Math.Ceiling(digitsCount / 3.0);
            for (var blockNumber = threeDigitBlocksCount - 1; blockNumber >= 0; blockNumber--)
            {
                var blockValue = GetThreeDigitBlock(number, blockNumber);
                if (blockValue == 0) continue;
                var blockWords = ThreeDigitNumberToWords(blockValue, culture);
                var delimeter = GetBlocksDelimeter(culture, blockNumber, threeDigitBlocksCount, blockValue);
                words += delimeter + " " + blockWords + " " + blockNames[blockNumber];
            }
            return words.Trim();
        }

        private static string GetBlocksDelimeter(Culture culture, int blockNumber, int blocksCount, int blockValue)
        {
            var isHighestBlock = blockNumber == blocksCount - 1;
            var isLowestBlock = blockNumber == 0;
            var isMiddleBlock = !isHighestBlock && !isLowestBlock;

            if (isHighestBlock) return "";
            if (isMiddleBlock) return ",";
            if (blockValue >= 100) return ",";
            if (culture == Culture.British) return " and";
            return "";
        }

        private static int GetThreeDigitBlock(int number, int blockNumber)
        {
            var result = (int)Math.Truncate(number / Math.Pow(1000, blockNumber));
            result %= 1000;
            return result;
        }

        private static string ThreeDigitNumberToWords(int n, Culture culture)
        {
            var hundreds = n / 100;
            var rest = n - hundreds * 100;
            var hundredWords = hundreds > 0 ? from0To19[hundreds] + " hundred" : "";
            var delimeter = (culture == Culture.British && hundreds > 0 && rest > 0) ? " and" : "";
            var restWords = rest > 0 ? " " + DoubleDigitNumberToWords(rest) : "";
            var words = hundredWords + delimeter + restWords;
            return words.Trim();
        }

        private static string DoubleDigitNumberToWords(int n)
        {
            if (n <= 19) return from0To19[n];
            var tens = n / 10;
            var units = n - tens * 10;
            var tenWords = tensNames[tens - 2];
            var unitWords = units > 0 ? "-" + from0To19[units] : "";
            return tenWords + unitWords;
        }

        private static string[] blockNames = { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion" };
        private static string[] tensNames = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static string[] from0To19 =
        {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "forteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };
    }
}
