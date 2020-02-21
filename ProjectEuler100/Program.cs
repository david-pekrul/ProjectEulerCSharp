using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler100
{
    //THIS SHOULD BE PROBLEM 100
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(runFormula(15));
            double big = 412000000000;
            double limit = 1000000000000;
            //for (double a = 1; a < double.MaxValue; a++)
            //{
            //    double b = runFormula(a);
            //    ulong c = (ulong)b;
            //    if (c == b)
            //    {
            //        Console.WriteLine("works: " + a);
            //        if (a + b > 1000000000000)
            //        {
            //            Console.WriteLine("ANSWER: " + a + "\t" + b);
            //            break;
            //        }
            //    }
            //}

            double an1 = 1;
            double an2 = 3;
            double an3 = 0;

            bool done = false;
            while (!done)
            {
                //Console.WriteLine(an1);
                double six = 6 * an1;
                if (six < an1)
                {
                    throw new Exception("bork");
                }
                an3 = 6 * an1 - an2 - 2;

                double other = secondFormula(an3);
                Console.WriteLine(an3 + "\t" + other);
                if (an3 + other > limit)
                {
                    Console.WriteLine("ANSWER: " + an3);
                    done = true;
                    break;
                }
                an2 = an1;
                an1 = an3;

            }

        }
        //4411375203411

        static double secondFormula(double x)
        {
            double d = 2 * x * (x - 1);
            double sqrt = Math.Sqrt(d);
            double upper = Math.Ceiling(sqrt);
            return upper;
        }

        static double runFormula(double x)
        {
            double pow = Math.Pow(x - 0.5, 2);
            decimal pow2 = (decimal)pow;
            decimal underSqrt = (8 * pow2 - 1);
            if (underSqrt % 4 != 1)
            {
                return 0.3;
            }
            underSqrt /= 4;
            return Math.Sqrt((double)underSqrt) + 0.5;
        }
    }
}
