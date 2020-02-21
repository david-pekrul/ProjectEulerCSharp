using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

/*We define the Matrix Sum of a matrix as the maximum sum of matrix elements with each element being the only one in his row and column. 
 * For example, the Matrix Sum of the matrix below equals 3315 ( = 863 + 383 + 343 + 959 + 767):

  7  53 183 439 863
497 383 563  79 973
287  63 343 169 583
627 343 773 959 943
767 473 103 699 303

Find the Matrix Sum of:

  7  53 183 439 863 497 383 563  79 973 287  63 343 169 583
627 343 773 959 943 767 473 103 699 303 957 703 583 639 913
447 283 463  29  23 487 463 993 119 883 327 493 423 159 743
217 623   3 399 853 407 103 983  89 463 290 516 212 462 350
960 376 682 962 300 780 486 502 912 800 250 346 172 812 350
870 456 192 162 593 473 915  45 989 873 823 965 425 329 803
973 965 905 919 133 673 665 235 509 613 673 815 165 992 326
322 148 972 962 286 255 941 541 265 323 925 281 601  95 973
445 721  11 525 473  65 511 164 138 672  18 428 154 448 848
414 456 310 312 798 104 566 520 302 248 694 976 430 392 198
184 829 373 181 631 101 969 613 840 740 778 458 284 760 390
821 461 843 513  17 901 711 993 293 157 274  94 192 156 574
 34 124   4 878 450 476 712 914 838 669 875 299 823 329 699
815 559 813 459 522 788 168 586 966 232 308 833 251 631 107
813 883 451 509 615  77 281 613 459 205 380 274 302  35 805
 */

//ANSWER: 13938 

namespace ProjectEuler345
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            short[,] bigArray = null;
            bool testCase = false;
            if (testCase)
            {
                bigArray = new short[,] { { 7, 53, 183, 439, 863 }, { 497, 383, 563, 79, 973 }, { 287, 63, 343, 169, 583 }, { 627, 343, 773, 959, 943 }, { 767, 473, 103, 699, 303 } };
            }
            else
            {
                bigArray = new short[,]{{7,   53,  183, 439, 863, 497, 383, 563, 79,  973, 287, 63,  343, 169, 583},
                                {627, 343, 773, 959, 943, 767, 473, 103, 699, 303, 957, 703, 583, 639, 913},
                                {447, 283, 463, 29,  23,  487, 463, 993, 119, 883, 327, 493, 423, 159, 743},
                                {217, 623, 3,   399, 853, 407, 103, 983, 89,  463, 290, 516, 212, 462, 350},
                                {960, 376, 682, 962, 300, 780, 486, 502, 912, 800, 250, 346, 172, 812, 350},
                                {870, 456, 192, 162, 593, 473, 915, 45,  989, 873, 823, 965, 425, 329, 803},
                                {973, 965, 905, 919, 133, 673, 665, 235, 509, 613, 673, 815, 165, 992, 326},
                                {322, 148, 972, 962, 286, 255, 941, 541, 265, 323, 925, 281, 601, 95,  973},
                                {445, 721, 11,  525, 473, 65,  511, 164, 138, 672, 18,  428, 154, 448, 848},
                                {414, 456, 310, 312, 798, 104, 566, 520, 302, 248, 694, 976, 430, 392, 198},
                                {184, 829, 373, 181, 631, 101, 969, 613, 840, 740, 778, 458, 284, 760, 390},
                                {821, 461, 843, 513, 17,  901, 711, 993, 293, 157, 274, 94,  192, 156, 574},
                                {34,  124, 4,   878, 450, 476, 712, 914, 838, 669, 875, 299, 823, 329, 699},
                                {815, 559, 813, 459, 522, 788, 168, 586, 966, 232, 308, 833, 251, 631, 107},
                                {813, 883, 451, 509, 615, 77,  281, 613, 459, 205, 380, 274, 302, 35,  805}};
            }

            int size = bigArray.GetLength(0);

            List<short[,]> anotherArray = new List<short[,]>();
            anotherArray.Add(bigArray);
            for (int i = 0; i < size; i++)
            {
                short[,] temp = (short[,])anotherArray[i].Clone();
                for (int j = 0; j + 1 < size; j++)
                {
                    temp = swapRows(temp, j, j + 1);
                }
                anotherArray.Add(temp);
            }


            int answer = 0;
            foreach (var a in anotherArray)
            {
                int aa = findAnswer(a);

                if (aa > answer)
                {
                    answer = aa;
                }
            }
            DateTime end = DateTime.Now;

            Console.WriteLine("ANSWER: " + answer);
            Console.WriteLine("Total Time: " + (end - start).TotalMilliseconds);
        }

        static int findAnswer(short[,] array)
        {
            int size = array.GetLength(0);
            int start = 0;

            while (start != (size - 1))
            {
                for (int width = 1; width + start < size; width++)
                {
                    //compare start with (start+width)
                    short TL = array[start, start];
                    short BR = array[start + width, start + width];
                    short TR = array[start, start + width];
                    short BL = array[start + width, start];
                    if ((TL + BR) < (TR + BL))
                    {
                        //swap rows
                        array = swapRows(array, start, start + width);
                        start--;
                        break;
                    }
                }
                start++;
            }


            int total = 0;
            for (int i = 0; i < size; i++)
            {
                total += array[i, i];
            }
            return total;
        }

        static short[,] swapRows(short[,] array, int firstRow, int secondRow)
        {
            int size = array.GetLength(0);

            Parallel.For(0, size, i =>
            {
                short temp = array[firstRow, i];
                array[firstRow, i] = array[secondRow, i];
                array[secondRow, i] = temp;
            });
            return array;
        }

        static short[,] swapColumns(short[,] array, int firstColumn, int secondColumn)
        {
            int size = array.GetLength(0);
            Parallel.For(0, size, i =>
            {
                short temp = array[i, firstColumn];
                array[i, firstColumn] = array[i, secondColumn];
                array[i, secondColumn] = temp;
            });
            return array;
        }

        static void printArray(short[,] array)
        {
            int i = array.GetLength(0);
            short count = 0;
            foreach (object value in array)
            {
                Console.Write(value + "\t");
                count++;
                if (count == i)
                {
                    Console.WriteLine();
                    count = 0;
                }

            }
        }

        static string arrayToString(short[,] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (short s in array)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }
    }
}