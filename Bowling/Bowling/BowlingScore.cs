using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class BowlingScore
    {
        private string _score;
        private int _total;
        FileReader fr = new FileReader(@"../../Scores.txt");
        FileWriter fw = new FileWriter(@"../../Totals.txt");
        public BowlingScore()
        {

        }

        public BowlingScore(string score, int total)
        {
            _score = score;
            _total = total;
        }

        public int[] ConvertCharsToValues(params char[] characters)
        {
            int[] scores = new int[characters.Length + 2];
            for (int i = 0; i < characters.Length; i++)
            {
                int.TryParse(characters[i].ToString(), out scores[i]);
                if (characters[i] == 'X')
                {
                    scores[i] = 10;
                }
                if (characters[i] == '/')
                {
                    scores[i] = 10 - scores[i - 1];
                }
            }
            return scores;
        }
        public int[] ConvertUnusedCharsToValues(params char[] characters)
        {
            int[] scores = new int[characters.Length + 1];
            for (int i = 0; i < characters.Length; i++)
            {
                int.TryParse(characters[i].ToString(), out scores[i]);
                if (characters[i] == 'X')
                {
                    scores[i] = 0;
                }
                if (characters[i] == '/')
                {
                    scores[i] = 0;
                    scores[i - 1] = 0;
                }
            }
            return scores;
        }
        public int CalcStrikes(char[] characters)
        {
            int total = 0;
            int[] scores = ConvertCharsToValues(characters);
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] == 'X')
                {
                    total += scores[i] + scores[i + 1] + scores[i + 2];
                }
            }
            if (characters[characters.Length - 1] == 'X' && characters[characters.Length - 2] == 'X')
            {
                return total - 30;
            }
            if (characters[characters.Length - 1] != 'X' && characters[characters.Length - 2] == 'X')
            {
                return total - 10 - scores[characters.Length - 1];
            }
            else
            {
                return total;
            }
        }
        public int CalcSpares(char[] characters)
        {
            int total = 0;
            int[] scores = ConvertCharsToValues(characters);
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] == '/')
                {
                    total += scores[i - 1] + scores[i] + scores[i + 1];
                }
            }
            return total;
        }
        public int CalcRemainingTotal(char[] characters)
        {
            int total = 0;
            int[] score = ConvertUnusedCharsToValues(characters);
            for (int i = 0; i < score.Length; i++)
            {
                total += score[i];
            }
            return total - score[characters.Length - 1];
        }

        public void CalculateBowlingScores()
        {
            List<char[]> originalScores = fr.ReadListFromFile();
            List<int> totals = new List<int>();
            List<BowlingScore> bowlingScores = new List<BowlingScore>();
            foreach (char[] originalScore in originalScores)
            {
                int strikes = CalcStrikes(originalScore);
                int spares = CalcSpares(originalScore);
                int remaining = CalcRemainingTotal(originalScore);
                int total = strikes + spares + remaining;
                string charArrayToString = new string(originalScore);
                bowlingScores.Add(new BowlingScore(charArrayToString, total));
                Console.WriteLine(total);
                totals.Add(total);
            }
            foreach (BowlingScore bowlingScore in bowlingScores)
            {
                fw.WriteToFile(bowlingScore);
            }
        }

        public override string ToString()
        {
            return $"{_score}, {_total}";

        }
    }
}
