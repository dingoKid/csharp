using System;
using System.Linq;

namespace Valid_Mountain_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ValidMountainArray(new int[]{-1, -2, -2, -1}));
        }

        static bool ValidMountainArray(int[] heights)
        {
            if(heights.Length == 0 || heights is null) return false;
            var firstNumber = heights.First();
            var result = heights.SkipWhile(x => x <= firstNumber);
            return result.Any(x => x < result.First());
        }
    }
}
