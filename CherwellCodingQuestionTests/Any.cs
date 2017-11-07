using System;

namespace CherwellCodingQuestionTests
{
    public static class Any
    {
        private static readonly Random _random = new Random();

        public static int IntBetween(int min = 0, int max = 65536)
        {
            return _random.Next(min, max);
        }

        public static int PositiveInt()
        {
            return IntBetween();
        }
    }
}
