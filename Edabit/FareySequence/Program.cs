using System;
using System.Collections;

namespace FareySequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = Farey(4);
            foreach(var item in res)
            {
                System.Console.WriteLine(item);
            }
        }

        public static string[] Farey(int n)
	{
			var sortedElements = new SortedList();
			string fraction;
			for(int i = 0; i <= n; i++)
			{
				for(int j = i; j <= n; j++)
				{
					if(j == 0) continue;
					fraction = i + "/" + j;
					if(!sortedElements.ContainsKey(i / (double) j))
					{
						sortedElements.Add(i / (double) j, fraction);
					}
				}
			}
			var values = sortedElements.GetValueList();
			var result = new string[sortedElements.Count];
			for(int i = 0; i < result.Length; i++)
			{
				result[i] = (string) values[i];
			}
			return result;
		}
    }
}
