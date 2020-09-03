using System;
using System.Collections.Generic;
using System.Linq;

namespace First_Missing_Positive_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MissingInteger(new int[]{3, 4, -1, 1, 2}));
        }

        static int MissingInteger(int[] numbers)
        {
            var positivePartOfList = new List<int>(numbers).Where(x => x > 0).OrderBy(x => x);
            int result = 1;
            while(true)
            {
                if(!positivePartOfList.Contains(result)) break;
                result++;
            }
            return result;
        }
    }
}
