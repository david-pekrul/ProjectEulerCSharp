using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler25
{
    /*

     The Fibonacci sequence is defined by the recurrence relation:

    Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.

Hence the first 12 terms will be:

    F1 = 1
    F2 = 1
    F3 = 2
    F4 = 3
    F5 = 5
    F6 = 8
    F7 = 13
    F8 = 21
    F9 = 34
    F10 = 55
    F11 = 89
    F12 = 144

The 12th term, F12, is the first term to contain three digits.

What is the first term in the Fibonacci sequence to contain 1000 digits?

     */
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger a = 1;
            BigInteger b = 1;
            BigInteger fib = 1;
            bool done = false;
            int count = 2;
            while (!done)
            {
                count++;
                fib = a + b;
                b = a;
                a = fib;
                //Console.WriteLine(count + " - " + fib );
                if (fib.ToString().Length >= 1000)
                {
                    done = true;
                }
            }
            Console.WriteLine(count);
        }
    }
}
