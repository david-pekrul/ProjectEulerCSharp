using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler104
{
    class Program
    {
        static long mod = 1000000000;
        static long modleft = mod * 1000000; // need to keep enough units of precision so that adding insignificant digits can trickle up
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            long f1Right = 1;
            long f1Left = 1;
            long f2Right = 1;
            long f2Left = 1;
            long fnextRight = 1;
            long fnextLeft = 1;

            int k = 2;

            while (!(isPandigital(fnextRight) && isPandigital(fnextLeft)))
            {
                k++;
                if(k < 0)
                {
                    throw new Exception("overflow");
                }
                f1Right = f2Right;
                f2Right = fnextRight;
                fnextRight = f2Right + f1Right;
                fnextRight = fnextRight%mod;

                f1Left = f2Left;
                f2Left = fnextLeft;

                fnextLeft = f2Left + f1Left;
                if(fnextLeft > modleft)
                {
                    fnextLeft /= 10;
                    f2Left /= 10;
                }
            }
            DateTime end = DateTime.Now;




            Console.WriteLine(k);
            Console.WriteLine("TIME: " + (end-start).TotalMilliseconds + " milliseconds");

        }

        static bool isPandigital(long number)
        {
             
            while(number > mod)
            {
                number /= 10;
            }
            HashSet<long> hash = new HashSet<long>();
            while(number > 0)
            {
                long n = number%10;
                number /= 10;
                if(n==0)
                {
                    return false;
                }
                if (hash.Contains(n))
                {
                    return false;
                }
                hash.Add(n);
            }
            return hash.Count == 9;
        }
    }
}
