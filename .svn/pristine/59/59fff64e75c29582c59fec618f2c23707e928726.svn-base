using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerLibrary;
using System.Numerics;

namespace ProjectEuler69
{
    /*
     * Euler's Totient function, φ(n) [sometimes called the phi function], is used to determine the number of numbers 
     * less than n which are relatively prime to n. For example, as 1, 2, 4, 5, 7, and 8, are all less than nine and relatively prime to nine, φ(9)=6.
n 	Relatively Prime 	φ(n) 	n/φ(n)
2 	1 	                1 	    2
3 	1,2 	            2 	    1.5
4 	1,3 	            2 	    2
5 	1,2,3,4 	        4 	    1.25
6 	1,5 	            2 	    3
7 	1,2,3,4,5,6 	    6 	    1.1666...
8 	1,3,5,7 	        4 	    2
9 	1,2,4,5,7,8 	    6 	    1.5
10 	1,3,7,9 	        4 	    2.5

It can be seen that n=6 produces a maximum n/φ(n) for n ≤ 10.

Find the value of n ≤ 1,000,000 for which n/φ(n) is a maximum.
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * THIS DOES NOT RUN IN A DECENT TIME! BUT I HAVE IT SOLVED!
     * [UPDATE: This does run!]
     * 
     * The numbers that are the best, in increasing order:
     * 
     * 6        = 2 * 3
     * 30       = 2*3*5
     * 210      = 2*3*5*7
     * 2310     = 2*3*5*7*11
     * 30030    =2*3*5*7*11 * 13
     * 510510   = 2*3*5*7*11*13*17  ====== FINAL ANSWER!!!
     * 
     * 
     * 
     */
    class Program
    {
        static Dictionary<Tuple<int, int>, int> dictionary = new Dictionary<Tuple<int, int>, int>();
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            int million = 10000000;
            

            List<int> primesList = Numbers.findPrimesBelowInt(million);
            HashSet<int> primes = new HashSet<int>(primesList);


            Console.WriteLine("Done calculating primes");

            List<FactorTree> trees = new List<FactorTree>();

            for (int i = 2; i <= million; i++)
            {
                if (primes.Contains(i))
                {
                    trees.Add(new FactorTree(i));
                    continue;
                }

                foreach (int j in primesList)
                {
                    if (i % j == 0)
                    {
                        trees.Add(new FactorTree(i, j, trees[(i / j - 2)]));
                        break;
                    }
                }
            }
            DateTime end = DateTime.Now;


            Console.WriteLine("Build Total Time: " + (end - start).TotalMilliseconds);
            Console.WriteLine("\n");

            start = DateTime.Now;
            double bestRatio = 0;
            int bestNumber = 0;
            double bestRatioSecond = 100000;
            int bestNumberSecond = 0;
            BigInteger sumOfPhis = 0;
            foreach (FactorTree tree in trees)
            {
                double phi = tree.calculatePhi();
                if(arePermutations((int)phi, tree.rootValue()))
                {
                    double ratioSecond = (tree.rootValue()*1.0)/phi;
                    if(bestRatioSecond > ratioSecond)
                    {
                        bestRatioSecond = ratioSecond;
                        bestNumberSecond = tree.rootValue();
                    }
                   //Console.WriteLine("PERMUTATION: " + "\t" + tree.rootValue() + "\t" + phi);
                }
               
                sumOfPhis += new BigInteger(phi);
                double ratio = (tree.rootValue() * 1.0) / phi;
                if (ratio > bestRatio)
                {
                    bestRatio = ratio;
                    bestNumber = tree.rootValue();
                }
            }
            end = DateTime.Now;

            Console.WriteLine("Total Time: " + (end - start).TotalMilliseconds);
            Console.WriteLine("\n");
            Console.WriteLine("Problem 69: " + bestNumber);
            Console.WriteLine("Problem 72: " + sumOfPhis);
            Console.WriteLine("Problem 70: " + bestNumberSecond);

        }

        public static bool arePermutations(int a, int b)
        {
            string aString = a.ToString();
            string bString = b.ToString();
            if (aString.Length != bString.Length)
            {
                return false;
            }
            byte[] countArray = new byte[10];
            for (int i = 0; i < aString.Length; i++)
            {
                int temp = Convert.ToInt32(aString[i])-48;
                countArray[temp]++;

                temp = Convert.ToInt32(bString[i])-48;
                countArray[temp]--;
            }
            foreach (byte count in countArray)
            {
                if(count != 0)
                {
                    return false;
                }
            }

            return true;
        }

        class FactorTree
        {
            FactorTree left;
            int right;
            int root;
            int phi;

            public FactorTree(int prime)
            {
                root = prime;
                left = null;
                right = 1;
                phi = 0;
            }

            public FactorTree(int nonPrime, int smallestPrimeFactor, FactorTree largestFactor)
            {
                root = nonPrime;
                left = largestFactor;
                right = smallestPrimeFactor;
                phi = 0;
            }


            public int rootValue()
            {
                return root;
            }

            public override string ToString()
            {
                string output = "" + root + "{" + right;
                if (left != null)
                {
                    output += ", " + left.root;
                }
                output += "}";
                return output;
            }

            public FactorTree nextTree()
            {
                return left;
            }

            public string recursiveOutput()
            {
                string output = "" + root + "{" + right;
                if (left != null)
                {
                    output += ", " + left.recursiveOutput();
                }
                output += "}";
                return output;
            }

            public int recursiveDepth()
            {
                int height = 1;
                if (left != null)
                {
                    height += left.recursiveDepth();
                }

                return height;
            }

            /// <summary>
            /// http://en.wikipedia.org/wiki/Euler's_totient_function#Computing_Euler.27s_function
            /// </summary>
            /// <returns></returns>
            public int calculatePhi()
            {
                HashSet<int> primeFactorsSet = new HashSet<int>();
                FactorTree temp = this;
                while (temp != null)
                {
                    if (temp.right == 1)
                    {
                        primeFactorsSet.Add(temp.root);
                    }
                    primeFactorsSet.Add(temp.right);
                    temp = temp.left;
                }
                primeFactorsSet.Remove(1);
                decimal fraction = 1;
                foreach (int primeFactor in primeFactorsSet)
                {
                    decimal dub = primeFactor;
                    fraction *= (1m - 1m / dub);
                }
                
                decimal phiDouble = root * fraction;

                string phiDoubleString = phiDouble.ToString();
                phiDoubleString = phiDoubleString.Substring(0, phiDoubleString.IndexOf('.'));

                phi = closestInteger(phiDouble);
                string phiString = phi.ToString();
                //if(phiString != phiDoubleString)
                //{
                    //Console.WriteLine(root + "\t | " + phi + "\t" + phiDoubleString + "\t" + phiDouble);
                //}
                return phi;
            }

            /// <summary>
            /// This method is used because of the inherent lack of precision of decimal points being rounded incorrectly when 
            /// converting between decimal, double, and int. I'm not sure of an exact way to calculate this, so I best-guessed it.
            /// </summary>
            /// <param name="d"></param>
            /// <returns></returns>
            private int closestInteger(decimal d)
            {
                string dstring = d.ToString();
                int i = Convert.ToInt32(dstring.Substring(0, dstring.IndexOf('.')));
                if(d % 1 < .5m)
                {
                    return i;
                }
                return i + 1;
            }

            
        }
    }
}
