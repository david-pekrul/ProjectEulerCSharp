using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler28
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong sum = 1;
            int squareSize = 1001;
            int MaxNumber = squareSize * squareSize;
            int numberToSkipTo = 2;
            int numbersInSquare = 0;

            for (int i = 3; i <= MaxNumber; i += numberToSkipTo)
            {
                numbersInSquare++;
                sum = sum + (ulong)i;

                if (numbersInSquare == 4)
                {
                    numbersInSquare = 0;
                    numberToSkipTo += 2;
                }
            }

            Console.WriteLine("Answer: " + sum);
        }
    }
}
