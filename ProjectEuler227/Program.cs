using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler227
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.Priority = ThreadPriority.Lowest;
            double numberOfTrials = 10;
            double numberOfGames = 100000;
            int numberOfPlayers = 4;
            Dice d = new Dice();
            double totalRolls = 0;
            for (int x = 0; x < numberOfTrials; x++)
            {
                List<double> running = new List<double>();

                for (int i = 0; i < numberOfGames; i++)
                {
                    double rolls = playGame(numberOfPlayers, d);

                    running.Add(rolls);

                }


                Console.WriteLine("ANSWER: " + running.Average());
            }
        }

        static int playGame(int numberOfPlayers, Dice d)
        {
            //ZERO is not an allowed player number;
            int x = 1;
            int y = numberOfPlayers/2;
            
            int roll;
            int turns = 0;

            while(x != y)
            {
                roll = d.roll();
                if(roll == 1)
                {
                    x++;
                }else if (roll == 6)
                {
                    x--;
                }

                roll = d.roll();
                if (roll == 1)
                {
                    y++;
                }
                else if (roll == 6)
                {
                    y--;
                }

                if(x == 0)
                {
                    x = 100;
                }
                else if (x == (numberOfPlayers+1))
                {
                    x = 1;
                }
                if (y == 0)
                {
                    y = 100;
                }
                else if (y == (numberOfPlayers+1))
                {
                    y = 1;
                }
                turns++;

            }

            return turns;
        }
    }

    class Dice
    {
        private Random r;
        public Dice()
        {
            r = new Random();
        }

        public int roll()
        {
            return r.Next(0, 7);
        }
    }
}
