using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler74
{
    class Program
    {
        static Dictionary<int, int> numberToFactorial;
        static void Main(string[] args)
        {
            numberToFactorial = new Dictionary<int, int>();
            numberToFactorial.Add(0, 1);
            int f = 1;
            for (int i = 1; i < 10; i++)
            {
                f *= i;
                numberToFactorial.Add(i, f);
            }

            //Console.WriteLine(factorialSum(169));

            Dictionary<int, int> numberToChainLength = new Dictionary<int, int>();
            int million = 1000000;
            int exactlySixtyCount = 0;
            
            for (int i = 1; i < million; i++)
            {
                HashSet<int> seennumbers = new HashSet<int>();
                int number = i;
                int count = 0;
                while (!seennumbers.Contains(number))
                {
                    seennumbers.Add(number);
                    number = factorialSum(number);
                    count++;
                    if (numberToChainLength.ContainsKey(number))
                    {
                        count += numberToChainLength[number];
                        break;
                    }
                    
                }
                numberToChainLength.Add(i, count);
                
                if (count == 60)
                {
                    exactlySixtyCount++;
                    //Console.WriteLine("SIXTY: " + i);
                }

            }

            Console.WriteLine(exactlySixtyCount);
        }

        static int factorialSum(int number)
        {
            int sum = 0;
            string s = number.ToString();
            while (s != "")
            {
                sum += numberToFactorial[int.Parse(s[0].ToString())];
                s = s.Substring(1);
            }
            return sum;
        }
    }
}
