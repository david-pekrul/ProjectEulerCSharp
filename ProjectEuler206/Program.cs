using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;

namespace ProjectEuler206
{
    class Program
    {
        static byte[] digits = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        static void Main(string[] args)
        {

          
            ulong minNumber = 1020304050607080900;
            ulong maxNumber = 1929394959697989990;

            DateTime start = DateTime.Now;
            ulong low = (ulong) Math.Floor(Math.Sqrt(minNumber));
            ulong high = (ulong) Math.Floor(Math.Sqrt(maxNumber));
            Console.WriteLine(low);
            Console.WriteLine(high);
            ulong num = low;

            while(num %100 != 30)
            {
                num++;
            }

            bool goToSeventy = true;
            while (num < high) 
            {
                ulong square = num*num;
                if(works(square))
                {
                    break;
                }
                //numbers ending in 70 and 30 are the only numbers that, when squared, can end in 900
                if(goToSeventy)
                {
                    //go to 70
                    num += 40;
                    goToSeventy = false;
                } else
                {
                    //goes to 30
                    num += 60;
                    goToSeventy = true;
                }

            }
            DateTime end = DateTime.Now;
            Console.WriteLine("NUM: " + num);
            Console.WriteLine("TIME: " + (end - start).TotalMilliseconds);


        }

        public static bool works(ulong square)
        {
            ulong number = 0;
            ulong copy = square;
            while(number != 1)
            {
                ulong next = copy%100;
                copy /= 100;
                if((next % 10) != number)
                {
                    return false;
                }
                if(number == 0)
                {
                    number = 9;
                }
                else
                {
                    number--;
                }

            }

            return true;
        }

        public static ulong spreadout(ulong num)
        {
            ulong result = 0;
            ulong powTen = 10;
            while(num != 0)
            {
                ulong nextNum = num%10;
                num = (num - nextNum)/10;
                result = result + nextNum*powTen;
                powTen *= 100;
            }
            return result;
        }

        public static ulong weave(ulong num)
        {
            ulong copy = num;
            ulong result = 0;
            ulong powTen = 10;
            ulong nextNumber = 0;
            for (int i = 0; i < 10; i++)
            {
                result = result + digits[9 - i] * powTen;
                powTen *= 10;
                nextNumber = copy % 10;
                copy = (copy - copy%10)/10;
                result = result + nextNumber*powTen;
                powTen *= 10;
            }

            return result;
        }
    }
}
