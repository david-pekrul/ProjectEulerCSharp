using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler39
{
    /*
     * If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.

{20,48,52}, {24,45,51}, {30,40,50}

For which value of p ≤ 1000, is the number of solutions maximised?

     */
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> pToCount = new Dictionary<int, int>();
            HashSet<int> squareNumbers = new HashSet<int>();
            for (int i = 1; i < 1000; i++)
            {
                squareNumbers.Add(i * i);
            }


            for (int a = 1; a < 1000; a++)
            {
                
                int asquared = a * a;
                for (int b = a; b < 1000 && a + b < 1000; b++)
                {
                    double sqrt = Math.Sqrt(asquared + b * b);
                    if (sqrt % 1 == 0)
                    {
                        //Console.WriteLine("-" + sqrt);
                        int p = a + b + (int)sqrt;
                        if (p > 1000) continue;
                        if (pToCount.ContainsKey(p))
                        {
                            pToCount[p]++;
                        }
                        else
                        {
                            pToCount.Add(p, 1);
                        }
                    }
                }
            }


            int maxP = 0;
            int maxValues = 0;
            foreach(KeyValuePair<int,int> kvp in pToCount)
            {
               // Console.WriteLine("# " + kvp.Key + " : " + kvp.Value);

                if (kvp.Value > maxValues)
                {
                    maxValues = kvp.Value;
                    maxP = kvp.Key;
                }
            }

            Console.WriteLine("Answer: " + maxP);

        }
    }
}
