using System;

namespace Distribute_Bonuses
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetBonuses(new int[]{1, 2, 3, 2, 3, 5, 1});
            foreach(var item in result)
            {
                System.Console.WriteLine(item);
            }
        }

        static int[] GetBonuses(int[] performance)
        {
            if(performance is null)
            {
                System.Console.WriteLine("Parameter cannot be null!");
                return new int[0];
            }
            
            int[] result = new int[performance.Length];
            Array.Fill(result, 1);
            for(int i = 0; i < performance.Length - 1; i++)
            {
                if(performance[i] > performance[i + 1]) result[i]++;
                else if(performance[i] < performance[i + 1]) result[i+1]++;
            }
            return result;
        }
    }
}
