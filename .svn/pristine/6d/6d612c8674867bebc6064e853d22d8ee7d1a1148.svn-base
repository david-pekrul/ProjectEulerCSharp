using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
namespace ProjectEuler86
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<BigInteger> squares = new HashSet<BigInteger>();
            BigInteger largestSquare = 0;
            for(int i = 1; i < 1000000; i++)
            {
                BigInteger temp = i;
                temp = temp*temp;
                squares.Add(temp);
                largestSquare = temp;
            }

            int maxM = 100000;
            int countLimit = 1000000;
            int count = 0;
            for(int i = 1; i < maxM; i++)
            {
                BigInteger a = i;
                a = a*a;
                for(int j = 1; j <= i; j++)
                {
                    for(int k = j; k <= i; k++)
                    {
                        BigInteger b = j + k;
                        b = b*b;
                        b = b + a;
                        if(squares.Contains(b))
                        {
                            count++;
                            if(count >= countLimit)
                            {
                                Console.WriteLine("Answer: " + i);
                                return;
                            }
                        }
                        else if(b > largestSquare)
                        {
                            Console.WriteLine("TOO BIG! " + b);
                            return;
                        }
                    }
                }
                Console.WriteLine("i: " + i + "\t" + count);
            }
        }
    }
}
