using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler31
{
    //LOOK FOR INSPIRATION HERE: 
    //http://mathforum.org/library/drmath/view/54333.html

    class Program
    {
        static Dictionary<int, BigInteger> ones = new Dictionary<int, BigInteger>();
        static Dictionary<int, BigInteger> twos = new Dictionary<int, BigInteger>();
        static Dictionary<int, BigInteger> fives = new Dictionary<int, BigInteger>();
        static Dictionary<int, BigInteger> tens = new Dictionary<int, BigInteger>();
        static Dictionary<int, BigInteger> twenties = new Dictionary<int, BigInteger>();
        static Dictionary<int, BigInteger> fifties = new Dictionary<int, BigInteger>();
        static Dictionary<int, BigInteger> onehundreds = new Dictionary<int, BigInteger>();
        static Dictionary<int, BigInteger> twohundreds = new Dictionary<int, BigInteger>();
        static void Main(string[] args)
        {

            for (int i = 0; i <= 200; i++)
            {
                Console.WriteLine(i + ": " + twohundred(i));
            }
        }

        static BigInteger one(int x)
        {
            return 1;
        }

        static BigInteger two(int x)
        {
            if (x <= 0)
            {
                return 0;
            }
            if (twos.ContainsKey(x)) { return twos[x]; }
            BigInteger value = two(x - 2) + one(x);
            twos.Add(x, value);
            return value;
        }

        static BigInteger five(int x)
        {
            if (x <= 0)
            {
                return 0;
            }
            if (fives.ContainsKey(x)) { return fives[x]; }
            BigInteger value = five(x - 5) + two(x);
            fives.Add(x, value);
            return value;
        }

        static BigInteger ten(int x)
        {
            if (x <= 0)
            {
                return 0;
            }
            if (tens.ContainsKey(x)) { return tens[x]; }
            BigInteger value = ten(x - 10) + five(x);
            tens.Add(x, value);
            return value;
        }

        static BigInteger twenty(int x)
        {
            if (x <= 0)
            {
                return 0;
            }
            if (twenties.ContainsKey(x)) { return twenties[x]; }
            BigInteger value = twenty(x - 20) + ten(x);
            twenties.Add(x, value);
            return value;
        }

        static BigInteger fifty(int x)
        {
            if (x <= 0)
            {
                return 0;
            }
            if (fifties.ContainsKey(x)) { return fifties[x]; }
            BigInteger value = fifty(x - 50) + twenty(x);
            fifties.Add(x, value);
            return value;
        }

        static BigInteger hundred(int x)
        {
            if (x <= 0)
            {
                return 0;
            }
            if (onehundreds.ContainsKey(x)) { return onehundreds[x]; }
            BigInteger value = hundred(x - 100) + fifty(x);
            onehundreds.Add(x, value);
            return value;
        }

        static BigInteger twohundred(int x)
        {
            if (x <= 0)
            {
                return 0;
            }
            if (twohundreds.ContainsKey(x)) { return twohundreds[x]; }
            BigInteger value = twohundred(x - 200) + hundred(x);
            twohundreds.Add(x, value);
            return value;
        }
    }

    
}
