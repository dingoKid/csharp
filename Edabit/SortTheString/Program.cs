using System;
using System.Collections.Generic;
using System.Linq;

namespace SortTheString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sorting("846ZIbo"));
        }

        public static string sorting(string str) 
        {
            var list = str.ToList();
            list.Sort();
            var numbers = list.FindAll(x => char.IsDigit(x));
            var lowerCaseLetters = list.Where(x => char.IsLower(x));
            var upperCaseLetters = list.Where(x => char.IsUpper(x)).Select(x => char.ToLower(x));
            var allLetters = lowerCaseLetters.Union(upperCaseLetters).OrderBy(x => x);

            var result = new List<char>();
            foreach(var item in allLetters)
            {
                if(lowerCaseLetters.Contains(item)) result.Add(item);
                if(upperCaseLetters.Contains(item)) result.Add(char.ToUpper(item));
            }
            result.AddRange(numbers);
            return string.Join("", result);
        }
    }
}
