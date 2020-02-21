using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

/*
 * What is most surprising is that the important mathematical constant,
e = [2; 1,2,1, 1,4,1, 1,6,1 , ... , 1,2k,1, ...].

The first ten terms in the sequence of convergents for e are:
2, 3, 8/3, 11/4, 19/7, 87/32, 106/39, 193/71, 1264/465, 1457/536, ...

The sum of digits in the numerator of the 10th convergent is 1+4+5+7=17.

Find the sum of digits in the numerator of the 100th convergent of the continued fraction for e.
 */
namespace ProjectEuler65
{
    class Program
    {
        static void Main(string[] args)
        {
            int countByThree = 3;//Starting with givens [2] and [2;1]=> 2 + (1/1)

            int k = 1;
            Fraction previous1 = new Fraction(3, 1);
            Fraction previous2 = new Fraction(2, 1);
            BigInteger nextNumerator = 0;
            BigInteger nextDenominator = 0;
            for(int i = 3; i < 101; i++)//this is an off by one problem that I don't plan on fixing...
            {
                //Console.WriteLine(i + "\t" + (i%3) + "\t" + previous1);
                //i => the ith fraction currently being calculated);
                switch (i%3)
                {
                    case 0:
                        nextNumerator = previous1.n * 2 * k + previous2.n;
                        nextDenominator = previous1.d * 2 * k + previous2.d;
                        k++;
                        break;
                    case 1:
                    case 2:
                        nextNumerator = previous1.n + previous2.n;
                        nextDenominator = previous1.d + previous2.d;
                        break;
                        
                }
                
                Fraction temp = new Fraction(nextNumerator, nextDenominator);
                previous2 = previous1;
                previous1 = temp;
            }

            Console.WriteLine("Last Numerator: " + previous1.n);

            int sum = 0;
            foreach(char c in previous1.n.ToString())
            {
                sum += Int16.Parse(c.ToString());
            }
            Console.WriteLine("Answer: " + sum);
        }

        class Fraction
        {
            public BigInteger n;
            public BigInteger d;
            public Fraction(BigInteger nu, BigInteger de)
            {
                n = nu;
                d = de;
            }

            public override string ToString()
            {
                return "[" + n + " / " + d + "]";
            }
        }
    }
}
