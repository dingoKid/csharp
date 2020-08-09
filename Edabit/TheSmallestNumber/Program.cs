using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace TheSmallestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Smallest(10));
        }

        public static string Smallest(int n)
		{
            if(n == 1) return "1";
            var primeDividers = new Dictionary<int, int>();
            var highestPoweredDividers = new Dictionary<int, int>();

            for(int i = 2; i <= n; i++)
            {
                primeDividers = GetPrimeFactors(i);
                highestPoweredDividers = UpdateHighestPoweredDividers(highestPoweredDividers, primeDividers);
            }
            return GetLCM(highestPoweredDividers);
		}
        private static string GetLCM(Dictionary<int, int> highestPoweredDividers)
        {
            BigInteger result = 1;
            foreach(var item in highestPoweredDividers.Keys)
            {
                result *= (BigInteger) Math.Pow(item, highestPoweredDividers[item]);
            }
            return result.ToString();
       	}
        static Dictionary<int, int> GetPrimeFactors(int number)
        {
            var primeFactors = new Dictionary<int, int>();
            int i = 2;
            while(true)
            {
                if(number == 1) break;
                if(number % i == 0)
                {
                    primeFactors = Add(primeFactors, i);
                    number /= i;
                    continue;
                }
                i++;
            }
            return primeFactors;
        }
        static Dictionary<int, int> UpdateHighestPoweredDividers(Dictionary<int, int> highestPoweredDividers, Dictionary<int, int> primeDividers)
        {
            foreach(var item in primeDividers.Keys)
            {
                if(highestPoweredDividers.Keys.Contains(item))
                {
                    highestPoweredDividers[item] = highestPoweredDividers[item] < primeDividers[item] ? primeDividers[item] : highestPoweredDividers[item];
                }
                else highestPoweredDividers.Add(item, primeDividers[item]);
            }
            return highestPoweredDividers;
        }
        static Dictionary<int, int> Add(Dictionary<int, int> list, int key)
        {
            if(list.Keys.Contains(key)) list[key]++;            
            else list.Add(key, 1);
            return list;
        }
    }

}

