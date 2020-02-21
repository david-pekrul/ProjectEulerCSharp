using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;

namespace ProjectEuler116
{
    class Program
    {

        
        static void Main(string[] args)
        {
            decimal startingBlack = 50;

            
            decimal total = 0;
            decimal answer = 0;
            int redSize = 2;
            int greenSize = 3;
            int blueSize = 4;



            //red = 2
            answer = combinationsForSize(startingBlack, 2);
            total += answer;
            Console.WriteLine("\t" + answer);
            //green = 3);
            answer = combinationsForSize(startingBlack, 3);
            total += answer;
            Console.WriteLine("\t" + answer);
            //blue = 4
            answer = combinationsForSize(startingBlack, 4);
            total += answer;
            Console.WriteLine("\t" + answer);
            answer = 0;

            Console.WriteLine(total);

        }

        static decimal combinationsForSize(decimal black, decimal size)
        {
            decimal answer = 0;
            for (decimal numberOfColor = 1; numberOfColor <= black / size; numberOfColor++)
            {
                decimal thisOne = nChoseR(black - (size * numberOfColor) + numberOfColor, numberOfColor);
               // Console.WriteLine(thisOne);
                if(thisOne <= 0)
                {
                    throw new Exception("" + numberOfColor);
                }
                answer += thisOne;
            }
            return answer;
        }

        static decimal nChoseR(decimal n, decimal r)
        {
            decimal numerator = 1;
            decimal denominator = 1;
            if(r > (n/2))
            {
                r = n - r;
            }

            for (decimal i = 1; i <= r; i++)
            {
                numerator *= (n - i + 1);
                denominator *= (r - i + 1);
            }
            if(numerator%denominator != 0)
            {
                throw new Exception("" + n + " \t " + r);
            }
            return numerator / denominator;

        }
    }
}
