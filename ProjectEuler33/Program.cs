using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler33
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fraction> allFractions = new List<Fraction>();
            List<Fraction> goodFractions = new List<Fraction>();
            for (int i = 11; i < 100; i++)
            {
                if (i % 10 == 0) continue;
                for (int j = 11; j < i; j++)
                {
                    if (j % 10 == 0) continue;
                    allFractions.Add(new Fraction(j,i));
                }
            }

            allFractions = allFractions.Where(f => f.canWork()).ToList();
            foreach (Fraction f in allFractions)
            {
                if (Fraction.unorthodoxCancel(f))
                {
                    Console.WriteLine(f);
                    goodFractions.Add(f);
                }
            }

            Fraction mult = new Fraction(1, 1);
            foreach (Fraction f in goodFractions)
            {
                mult = Fraction.multiply(mult, f);
            }
            Console.WriteLine("-\n" + mult);
        }
    }

    class Fraction
    {
        int numerator;
        int denominator;

        public Fraction(int n, int d)
        {
            numerator = n;
            denominator = d;
        }

        public List<Fraction> unorthodoxedreducedFractions()
        {
            List<Fraction> reduceds = new List<Fraction>();
            string f1n = this.numerator.ToString();
            string f1d = this.denominator.ToString();

            char n = f1n[0];
            char d = f1d[1];
            int numer = Convert.ToInt32(n)-48;
            int denom = Convert.ToInt32(d)-48;
            reduceds.Add(new Fraction(numer, denom));
            return reduceds;
        }

        public static bool equalValue(Fraction fraction1, Fraction fraction2)
        {
            if (fraction2.denominator == 1 && fraction2.numerator == 1) return false;
            double value = (1.0 * fraction1.numerator * fraction2.denominator) / (1.0 * fraction1.denominator * fraction2.numerator);
            return value == 1.0;
        }

        public static bool sameFraction(Fraction fraction1, Fraction fraction2)
        {
            return (fraction1.numerator == fraction2.numerator && fraction1.denominator == fraction2.denominator);
        }

        public static Fraction multiply(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.numerator * f2.numerator, f1.denominator * f2.denominator).reduce();
        }

        public Fraction reduce()
        {
            int i = 2;
            if (this.numerator == 49 && this.denominator == 98)
            {
                int x = 3;
            }
            while (i <= numerator)
            {
                if (numerator % i == 0 && denominator % i == 0)
                {
                    numerator /= i;
                    denominator /= i;
                    i--;
                }
                i++;
            }
            return this;
        }


        public bool canWork()
        {
            string f1n = this.numerator.ToString();
            string f1d = this.denominator.ToString();
            return f1n[1] == f1d[0];
        }

        public static bool unorthodoxCancel(Fraction originalFraction)
        {
            List<Fraction> reducedFractions = originalFraction.unorthodoxedreducedFractions();

            foreach (Fraction reduced in reducedFractions)
            {
                if (originalFraction.numerator == 49 && originalFraction.denominator == 98)
                {
                    int x = 3;
                }
                if (sameFraction(reduced, originalFraction))
                {
                    return false;
                }
                if (!equalValue(reduced, originalFraction))
                {
                    return false;
                }

                string f1n = originalFraction.numerator.ToString();
                string f1d = originalFraction.denominator.ToString();
                string f2n = reduced.numerator.ToString();
                string f2d = reduced.denominator.ToString();

                if (f1n[0] == f2n[0] && f1d[1] == f2d[0])
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return "" + numerator + "/" + denominator;
        }
    }
}
