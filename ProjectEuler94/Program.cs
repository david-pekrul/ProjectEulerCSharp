using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler94
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalPermiter = 0;
            double max = Math.Ceiling(Math.Pow(10, 9) / 3);
            Console.WriteLine("M: " + max);
            ulong s;
            ulong c;
            ulong z;
            for (ulong x = 3; x < max; x+=2)
            {
                c = x - 1;
                if ((2 * x + c) % 2 == 0)
                {
                    s = (2*x + c)/2L;
                    z = s*(s - c);
                    if (isPerfectSquare(z))
                    {
                        
                            Console.WriteLine(x + "\t" + c);
                            totalPermiter += (s*2);
                        
                    }
                }

                c = x + 1;
                if ((2 * x + c) % 2 == 0)
                {
                    s = (2*x + c)/2L;
                    z = s*(s - c);

                    if (isPerfectSquare(z))
                    {
                        Console.WriteLine(x + "\t" + c);
                            totalPermiter += (s*2);
                        
                    }
                }







                #region dead code

                //double c = x + 1;
                //double s = (2*x + c)/2;
                //double h = Math.Sqrt(s*(s - c))*(2*(s - x)/c);
                //if(h%1==0)
                //{
                //    Console.WriteLine(x);
                //    totalPermiter += s;
                //}

                //c = x - 1;
                //s = (2 * x + c) / 2;
                //h = Math.Sqrt(s * (s - c)) * (2 * (s - x) / c);
                //if (h % 1 == 0)
                //{
                //    Console.WriteLine(x);
                //    totalPermiter += s;
                //}

                //double a = (x + 1)/2;
                //double acos = Math.Acos(a / x);
                //double h = Math.Sin(acos)*x;
                //if(h%1==0)
                //{
                //    double perimeter = 3 * x + 1;
                //    totalPermiter += perimeter;
                //    Console.WriteLine("X:+" + x + "\tH: " + h + "\t\tP: " + perimeter + " \tAC: " + acos);

                //}

                //a = (x - 1) / 2;
                //acos = Math.Acos(a / x);
                //h = Math.Sin(acos) * x;
                //if (h % 1 == 0)
                //{
                //    double perimeter = 3 * x - 1;
                //    totalPermiter += perimeter;
                //    Console.WriteLine("X:-" + x + "\tH: " + h + "\t\tP: " + perimeter + " \tAC: " + acos);

                //}

                #endregion
            }
            Console.WriteLine("ANSWER: " + totalPermiter);
        }

        public static bool isPerfectSquare(ulong n)
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


    }
}
