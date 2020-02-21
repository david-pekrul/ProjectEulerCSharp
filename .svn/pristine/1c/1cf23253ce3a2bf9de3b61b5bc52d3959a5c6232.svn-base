using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;

//1  n + n2  n3 + n4  n5 + n6  n7 + n8  n9 + n10
/*
n | n^10-n^9+n^8-n^7+n^6-n^5+n^4-n^3+n^2-n+1
1 |  1
2 |  683
3 |  44287
4 |  838861
5 |  8138021
6 |  51828151
7 |  247165843
8 |  954437177
9 |  3138105961
10 | 9090909091
 */
namespace ProjectEuler101b
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> actualValues = new List<double>() { 1, 683, 44287, 838861, 8138021, 51828151, 247165843, 954437177, 3138105961, 9090909091 };
            //List<double> actualValues = new List<double>() { 1, 8, 27};

            double ANSWER = 1;
            for (int z = 1; z <= actualValues.Count; z++)
            {
                Matrix matA = new Matrix(z, z);

                for (int col = 0; col < z; col++)
                {
                    PolynomialTerm pt = new PolynomialTerm(1, z - 1 - col);
                    for (int row = 0; row < z; row++)
                    {
                        matA[row, col] = pt.evaluateAt(row + 1);
                    }
                }


                Matrix matV = new Matrix(z, 1);
                for (int row = 0; row < z; row++)
                {
                    matV[row, 0] = actualValues[row];
                }

                Matrix matX = matA.SolveWith(matV);


                List<PolynomialTerm> ptTerms = new List<PolynomialTerm>();
                for (int row = 0; row < z; row++)
                {
                    ptTerms.Add(new PolynomialTerm(matX[row, 0], z - 1 - row));
                }

                for (int value = 1; value <= z + 1; value++)
                {
                    double thing = evaluatePolynomialListAt(value, ptTerms);
                    thing = getClosestInteger(thing);
                    if (!actualValues.Contains(thing))
                    {
                        Console.WriteLine("\n\nFIT: " + thing);
                        ANSWER += thing;
                        break;
                    }
                    Console.WriteLine("F(x)@" + value + " = " + thing);
                }

                Console.WriteLine("Z: " + z);
                Console.WriteLine(matA.ToString());
                Console.WriteLine(matV.ToString());
                Console.WriteLine(matX.ToString());
                Console.WriteLine("-----------------------------");
            }



            //Matrix m = new Matrix(3, 3);
            //m[0, 0] = 1;
            //m[0, 1] = 1;
            //m[0, 2] = 1;

            //m[1, 0] = 4;
            //m[1, 1] = 2;
            //m[1, 2] = 1;

            //m[2, 0] = 9;
            //m[2, 1] = 3;
            //m[2, 2] = 1;
            //Console.WriteLine(m.ToString());
            //Matrix v = new Matrix(3,1);

            //v[0, 0] = 1;
            //v[1, 0] = 683;
            //v[2, 0] = 44287;
            //Console.WriteLine(v.ToString());
            //Matrix x = m.SolveWith(v);

            //Console.WriteLine(x.ToString());
            Console.WriteLine("ANSWER: " + ANSWER);

        }

        public static double evaluatePolynomialListAt(int value, List<PolynomialTerm> ptList)
        {
            double result = 0;
            foreach (PolynomialTerm pt in ptList)
            {
                result += pt.evaluateAt(value);
            }

            return result;
        }

        public static double getClosestInteger(double d)
        {
            double r = d - (d % 1);
            if (d % 1 > 0.5)
            {
                r++;
            }
            return r;
        }
    }

    class PolynomialTerm
    {
        double coefficient;
        int power;

        public PolynomialTerm(double c, int p)
        {
            coefficient = c;
            power = p;
        }

        public double evaluateAt(int value)
        {
            return coefficient * Math.Pow(value, power);
        }
    }
}
