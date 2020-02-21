using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler164
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberWorking = 0;
            for(int i = 10; i <= 1000; i++)
            {
                if(digitSumsLessThanNine(i))
                {
                    Console.WriteLine(i);
                    numberWorking++;
                }
            }
            Console.WriteLine("Working: " + numberWorking);
        }

        static bool digitSumsLessThanNine(int num)
        {
            if(num >= 1000)
            {
                return false;
            }
            int sum = num%10;
            num/=10;
            sum += num%10;
            num /= 10;
            sum += num;
            return sum<=9;
        }
    }
}
