using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler91
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int max = 50;
            for (int x1 = 0; x1 <= max; x1++)
            {
                Console.WriteLine("X1: " + x1);
                for (int y1 = 0; y1 <= max; y1++)
                {
                    for (int x2 = 0; x2 <= max; x2++)
                    {
                        for (int y2 = 0; y2 <= max; y2++)
                        {
                            int a = isRightTriangle(x1, y1, x2, y2);
                            if (a != 0)
                            {
                                //Console.WriteLine("({0},{1}) , ({2},{3})  => {4}", x1,y1, x2, y2,a);
                                count += 1;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("ANSWER: " + count / 2);
        }

        static int isRightTriangle(double x1, double y1, double x2, double y2)
        {
            if ((x1 == 0 && y1 == 0) || (x2 == 0 && y2 == 0))
            {
                return 0;
            }
            if (x1 == x2 && y1 == y2)
            {
                return 0;
            }
            //divide by zeros
            Slope m1 = new Slope(x1, y1);
            Slope m3 = new Slope(x2, y2);
            double dx = (x2 - x1);
            double dy = (y2 - y1);
            if (x2 < x1)
            {
                dx = -dx;
                dy = -dy;
            }
            Slope m2 = new Slope(dx, dy);

            if (m1.isPerpendicular(m2))
            {
                //2
                return 1;
            }
            if (m2.isPerpendicular(m3))
            {
                //2
                return 1;
            }
            if (m3.isPerpendicular(m1))
            {
                //1
                return 1;
            }
            //0
            return 0;
        }
    }

    class Slope
    {
        double slope;
        bool vertical;

        public Slope(double dx, double dy)
        {
            if (dx == 0)
            {
                slope = int.MinValue;
                vertical = true;
            }
            else
            {
                vertical = false;
                slope = (1.0 * dy) / dx;
            }
        }

        public bool isPerpendicular(Slope s2)
        {
            if (this.vertical)
            {
                return s2.slope == 0;
            }
            if (s2.vertical)
            {
                return this.slope == 0;
            }
            if (this.slope == 0)
            {
                return s2.vertical;
            }
            if (s2.slope == 0)
            {
                return this.vertical;
            }
            double slopeInverse = -1 / this.slope;
            if (s2.slope == slopeInverse)
            {
                return true;
            }
            if (Math.Abs(s2.slope - slopeInverse) < 0.00001)
            {
                return true;
            }

            return false;
        }
    }
}
