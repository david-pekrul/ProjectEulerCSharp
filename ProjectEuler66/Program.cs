using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using EulerLibrary;
/*
 * 
 * 

Consider quadratic Diophantine equations of the form:

x2 – Dy2 = 1

For example, when D=13, the minimal solution in x is 649^2 – 13×180^2 = 1.

It can be assumed that there are no solutions in positive integers when D is square.

By finding minimal solutions in x for D = {2, 3, 5, 6, 7}, we obtain the following:

3^2 – 2×2^2 = 1
2^2 – 3×1^2 = 1
9^2 – 5×4^2 = 1 !
5^2 – 6×2^2 = 1
8^2 – 7×3^2 = 1

Hence, by considering minimal solutions in x for D ≤ 7, the largest x is obtained when D=5.

Find the value of D ≤ 1000 in minimal solutions of x for which the largest value of x is obtained.

 */

namespace ProjectEuler66
{
    class Program
    {
        static void Main(string[] args)
        {
            int million = 1000000;
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

            //the index is off by two.
            int count = 0;
            FactorTree oneHundred = trees[98];
            //trees.Reverse();
            foreach (FactorTree t in trees)
            {
                if(t.rootValue() % 1000 == 0)
                {
                    Console.WriteLine(t.rootValue());
                }
                for (int i = 1; i < t.rootValue() / 2; i++)
                {
                    if (t.isMultipleOf(i))
                    {
                        count++;
                        //Console.WriteLine(t.rootValue() + "\t" + i);
                    }
                }
            }
            Console.WriteLine(count);


        }

        class FactorTree
        {
            FactorTree left;
            int right;
            int root;
            int phi;
            private HashSet<int> divisors;

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

            public HashSet<int> getPrimeFactorsExcludingOne()
            {
                if (divisors != null)
                {
                    return divisors;
                }
                if(left == null)
                {
                    divisors = new HashSet<int>();
                }
                else
                {
                   // Console.Write(".");
                    HashSet<int> div = this.left.getPrimeFactorsExcludingOne();
                    div.Add(this.right);
                    divisors = div;    
                }
                
                
                return divisors;
            }

            public bool isMultipleOf(int value)
            {
                if(this.root == value)
                {
                    return true;
                }
                if(divisors == null)
                {
                    getPrimeFactorsExcludingOne();
                }
                return divisors.Contains(value);
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
                if (d % 1 < .5m)
                {
                    return i;
                }
                return i + 1;
            }


        }
    }
}
