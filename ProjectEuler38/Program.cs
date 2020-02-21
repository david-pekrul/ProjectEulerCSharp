using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Take the number 192 and multiply it by each of 1, 2, and 3:

    192 × 1 = 192
    192 × 2 = 384
    192 × 3 = 576

By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576 the concatenated product of 192 and (1,2,3)

The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, which is the concatenated product of 9 and (1,2,3,4,5).

What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2, ... , n) where n > 1?

 */
namespace ProjectEuler38
{
    class Program
    {
        static List<char> digits = new List<char>();
            
        static void Main(string[] args)
        {
            digits.Add('1');
            digits.Add('2');
            digits.Add('3');
            digits.Add('4');
            digits.Add('5');
            digits.Add('6');
            digits.Add('7');
            digits.Add('8');
            digits.Add('9');

            for (int i = 2; i < 50000; i++)
            {
                string bldr = i.ToString();
                int j = 2;
                while (bldr.Length < 10)
                {
                    int postFix = i * j;
                    bldr += postFix;
                    if (isPandigital(bldr))
                    {
                        Console.WriteLine(i + "\t" + bldr);
                    }
                    j++;
                }
            }

        }

        static bool isPandigital(string str)
        {
            if (str.Length != 9)
            {
                return false;
            }
            foreach (char c in digits)
            {
                if (!str.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
