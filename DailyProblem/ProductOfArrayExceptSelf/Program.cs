using System;

namespace ProductOfArrayExceptSelf
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] val = Products(new int[]{1, 2, 3, 4, 5});
            foreach(var item in val)
             {
                 System.Console.WriteLine(item);
             }
        }

        static int[] Products(int[] array)
        {
            int[] result = new int[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                int product = 1;
                for(int j = 0; j < array.Length; j++)
                {
                    if(j != i) product *= array[j];
                }
                result[i] = product;
            }
            return result;
        }
    }
}
