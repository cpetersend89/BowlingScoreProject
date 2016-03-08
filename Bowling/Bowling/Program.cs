using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            BowlingScore bs = new BowlingScore();
            bs.CalculateBowlingScores();

            //List<int[]> list2 = bs2.ConvertUnusedCharsToValues(scores);
            ////foreach (int[] a in list2)
            ////{
            ////    foreach (int i in a)
            ////    {
            ////        Console.WriteLine(i);
            ////    }
            ////}
            //List<int> strikes = bs2.CalcStrikes();
            //foreach (int strike in strikes)
            //{
            //    Console.WriteLine(strike);
            //}












            //BowlingScore bs = new BowlingScore();

            //int strikes = bs.CalcStrikes();
            //int spares = bs.CalcSpares();
            //int remaining = bs.CalcRemainingTotal();
            //int total = strikes + spares + remaining;

            //Console.WriteLine("Strikes: " + strikes);
            //Console.WriteLine("Spares: " + spares);
            //Console.WriteLine("Remaining: " + remaining);
            //Console.WriteLine("Total Score: " + total);






            Console.ReadKey();

        }
    }
}
