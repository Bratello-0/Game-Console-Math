using System;

namespace Game4
{
    public static class IntExtension
    {
        private static Random random;
        public static int RandomNumber(this int start, int end)
        {
            random = new Random();
            return  random.Next(start, end);
        }
        public static int RandomNumber(this int start)
        {
            random = new Random();
            return random.Next() % start;
        }
    }
}
