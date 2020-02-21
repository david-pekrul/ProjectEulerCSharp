using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.

 */
namespace ProjectEuler17
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dictionary = new Dictionary<int,int>();
            dictionary.Add(0, 0);
            dictionary.Add(1,3);
            dictionary.Add(2,3);
            dictionary.Add(3,5);
            dictionary.Add(4,4);
            dictionary.Add(5,4);
            dictionary.Add(6,3);
            dictionary.Add(7,5);
            dictionary.Add(8,5);
            dictionary.Add(9,4);
            dictionary.Add(10,3);
            dictionary.Add(11,6);
            dictionary.Add(12,6);
            dictionary.Add(13,8);
            dictionary.Add(14,8);
            dictionary.Add(15,7);
            dictionary.Add(16,7);
            dictionary.Add(17,9);
            dictionary.Add(18,8);
            dictionary.Add(19,8);
            dictionary.Add(20,6);
            dictionary.Add(30,6);
            dictionary.Add(40,5);
            dictionary.Add(50,5);
            dictionary.Add(60,5);
            dictionary.Add(70,7);
            dictionary.Add(80,6);
            dictionary.Add(90,6);

            int totalCount = 0;

            
            for (int i = 1; i < 1000; i++)
            {
                int thisCount = 0;
                int hundreds = (i % 1000 - i % 100)/100;
                if (hundreds != 0)
                {
                    thisCount += 7; //"hundred"
                    thisCount += dictionary[hundreds];
                }
                
                int lessThanHundreds = i - hundreds * 100;

                if (lessThanHundreds != 0)
                {
                    if (hundreds != 0)
                    {
                        thisCount += 3; //"and"
                    }
                    if (lessThanHundreds <= 20)
                    {
                        thisCount += dictionary[lessThanHundreds];
                    }
                    else
                    {
                        int ones = lessThanHundreds % 10;
                        int tens = (lessThanHundreds - ones);

                        thisCount += dictionary[ones];
                        thisCount += dictionary[tens];
                    }
                }
                Console.WriteLine(i + "\t" + thisCount);
                totalCount += thisCount;
            }
            totalCount += 11; //one thousand

            Console.WriteLine(totalCount);
        }
    }
}
