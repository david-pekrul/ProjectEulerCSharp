using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler57
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction firstFraction = new Fraction(1, 2);
            Fraction secondFraction = new Fraction(3, 2);
            int count = 0;
            for(int i = 3; i < 1000; i++)
            {
                BigInteger nextNumerator = secondFraction.numerator * 2 + firstFraction.numerator;
                BigInteger nextDenominator = secondFraction.numerator + secondFraction.denominator;

                Fraction nextFraction = new Fraction(nextNumerator, nextDenominator);
                if(nextFraction.moreDigitsInNumeratorThanDenominator())
                {
                    count++;
                }
                firstFraction = secondFraction;
                secondFraction = nextFraction;
            }
            Console.WriteLine(count);
        }

        class Fraction
        {
            public BigInteger numerator;
            public BigInteger denominator;
            public Fraction(BigInteger n, BigInteger d)
            {
                numerator = n;
                denominator = d;
            }

            public bool moreDigitsInNumeratorThanDenominator()
            {
                return numerator.ToString().Length > denominator.ToString().Length;
            }

        }
    }
}
