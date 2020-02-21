using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler26
{
    /*
     * 
     * A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

    1/2	= 	0.5
    1/3	= 	0.(3)
    1/4	= 	0.25
    1/5	= 	0.2
    1/6	= 	0.1(6)
    1/7	= 	0.(142857)
    1/8	= 	0.125
    1/9	= 	0.(1)
    1/10	= 	0.1

Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
*/
    class Program
    {
        static void Main(string[] args)
        {
            int maxEye = 1;
            int maxCycle = 0;
            for (int i = 3; i < 1000; i++)
            {
                Fraction test = new Fraction(i);
                int temp = test.findCycleLength();
                if (temp > maxCycle)
                {
                    maxEye = i;
                    maxCycle = temp;
                }
            }

            Console.WriteLine(maxEye);
        }
    }

    class Fraction
    {
        List<int> remainders;
        int powerOfTen;
        int denominator;
        int cycleLength;
        public Fraction(int d)
        {
            cycleLength = 0;
            denominator = d;
            remainders = new List<int>();
            if (d < 10)
            {
                powerOfTen = 10;
            }
            else if (d < 100)
            {
                powerOfTen = 100;
            }
            else
            {
                powerOfTen = 1000;
            }
        }

        public int findCycleLength()
        {
            int numerator = powerOfTen;
            int remainder = 0;

            while (true)
            {
                remainder = numerator % denominator;
                if (remainders.Contains(remainder))
                {
                    break;
                }
                else
                {
                    remainders.Add(remainder);
                }
                numerator = remainder * 10;
            }

            cycleLength = remainders.Count - remainders.IndexOf(remainder);

            return cycleLength;

        }
    }
}
