using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using EulerLibrary;

namespace ProjectEuler119_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BigInteger> aList = new List<BigInteger>();
            int exponentLimit = 15;
            int count = 0;
            BigInteger thirtieth = 0;
            
            for (BigInteger i = 2; i <= 90; i++)
            {
                BigInteger powered = i;
                int exponent = 1;

                while (true)
                {
                    powered = timesAgain(powered, i);
                    exponent++;
                    BigInteger sum = sumOfDigits(powered);
                    if (sum == i)
                    {
                        Console.WriteLine("" + ++count + "\t" + i + "\t" + powered + "\t(" + exponent+ ")");
                        aList.Add(powered);
                        //break; //THIS IS INCORRECT. E.g. 18 => several numbers, not just 
                    }
                    if(thirtieth != 0 && powered > thirtieth)
                    {
                        break;
                    }
                    if (exponent >= exponentLimit && thirtieth == 0)
                    {
                        break;
                    }
                    
                }
                if(aList.Count >= 31)
                {
                    aList.Sort();
                    aList.RemoveAt(30);
                    thirtieth = aList[29];
                    Console.WriteLine("THIRTIETH: " + thirtieth);
                }
            }

            Console.WriteLine(aList.Count);
            aList.Sort();
            for (int i = 0; i < aList.Count; i++ )
            {
                Console.WriteLine((i+1) + "\t" + aList[i]);
            }

                Console.WriteLine(aList[29]);

        }

        static BigInteger timesAgain(BigInteger previousPower, BigInteger baseNumber)
        {
            return previousPower * baseNumber;
        }

        static BigInteger sumOfDigits(BigInteger number)
        {
            BigInteger sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
    }
}