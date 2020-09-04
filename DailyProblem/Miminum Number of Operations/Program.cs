using System;

namespace Miminum_Number_of_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinimumOperations(6, 19));
        }

        static int MinimumOperations(int x, int y)
        {
            int operations = 0;
            if(y < x) return x-y;
            if(y % 2 == 1) 
            {
                operations++;
                y++;
            }

            while(x <= y)
            {
                if(x == y) return operations;
                y /= 2;
                operations++;
            }
            operations = operations + x - y;
            return operations;
        }
    }
}
