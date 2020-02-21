using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace EulerLibrary
{
    public class Numbers
    {
        public static List<ulong> primes;
        public static List<BigInteger> primesBigInt;
        public static List<ulong> multiplicands;
        public static Dictionary<ulong, List<ulong>> numberToDivisors = new Dictionary<ulong, List<ulong>>();
        public static Dictionary<BigInteger, List<BigInteger>> numberToListOfPrimeFactors = new Dictionary<BigInteger, List<BigInteger>>();
        private static Dictionary<ulong, List<ulong>> numberToPrimeFactorization = new Dictionary<ulong, List<ulong>>();
        private static Dictionary<BigInteger, List<BigInteger>> numberToPrimeFactorizationBigInt = new Dictionary<BigInteger, List<BigInteger>>();
        public static object locking = new object();
        

        public Numbers() { }

        /// <summary>
        /// Creates a list of numbers that are prime and are less than upperBound.
        /// Note: 1000000000 (10E10) uses up too much memory!
        /// </summary>
        /// <param name="upperBound">The largest possible value (inclusive) of a prime in the list</param>
        /// <returns>a List containint ulong values of primes.</returns>
        public static List<BigInteger> findPrimesBelowBigInt(BigInteger upperBound)
        {

            try
            {
                BigInteger num = 0;
                List<BigInteger> prms = new List<BigInteger>();
                readPrimeList(ref num, ref prms, upperBound);
                if (num >= upperBound)
                {
                    Console.WriteLine("Using cached primes.");
                    primesBigInt = prms;
                    return prms;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Generating From Scratch");
                //There was not a successful file
            }

            LinkedList<BigInteger> listOfPrimes = new LinkedList<BigInteger>();
            //HashSet<BigInteger> primesThatArentTooBig = new HashSet<BigInteger>();

            listOfPrimes.AddFirst(2);

            for (ulong x = 3; x <= upperBound; x+=2)
            {
                bool isPrime = true;
                ulong sqrtOfNumber = (ulong)Math.Floor(Math.Sqrt(x));

                foreach (ulong prime in listOfPrimes)
                {
                    if (prime > sqrtOfNumber)
                    {
                        break;
                    }
                    if (x % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    listOfPrimes.AddLast(x);
                }

            }


            writePrimeList(upperBound, listOfPrimes.ToList<BigInteger>());
            return listOfPrimes.ToList<BigInteger>();
        }

        public static List<int> findPrimesBelowInt(int upperBound)
        {
            LinkedList<int> listOfPrimes = new LinkedList<int>();

            listOfPrimes.AddFirst(2);

            for (int x = 3; x <= upperBound; x += 2)
            {
                bool isPrime = true;
                int sqrtOfNumber = (int)Math.Floor(Math.Sqrt(x));

                foreach (int prime in listOfPrimes)
                {
                    if (prime > sqrtOfNumber)
                    {
                        break;
                    }
                    if (x % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    listOfPrimes.AddLast(x);
                }

            }

            return listOfPrimes.ToList<int>();
        }

        public static List<int> findPrimesBelowIntFAST(int upperBound)
        {
            LinkedList<int> listOfPrimes = new LinkedList<int>();

            listOfPrimes.AddFirst(2);

            for (int x = 3; x <= upperBound; x += 2)
            {
                if (isPrime(x))
                {
                    listOfPrimes.AddLast(x);
                }


            }

            return listOfPrimes.ToList<int>();
        }

       private static void writePrimeList(BigInteger upperBound, List<BigInteger> primes)
       {
           
           StreamWriter writer = new StreamWriter("C:\\primes.nbr",false);
           Console.WriteLine("Writing new primes to file");
           writer.WriteLine(upperBound);
           foreach (BigInteger number in primes)
           {
               writer.WriteLine(number);
           }
           writer.Close();
       }

       private static void readPrimeList(ref BigInteger up, ref List<BigInteger> list, BigInteger upperBound)
       {
           StreamReader reader = new StreamReader("C:\\primes.nbr");

           up = BigInteger.Parse(reader.ReadLine());
           if(up < upperBound)
           {
               Console.WriteLine("Not reading from file " + up + " < " + upperBound);
               throw new Exception("Not reading from file " + up + " < " + upperBound);
           }
           list = new List<BigInteger>();
           while (!reader.EndOfStream)
           {
               list.Add(BigInteger.Parse(reader.ReadLine()));
           }
       }



        //the old version that used ulongs
        public static List<ulong> findPrimesBelow(ulong upperBound)
        {
            LinkedList<ulong> listOfPrimes = new LinkedList<ulong>();

            listOfPrimes.AddFirst(2);

            for (ulong x = 3; x <= upperBound; x+=2)
            {
                bool isPrime = true;
                ulong sqrtOfNumber = (ulong)Math.Floor(Math.Sqrt(x));

                foreach (ulong prime in listOfPrimes)
                {
                    if (prime > sqrtOfNumber)
                    {
                        break;
                    }
                    if (x % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    listOfPrimes.AddLast(x);
                }

            }

            return listOfPrimes.ToList<ulong>();
        }

        public static List<ulong> findTriangularNumbersBelow(ulong upperBound)
        {
            return null;    
        }

        public static ulong ithTriangularNumber(ulong index)
        {
            double first = (double)(index);
            double second = (double)(index + 1) / 2.0;
            ulong triNumber = (ulong)(first * second);

            return triNumber;
        }

        public static List<ulong> findDivisors(ulong number)
        {
            List<ulong> divisors = new List<ulong>() {1};

            for (ulong x = 2; x <= number / 2 + 1; x++)
            {
                if (number % x == 0)
                {
                    divisors.Add(x);
                    //number = number / x;
                    //x--;
                }
            }
            if (number != 2)
            {
                divisors.Add(number);
            }

            return divisors;
        }

        public static List<ulong> findDivisors2(ulong number)
        {
            HashSet<ulong> divisors = new HashSet<ulong>() { 1 };
            ulong max = (ulong)Math.Ceiling(Math.Sqrt(number));

            for (ulong x = 2; x <= max; x++)
            {
                if (number % x == 0)
                {
                    divisors.Add(x);
                    if (numberToDivisors.ContainsKey(number / x))
                    {
                        foreach (ulong div in numberToDivisors[number / x])
                        {
                            divisors.Add(div);
                        }
                        break;
                    }
                }
            }
            if (number != 2)
            {
                divisors.Add(number);
            }

            if (!numberToDivisors.ContainsKey(number))
            {
                numberToDivisors.Add(number, divisors.ToList());
            }

            return divisors.ToList();
        }

        public static BigInteger findNumberOfPrimeFactorsExcludingOne(BigInteger number)
        {
            List<BigInteger> listOfPrimes = new List<BigInteger>(); //should not contain the number "1";
            BigInteger numberCopy = number;

            if (primesBigInt == null)
            {
                primesBigInt = Numbers.findPrimesBelowBigInt(1000000).ToList();
                primesBigInt.Remove(1);
            }
            
            BigInteger prime = 0;
            int index = 0;
            while (numberCopy != 1)
            {
                prime = primesBigInt[index];
                if (numberCopy % prime == 0)
                {
                    listOfPrimes.Add(prime);
                    numberCopy /= prime;

                    if (numberToListOfPrimeFactors.ContainsKey(numberCopy))
                    {
                        foreach (BigInteger num in numberToListOfPrimeFactors[numberCopy])
                        {
                            listOfPrimes.Add(num);
                        }
                        numberCopy = 1;
                    }

                }
                else
                {
                    index++;
                }
            }
            
            //Save this information so it can be used later!
            lock (locking)
            {
                numberToListOfPrimeFactors.Add(number, listOfPrimes);
            }

            //Convert list to a dictionary
            Dictionary<BigInteger, BigInteger> frequencyOfPrimes = new Dictionary<BigInteger, BigInteger>();
            foreach (BigInteger primeFactor in listOfPrimes)
            {
                if (frequencyOfPrimes.ContainsKey(primeFactor))
                {
                    frequencyOfPrimes[primeFactor]++;
                }
                else
                {
                    frequencyOfPrimes.Add(primeFactor, 1);
                }
            }

            /*
             * Essentially it boils down to if your 
             * number n = a^x * b^y * c^z (where a, b, and c are n's prime divisors and x, y, and z are the number of times that divisor is repeated) 
             * then the total count for all of the divisors is (x + 1) * (y + 1) * (z + 1).
                The exponents are the value in the dicitonary
             */
            BigInteger numberofFactors = 1;
            foreach (BigInteger num in frequencyOfPrimes.Values)
            {
                numberofFactors *= (num + 1);
            }



            return numberofFactors;
        }

        public static IEnumerable<ulong> getTriangularNumbers(ulong max)
        {
            ulong tri = 0;
            for (ulong x = 1; tri < max; x++)
            {
                tri += x;
                yield return tri;
            }
        }

        public static List<BigInteger> getTriangularNumbersBigInt(BigInteger max)
        {
            List<BigInteger> list = new List<BigInteger>();
            BigInteger number = 1;
            BigInteger increment = 2;
            while (number <= max)
            {
                list.Add(number);
                number += increment++;
            }
            return list;
        }

        //dunno if this actually works more efficiently or not :(
        public static List<ulong> getTriangularNumbers2(ulong max, ulong start)
        {
            ulong tri = 0;
            ulong lastI = 0;
            for (ulong i = 1; tri < start; i++)
            {
                lastI = i;
                tri += i;
            }
            LinkedList<ulong> triList = new LinkedList<ulong>();
            ulong haha = tri;
            for (ulong x = lastI+1; tri < max; x++)
            {
                tri += x;
                triList.AddLast(tri);
            }
            return triList.ToList();
        }

        /// <summary>
        /// Finds a set of the prime factors 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<ulong> findPrimeFactors(ulong number)
        {
            ulong originalNumber = number;
            if (primes == null)
            {
                throw new ArgumentNullException("The primes were not set up prior to calling this function.");
            }
            HashSet<ulong> divisors = new HashSet<ulong>() { 1 };

            foreach (ulong prime in primes)
            {
                while (number % prime == 0)
                {
                    number = number / prime;
                    divisors.Add(prime);
                    if (number == 1)
                    {
                        break;
                    }
                }
                if (numberToPrimeFactorization.ContainsKey(number))
                {
                    foreach (ulong primeFactor in numberToPrimeFactorization[number])
                    {
                        divisors.Add(primeFactor);
                    }
                    break;
                }
            }

            if (!numberToPrimeFactorization.ContainsKey(originalNumber))
            {
                lock (numberToPrimeFactorization)
                {
                    numberToPrimeFactorization.Add(originalNumber, divisors.ToList());
                }
            }

            return divisors.ToList();
        }

        public static List<BigInteger> findPrimeFactorsBigInt(BigInteger number)
        {
            BigInteger originalNumber = number;
            if (primes == null)
            {
                throw new ArgumentNullException("The primes were not set up prior to calling this function.");
            }
            HashSet<BigInteger> divisors = new HashSet<BigInteger>() { 1 };

            foreach (BigInteger prime in primes)
            {
                while (number % prime == 0)
                {
                    number = number / prime;
                    divisors.Add(prime);
                    if (number == 1)
                    {
                        break;
                    }
                }
                if (numberToPrimeFactorizationBigInt.ContainsKey(number))
                {
                    foreach (ulong primeFactor in numberToPrimeFactorizationBigInt[number])
                    {
                        divisors.Add(primeFactor);
                    }
                    break;
                }
            }

            if (!numberToPrimeFactorizationBigInt.ContainsKey(originalNumber))
            {
                lock (numberToPrimeFactorization)
                {
                    numberToPrimeFactorizationBigInt.Add(originalNumber, divisors.ToList());
                }
            }

            return divisors.ToList();
        }


        public static void prepareStaticPrimeList(ulong maxPrimeValue)
        {
            primes = findPrimesBelow(maxPrimeValue);
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
                int temp = Convert.ToInt32(aString[i]) - 48;
                countArray[temp]++;

                temp = Convert.ToInt32(bString[i]) - 48;
                countArray[temp]--;
            }
            foreach (byte count in countArray)
            {
                if (count != 0)
                {
                    return false;
                }
            }

            return true;
        }


        public static BigInteger findDeterminantOfMatrix(int[,] matrix)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            if(width != height)
            {
                throw new Exception("Not a Square Matrix!");
            }
            if(width == 1)
            {
                return matrix[0, 0];
            }

            if(width == 2)
            {
                return matrix[0, 0]*matrix[1, 1] - matrix[1, 0]*matrix[0, 1];
            }

            BigInteger total = 0;
            bool AddInsteadOfSubtract = true;
            for (int i = 0; i < width; i++)
            {
                BigInteger value = matrix[0, i];
                int[,] subMatrix = removeRowAndColumn(matrix, 0, i);
                BigInteger subDeterminant = findDeterminantOfMatrix(subMatrix);
                subDeterminant *= value;
                if(!AddInsteadOfSubtract)
                {
                    subDeterminant *= -1;
                }

                total += subDeterminant;

                AddInsteadOfSubtract = !AddInsteadOfSubtract;
            }


            return total;
        }

        public static int[,] removeRowAndColumn(int[,] array, int row, int column)
        {
            int size = array.GetLength(0);
            int[,] newArray = new int[size - 1, size - 1];

            int rowIndex = 0;

            for (int i = 0; i < size; i++)
            {
                if (i == row)
                {
                    continue;
                }
                int columnIndex = 0;
                for (int j = 0; j < size; j++)
                {
                    if (j == column)
                    {
                        continue;
                    }
                    newArray[rowIndex, columnIndex] = array[i, j];
                    columnIndex++;
                }
                rowIndex++;
            }

            return newArray;
        }



        public static bool isSquare(ulong n)
        {
            if (n < 0)
                return false;

            switch ((int)(n & 0xF))
            {
                case 0:
                case 1:
                case 4:
                case 9:
                    ulong tst = (ulong)Math.Sqrt(n);
                    return tst * tst == n;

                default:
                    return false;
            }
        }

        public static bool isPrime(int n)
        {
            if (n < 2)
                return false;
            if (n < 4)
                return true;
            if (n % 2 == 0)
                return false;
            if (n < 9)
                return true;
            if (n % 3 == 0)
                return false;
            if (n < 25)
                return true;

            int s = (int)Math.Sqrt(n);
            for (int i = 5; i <= s; i += 6)
            {
                if (n % i == 0)
                    return false;
                if (n % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a list of FactorTree
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static List<FactorTree> createFactorTree(int max)
        {
            List<int> primesList = Numbers.findPrimesBelowInt(max);
            HashSet<int> factorPrimes = new HashSet<int>(primesList);


            Console.WriteLine("Done calculating primes");

            List<FactorTree> trees = new List<FactorTree>();

            for (int i = 2; i <= max; i++)
            {
                if (factorPrimes.Contains(i))
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

            return trees;
        }

        private static Dictionary<int, int> factorialDictionary = new Dictionary<int, int>();
        public static int factorial(int n)
        {
            if(factorialDictionary.ContainsKey(n))
            {
                return factorialDictionary[n];
            }
            int fact = n * factorial(n - 1);
            factorialDictionary.Add(n, fact);
            return fact;
        }

        public static int nCr(int n, int r)
        {
            int nBang = factorial(n);
            int rBang = factorial(r);
            int nMinusRBang = factorial(n - r);
            return (nBang)/(rBang*nMinusRBang);
        }

        public static int[,] rref(int[,] matrix)
        {            
            int lead = 0, rowCount = matrix.GetLength(0), columnCount = matrix.GetLength(1);
            for (int r = 0; r < rowCount; r++)
            {
                if (columnCount <= lead) break;
                int i = r;
                while (matrix[i, lead] == 0)
                {
                    i++;
                    if (i == rowCount)
                    {
                        i = r;
                        lead++;
                        if (columnCount == lead)
                        {
                        lead--;
                        break;
                        }
                    }
                }
                for (int j = 0; j < columnCount; j++)
                {
                    int temp = matrix[r, j];
                    matrix[r, j] = matrix[i, j];
                    matrix[i, j] = temp;
                }
                int div = matrix[r, lead];
                for (int j = 0; j < columnCount; j++) matrix[r, j] /= div;                
                for (int j = 0; j < rowCount; j++)
                {
                    if (j != r)
                    {
                        int sub = matrix[j, lead];
                        for (int k = 0; k < columnCount; k++) matrix[j, k] -= (sub * matrix[r, k]);
                    }
                }
                lead++;
            }
            return matrix;
        }
    
    }

    public class FactorTree
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

        public List<int> getPrimeFactors()
        {
            List<int> pfs = new List<int>();
            FactorTree l = this;
            FactorTree previousL = null;
            while(l != null)
            {
                pfs.Add(l.right);
                previousL = l;
                l = l.left;   
            }
            pfs.Add(previousL.root);
            return pfs;
        }

        public List<int> getFactors()
        {
            List<int> pfs = new List<int>();
            FactorTree l = left;
            while (l != null)
            {
                pfs.Add(l.right);
                pfs.Add(l.root);
                l = l.left;
            }
            return pfs;
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
            if (d % 1 < .5m)
            {
                return i;
            }
            return i + 1;
        }


    }
}
