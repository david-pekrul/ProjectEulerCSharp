using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler63
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for(int i = 1; i < 10; i++)
            {
                NumerPower np = new NumerPower(i);
                count += np.computePowers();
            }

            Console.WriteLine(count);

        }
    }

    class NumerPower
    {
        private BigInteger baseNumber;

        public NumerPower(BigInteger b)
        {
            baseNumber = b;
        }

        public int computePowers()
        {
            BigInteger temp = 1;

            int count = 0;
            for (int i = 1; i < 100; i++ )
            {
                temp *= baseNumber;
                string str = temp.ToString();
                if(str.Length == i)
                {
                    Console.WriteLine(baseNumber + " ^ " + i + " = " + temp);
                    count++;
                }
                else if(str.Length > i)
                {
                    break;
                }
            }
            return count;
        }


    }
    
}
