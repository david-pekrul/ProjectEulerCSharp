using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
/*
We can easily verify that none of the entries in the first seven rows of Pascal's triangle are divisible by 7:
  	  	  	  	  	  	 1
  	  	  	  	  	 1 	  	 1
  	  	  	  	 1 	  	 2 	  	 1
  	  	  	 1 	  	 3 	  	 3 	  	 1
  	  	 1 	  	 4 	  	 6 	  	 4 	  	 1
  	 1 	  	 5 	  	10 	  	10 	  	 5 	  	 1
1 	  	 6 	  	15 	  	20 	  	15 	  	 6 	  	 1

However, if we check the first one hundred rows, we will find that only 2361 of the 5050 entries are not divisible by 7.

Find the number of entries which are not divisible by 7 in the first one billion (10^9) rows of Pascal's triangle.

 */
namespace ProjectEuler148generator
{
    class Program
    {
        static void Main(string[] args)
        {

            //TODO: Get 100 working.
            BigInteger total = 0;
            BigInteger maxRows = 1000000000;
            BigInteger rowNumber = 0;
            BigInteger value = 0;
            BigInteger thingy = 1;
            BigInteger xtimesbaseValue = 0;
            BigInteger width = 1;
            //BigInteger multi = 0;
            int modValue = 1000000;
            bool firstLoop = true;
            int multistart = 1;

            bool done = false;
            
            while(!done)
            {
                //baseValue += baseIncrement;
                //if (baseValue > baseIncrementTimesSeven)
                //{
                //    baseIncrement += thingy;
                //    if (baseIncrement == 8) 
                //    {
                //        baseIncrement = powerOfTwo;
                //        powerOfTwo *= 2;
                //        thingy *= 2;
                //    }
                //    baseValue = baseIncrement;
                //    baseIncrementTimesSeven = baseIncrement * 7;
                    
                //}
                for (BigInteger baseintWrap = 1; baseintWrap < 1000000000; baseintWrap++)
                {
                    if (done) { break; }
                    for (BigInteger multi = multistart; multi % 8 != 0; multi += multistart)
                    {
                        if (done) { break; }
                        for (BigInteger baseint = 1; baseint < 8; baseint++)
                        {
                            if (done) { break; }
                            for (byte x = 1; x <= 7; x++)
                            {
                                xtimesbaseValue = x * baseint * multi * baseintWrap;
                                if (done) { break; }
                                for (byte y = 1; y <= 7; y++)
                                {
                                    if (rowNumber == maxRows)
                                    {
                                        done = true;
                                        break;
                                    }
                                    rowNumber++;
                                    value = xtimesbaseValue * y;

                                    if (rowNumber % modValue == 0)
                                    {
                                        Console.Write("#: " + rowNumber / modValue);
                                        Console.Write("\tx: " + x);
                                        Console.Write("\ty: " + y);
                                        Console.Write("\tm: " + multi);
                                        Console.Write("\tbi: " + baseint);
                                        Console.Write("\tt: " + thingy);
                                        Console.Write("\tw: " + baseintWrap);
                                        Console.Write("\tv: " + value);
                                        Console.WriteLine();
                                    }
                                    total += value;
                                }
                            }
                            //Console.WriteLine();
                        }
                    }
                }

            }

            Console.WriteLine("#: " + rowNumber + "\ttotal: " + total);
        }
    }
}
