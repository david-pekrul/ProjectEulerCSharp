using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.

Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:

    d2d3d4=406 is divisible by 2
    d3d4d5=063 is divisible by 3
    d4d5d6=635 is divisible by 5
    d5d6d7=357 is divisible by 7
    d6d7d8=572 is divisible by 11
    d7d8d9=728 is divisible by 13
    d8d9d10=289 is divisible by 17

Find the sum of all 0 to 9 pandigital numbers with this property.

 */
namespace ProjectEuler43
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> digits = new List<char>();
            digits.Add('0');
            digits.Add('1');
            digits.Add('2');
            digits.Add('3');
            digits.Add('4');
            digits.Add('5');
            digits.Add('6');
            digits.Add('7');
            digits.Add('8');
            digits.Add('9');

            string startingString = "";
            Stack<string> stack = new Stack<string>();
            stack.Push(startingString);
            double total = 0;
            while (stack.Count != 0)
            {
                string entry = stack.Pop();
                if(entry.Length == 10 && hasProperty(entry))
                {
                    Console.WriteLine(entry);
                    total += Double.Parse(entry);
                }
                if (hasProperty(entry))
                {
                    foreach(char c in digits)
                    {
                        if(!entry.Contains(c))
                        {
                            stack.Push(entry + c);
                        }
                    }
                    //add digits that are not in there
                }
            }

            Console.WriteLine("Total: " + total);
        }

        static bool hasProperty(string str)
        {
            
            int length = str.Length;
            if (length < 4)
            {
                return true;
            }
            int modNumber = 2;
            switch (length)
            {
                case 4: modNumber = 2; break;
                case 5: modNumber = 3; break;
                case 6: modNumber = 5; break;
                case 7: modNumber = 7; break;
                case 8: modNumber = 11; break;
                case 9: modNumber = 13; break;
                case 10: modNumber = 17; break;
                default: throw new Exception("Weird length");
            }

            //get last three digits and make a number;
            string lastThreeChar = str.Substring(str.Length - 3);
            int lastThreeNumber = Int32.Parse(lastThreeChar);

            return lastThreeNumber % modNumber == 0;

            
        }
    }
}
