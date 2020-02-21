using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Peter has nine four-sided (pyramidal) dice, each with faces numbered 1, 2, 3, 4.
Colin has six six-sided (cubic) dice, each with faces numbered 1, 2, 3, 4, 5, 6.

Peter and Colin roll their dice and compare totals: the highest total wins. The result is a draw if the totals are equal.

What is the probability that Pyramidal Pete beats Cubic Colin? Give your answer rounded to seven decimal places in the form 0.abcdefg

 */
namespace ProjectEuler205
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("9 Pyramids");
            List<string> allpyrs = setBuilder(9, new List<string>() { "1", "2", "3", "4"});
            Dictionary<int, int> thingy = getScoreToRepetition(allpyrs);
            foreach (int score in thingy.Keys)
            {
                Console.WriteLine("Score: " +score + "\t - Number of Combinations: " + thingy[score]);
            }
            Console.WriteLine("-------------------");
            Console.WriteLine("6 Dice");
            List<string> allDice = setBuilder(6, new List<string>() { "1", "2", "3", "4", "5", "6" });
            thingy = getScoreToRepetition(allDice);
            foreach (int score in thingy.Keys)
            {
                Console.WriteLine("Score: " + score + "\t - Number of Combinations: " + thingy[score]);
            }

        }

        public static List<string> setBuilder(int numberOfRollableObjects, List<string> values)
        {
            List<string> allPyramidSets = new List<string>();

            Stack<string> buildingStack = new Stack<string>();
            foreach (string value in values)
            {
                buildingStack.Push(value);
            }
            while (buildingStack.Count != 0)
            {
                string current = buildingStack.Pop();
                if (current.Length == numberOfRollableObjects)
                {
                    allPyramidSets.Add(current);
                }
                else
                {
                    foreach (string value in values)
                    {
                        buildingStack.Push(current + value);
                    }
                }
            }

            return allPyramidSets;
        }

        public static Dictionary<int, int> getScoreToRepetition(List<string> input)
        {
            Dictionary<int, int> scoreToRepetition = new Dictionary<int, int>();


            foreach (string roll in input)
            {
                int value = scoreSet(roll);
                if (scoreToRepetition.ContainsKey(value))
                {
                    scoreToRepetition[value] += 1;
                }
                else
                {
                    scoreToRepetition.Add(value, 1);
                }
            }
            return scoreToRepetition;
        }

        public static int scoreSet(string input)
        {
            int value = 0;
            foreach (char c in input)
            {
                value += (Convert.ToInt32(c) - 48);
            }
            return value;
        }
    }
}
