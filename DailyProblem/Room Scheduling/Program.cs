using System;
using System.Collections.Generic;
using System.Linq;

namespace Room_Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[]{3, 7};
            int[] arr1 = new int[]{0, 5};
            int[] arr2 = new int[]{5, 9};
            int[][] array = new int[][]{arr, arr1, arr2};
            Console.WriteLine(CreateSchedule(array));
        }

        static int CreateSchedule(int[][] intervals)
        {
            int roomsNeeded = 1;
            int counter;
            var current = new List<int>();
            foreach(var list in intervals)
            {
                current.AddRange(CreateList(list));
            }
            current.Sort();
            
            while(current.Count != 0)
            {
                counter = current.Count;
                current = current.SkipWhile(x => x.Equals(current.First())).ToList();
                counter -= current.Count;
                if(counter > roomsNeeded) roomsNeeded = counter;
            }
            return roomsNeeded;
        }

        static List<int> CreateList(int[] tuple)
        {

            return new List<int>(Enumerable.Range(tuple[0], tuple[1] - tuple[0] + 1));
        }
    }
}
