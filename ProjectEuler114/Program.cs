using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler114
{
    class Program
    {
        static Dictionary<int, decimal> dictionary = new Dictionary<int, decimal>();
        static void Main(string[] args)
        {
            decimal test;
            test = waysToFillBlackBlocks(4, 3) + 1;
            Console.WriteLine(test);
            test = waysToFillBlackBlocks(7, 3) + 1;
            Console.WriteLine(test);
            test = waysToFillBlackBlocks(8, 3) + 1 ;
            Console.WriteLine(test);
            test = waysToFillBlackBlocks(50, 3) + 1;
            Console.WriteLine(test);

            F(50, 3);
            Console.WriteLine();
        }

        static decimal waysToFillBlackBlocks(int blackBlocks, int minRedBlockSize)
        {
            if(blackBlocks < -1)
            {
                return 0;
            }
            if (blackBlocks == -1)
            {
                return 1;
            }
            if (blackBlocks == 0)
            {
                return 1;
            }
            if (minRedBlockSize == blackBlocks)
            {
                return 2;
            }
            if (minRedBlockSize > blackBlocks)
            {
                return 1;
            }
            if(dictionary.ContainsKey(blackBlocks))
            {
                return dictionary[blackBlocks];
            }

            decimal ways = 0;
            for (int redBlockSize = minRedBlockSize; redBlockSize <= blackBlocks; redBlockSize++)
            {
                for (int startingIndex = 0; blackBlocks - startingIndex - redBlockSize >= 0; startingIndex++)
                {
                    int remainingBlackBlocks = blackBlocks - redBlockSize - 1 - startingIndex;

                    ways += waysToFillBlackBlocks(remainingBlackBlocks, minRedBlockSize);
                }
            }
            dictionary.Add(blackBlocks, ways);
            return ways;
        }

        static Dictionary<int, long> cache = new Dictionary<int, long>();
        private static long F(int m, int n)
        {

            //The rest is empty
            long solutions = 1;

            //we can't fill out more
            if (n > m) return solutions;

            if (cache.ContainsKey(m)) return cache[m];

            for (int startpos = 0; startpos <= m - n; startpos++)
            {
                for (int blocklength = n; blocklength <= m - startpos; blocklength++)
                {
                    solutions += F(m - startpos - blocklength - 1, n);
                }
            }

            cache[m] = solutions;
            return solutions;
        }
    }
}