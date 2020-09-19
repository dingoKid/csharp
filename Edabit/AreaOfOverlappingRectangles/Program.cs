using System;
using System.Linq;

namespace AreaOfOverlappingRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            System.Console.WriteLine(OverlappingRectangles(new int[] { 2, 1, 3, 4 }, new int[] { 3, 2, 2, 5  }));
        }

        public static int OverlappingRectangles(int[] rect1, int[] rect2)
	    {
            var xIntervalOfRect1 = Enumerable.Range(rect1[0], rect1[2] + 1);
            var xIntervalOfRect2 = Enumerable.Range(rect2[0], rect2[2] + 1);
            var yIntervalOfRect1 = Enumerable.Range(rect1[1], rect1[3] + 1);
            var yIntervalOfRect2 = Enumerable.Range(rect2[1], rect2[3] + 1);
            var commonXinterval = xIntervalOfRect1.Intersect(xIntervalOfRect2);
            var commonYinterval = yIntervalOfRect1.Intersect(yIntervalOfRect2);
            if(commonXinterval.Count() < 2 && commonYinterval.Count() < 2) return 0;
            return (commonXinterval.Last() - commonXinterval.First()) * 
                (commonYinterval.Last() - commonYinterval.First());
	    }
    }
}
