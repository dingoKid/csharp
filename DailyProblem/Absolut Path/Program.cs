using System;
using System.Collections.Generic;
using System.Text;

namespace Absulut_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ShortestPath("/Users/Joma/Documents/../Desktop/./../"));
        }

        static string ShortestPath(string path)
        {
            if(path is null || path.Equals("")) return "Wrong path";
            string result;
            var stringArray = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var directories = new Stack<string>();
            try
            {
                foreach(var item in stringArray)
                {
                    if(item.Equals("..")) directories.Pop();
                    else if(item.Equals(".")) continue;
                    else directories.Push(item);
                }
            }
            catch(InvalidOperationException)
            {
                return "Invalid path";
            }
            stringArray = directories.ToArray();
            Array.Reverse(stringArray);
            result = String.Join('/', stringArray);
            return "/" + result + "/";
        }
    }
}