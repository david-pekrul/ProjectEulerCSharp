using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler160
{
    /*
     * For any N, let f(N) be the last five digits before the trailing zeroes in N!.
For example,

9! = 362880 so f(9)=36288
10! = 3628800 so f(10)=36288
20! = 2432902008176640000 so f(20)=17664

Find f(1,000,000,000,000)

     */
    class Program
    {
        static Dictionary<BigInteger, int> frequency = new Dictionary<BigInteger, int>();
        static int maxFrequency = 1;
        static void Main(string[] args)
        {
            BigInteger start = 1;
            BigInteger upperLimit = 10000000; // 1.0 E 12
            //upperLimit = 100000; // 1.0 E 5
            for (BigInteger i = 1; i <= upperLimit; i++)
            {
                BigInteger mult = i % 100000;
                BigInteger temp = multiplyAndReturnFive(start, i%100000);
                if (i % 1000000 == 0)
                {
                    Console.WriteLine(i + "\t" + temp);
                }
                //Console.WriteLine(temp);
                start = temp;
            }
            Console.WriteLine("MaxFreq: " + maxFrequency);
            Console.WriteLine("Answer: " + start);
        }

        public static BigInteger multiplyAndReturnFive(BigInteger previous, BigInteger multiplicand)
        {
           // multiplicand = BigInteger.Pow(multiplicand, 7);
            //Console.WriteLine(multiplicand);

            if (multiplicand == 0) { return previous; }
            while (multiplicand % 10 == 0)
            {
                multiplicand /= 10;
            }

            if (!frequency.ContainsKey(multiplicand))
            {
                frequency.Add(multiplicand, 1);
            }
            else
            {
                frequency[multiplicand]++;
                if (frequency[multiplicand] > maxFrequency)
                {
                    maxFrequency = frequency[multiplicand];
                }
            }


            BigInteger answer = previous *= multiplicand;

            while (answer % 10 == 0)
            {
                answer /= 10;
            }

            string lastFive = "";
            string answerString = answer.ToString();
            int cutoff = 5;
            if (answerString.Length > cutoff)
            {
                lastFive = answerString.Substring(answerString.Length - cutoff);
            }
            else
            {
                lastFive = answerString;
            }

            return BigInteger.Parse(lastFive);
        }

        
    }
}
/*
 * Wrong Answers:
 * 49312
 * 
*/