using System;
using System.Linq;
using System.Collections.Generic;

namespace PokerHandRanking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static string PokerHandRanking(string[] hand)
	    {
			string ranking = string.Empty;
			var set = new HashSet<char>(hand.ToList().Select(x => x.Last()));
			bool sameSuite = set.Count > 1 ? false : true;
			var cards = new Dictionary<string, int>();
			var figures = hand.ToList().Select(x => x.Substring(0, x.Length-1));
			
			foreach(var item in figures)
			{
				if(!cards.ContainsKey(item)) cards.Add(item, 1);
				else cards[item]++;
			}
			int numberOfDifferentKinds= cards.Values.Count;
			
			switch(numberOfDifferentKinds)
			{
				case 2: ranking = cards.Values.Contains(4) ? "Four of a Kind" : "Full House";
				break;
				case 3: ranking = cards.Values.Max() == 3 ? "Three of a Kind" : "Two Pair";
				break;
				case 4: ranking = "Pair";
				break;				
				case 5: if(figures.Select(x => x.First()).Any(y => char.IsNumber(y)) && figures.Select(w => w.First()).Any(z => char.IsLetter(z)))
						{	
							if(figures.Where(x => char.IsNumber(x.First())).Count() == 1 && figures.Contains("10"))
							{
								ranking = sameSuite == true ? "Royal Flush" : "Straight";
							}
							else ranking = sameSuite == true ? "Flush" : "High Card";
						}
						else
						{
							var sortedFigures = figures.Select(x => int.Parse(x)).OrderBy(x => x);
							ranking = sortedFigures.SequenceEqual(Enumerable.Range(sortedFigures.Min(), 5)) ? 
										sameSuite == true ? "Straight Flush" : "Straight"
										: sameSuite == true ? "Flush" : "High Card";
						}
				break;
			}			
			return ranking;
		}
    }
}
