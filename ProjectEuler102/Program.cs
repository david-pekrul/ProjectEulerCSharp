using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ProjectEuler102
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("triangles.txt");
            int trianglesContainingOrigin = 0;
            List<string> lines = new List<string>();
            Object locking = new Object();

            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }
            reader.Close();

            Parallel.ForEach(lines, line => 
            {
                string[] pts = line.Split(',');
                int x1 = Convert.ToInt32(pts[0]);
                int y1 = Convert.ToInt32(pts[1]);
                int x2 = Convert.ToInt32(pts[2]);
                int y2 = Convert.ToInt32(pts[3]);
                int x3 = Convert.ToInt32(pts[4]);
                int y3 = Convert.ToInt32(pts[5]);

                Triangle t = new Triangle(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3));
                if (t.isOriginWithinThisTriangle())
                {
                    lock (locking)
                    {
                        trianglesContainingOrigin++;
                    }
                }
            });

            Console.WriteLine(trianglesContainingOrigin);

        }
    }

    class Triangle
    {
        private static Point Origin = new Point(0, 0);
        public static double twoPI = Math.PI * 2;
        Point one, two, three;
        
        public Triangle(Point first, Point second, Point third)
        {
            one = first;
            two = second;
            three = third;
        }

        public bool isOriginWithinThisTriangle()
        {
            Vector Vone, Vtwo, Vthree;
            double thetaOne, thetaTwo, thetaThree;
            Vone = new Vector(one, Origin);
            Vtwo = new Vector(two, Origin);
            Vthree = new Vector(three, Origin);

            thetaOne = Vone.calculateAngleBetween(Vtwo);
            thetaTwo = Vtwo.calculateAngleBetween(Vthree);
            thetaThree = Vthree.calculateAngleBetween(Vone);

            double totalTheta = thetaOne + thetaTwo + thetaThree;
            if (!(totalTheta >= twoPI-.005 && totalTheta <= twoPI+.005))
            {
                return false;
            }

            if (thetaOne + thetaTwo < thetaThree)
            {
                return false;
            }
            if (thetaTwo + thetaThree < thetaOne)
            {
                return false;
            }
            if (thetaThree + thetaOne < thetaTwo)
            {
                return false;
            }

            return true;
        }
        
    }

    class Vector
    {
        Point start, end;
        public Vector(Point s, Point e)
        {
            start = s;
            end = e;
        }

        public double calculateAngleBetween(Vector v2)
        {
            int dotProduct = (v2.start.pointX * this.start.pointX) + (v2.start.pointY * this.start.pointY);
            double cosTheta = dotProduct / ((this.calculateLength()) * (v2.calculateLength()));
            return Math.Acos(cosTheta);
        }

        public double calculateLength()
        {
            return start.calculateDistance(end);
        }
    }

    class Point
    {
        
        public int pointX, pointY;
        public Point(int x, int y)
        {
            pointX = x;
            pointY = y;
        }

        public double calculateDistance(Point p2)
        {
            int deltaX = p2.pointX - this.pointX;
            int deltaY = p2.pointY - this.pointY;
            double diffOfSquares = Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2);
            return Math.Sqrt(diffOfSquares);
        }
    }
}
