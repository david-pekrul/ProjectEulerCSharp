using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler220
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            List<Orientation> aList = new List<Orientation>();
            List<Orientation> bList = new List<Orientation>();
            Orientation a0 = getA0();
            aList.Add(a0);
            Orientation b0 = getB0();
            bList.Add(b0);
            for (int i = 1; i < 50; i++)
            {
                Orientation aNext = getNextA(aList[i - 1], bList[i - 1]);
                aList.Add(aNext);
                Orientation bNext = getNextB(aList[i - 1], bList[i - 1]);
                bList.Add(bNext);
            }
            ulong stepLimit = 1000000000000;

            Dictionary<int, ulong> pows = new Dictionary<int, ulong>();
            ulong powersOfTwo = 1;
            for(int i = 0; i <= 50; i++)
            {
                pows.Add(i, powersOfTwo);
                powersOfTwo *= 2;
            }

            Dictionary<ulong, int> stepsInAiDict = new Dictionary<ulong, int>();
            List<ulong> nodeSteps = new List<ulong>();
            HashSet<ulong> powersHash = new HashSet<ulong>();
            for(int i = 1; i < aList.Count; i++)
            {
                stepsInAiDict.Add(pows[i]-1, i-1);
                nodeSteps.Add(pows[i]-1);
                powersHash.Add(pows[i]);
            }

            nodeSteps.Sort();
            nodeSteps.Reverse();

            #region Smarts
            Orientation startingOrientation = new Orientation();
            startingOrientation.applyStep();
            Rotation flex = Rotation.Right;

            ulong mutableStepLimit = stepLimit-1;//already used one
            foreach (ulong nodeStepCount in nodeSteps)
            {
                //Console.WriteLine("Remaining steps: " + mutableStepLimit);
                if (nodeStepCount > mutableStepLimit)
                {
                    continue;
                }
                int currentAIndex = stepsInAiDict[nodeStepCount];
               
                //Console.WriteLine("Using A[" + stepsInAiDict[nodeStepCount] + "], steps used: " + nodeStepCount);
                mutableStepLimit -= nodeStepCount;
                startingOrientation = startingOrientation.addOrientations(aList[currentAIndex]);


                //if the next to use is the B[n] next to this A[n]
                if (nodeStepCount == mutableStepLimit)
                {
                    //use B[n]
                    Console.WriteLine("Using B[n] for finish");
                    startingOrientation.changeDirection(Rotation.Right);
                    startingOrientation = startingOrientation.addOrientations(bList[currentAIndex]);
                    break;
                }
                if (mutableStepLimit > 0)
                {
                    startingOrientation.changeDirection(flex);
                    startingOrientation.changeDirection(Rotation.Left);
                    startingOrientation.applyStep();
                    mutableStepLimit--;
                }

                if (mutableStepLimit == 0)
                {
                    break;
                }
                flex = mutableStepLimit >= (nodeStepCount / 2) ? Rotation.Left : Rotation.Right;
            }
            DateTime end = DateTime.Now;
            Console.WriteLine("\r\nSmarts: \r\n" + startingOrientation);
            Console.WriteLine();
            Console.WriteLine("TIME: " + (end-start).TotalSeconds);
            #endregion

        }

        public static void checkBuilder(List<Orientation> aList, List<Orientation> bList)
        {
            string startA = "a";
            string startB = "b";
            for(int i = 0; i < 20; i++)
            {
                startA = createNextString(startA);
                Orientation runA = followString(startA, ulong.MaxValue);
                if(!aList[i].Equals(runA))
                {
                    Console.WriteLine("A[" + i + "] " + aList[i]);
                    Console.WriteLine(runA);
                    throw new Exception("not equal");
                }
                startB = createNextString(startB);
                Orientation runB = followString(startB, ulong.MaxValue);
                if (!bList[i].Equals(runB))
                {
                    Console.WriteLine("B[" + i + "] " + bList[i]);
                    Console.WriteLine(runB);
                    throw new Exception("not equal");
                }
            }
        }

        public static string createNextString(string prev)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char c in prev)
            {
                switch(c)
                {
                    case 'a':
                        sb.Append("aRbFR");
                        break;
                    case 'b':
                        sb.Append("LFaLb");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        public static Orientation followString(string instructions, ulong limit)
        {
            Orientation o = new Orientation();
            ulong stepsTaken = 0;
            
            foreach(char c in instructions)
            {   
                //Console.Write(c);
                switch(c)
                {
                    case 'F':
                        if(stepsTaken == limit)
                        {
                            Console.WriteLine();
                            return o;
                        }
                        o.applyStep();
                        stepsTaken++;
                        break;
                    case 'R':
                        o.changeDirection(Rotation.Right);
                        break;
                    case 'L':
                        o.changeDirection(Rotation.Left);
                        break;
                }
            }
            return o;
        }

        public static Orientation getA0()
        {
            Orientation a0 = new Orientation();
            a0.changeDirection(Rotation.Right);
            a0.applyStep();
            a0.changeDirection(Rotation.Right);
            return a0;
        }

        public static Orientation getB0()
        {
            Orientation b0 = new Orientation();
            b0.changeDirection(Rotation.Left);
            b0.applyStep();
            b0.changeDirection(Rotation.Left);
            return b0;
        }

        public static Orientation getNextA(Orientation aPrev, Orientation bPrev)
        {
            Orientation aNext = new Orientation();
            aNext = aNext.addOrientations(aPrev);
            aNext.changeDirection(Rotation.Right);
            aNext = aNext.addOrientations(bPrev);
            aNext.applyStep();
            aNext.changeDirection(Rotation.Right);
            return aNext;
        }

        public static Orientation getNextB(Orientation aPrev, Orientation bPrev)
        {
            Orientation bNext = new Orientation();
            bNext.changeDirection(Rotation.Left);
            bNext.applyStep();
            bNext = bNext.addOrientations(aPrev);
            bNext.changeDirection(Rotation.Left);
            bNext = bNext.addOrientations(bPrev);
            return bNext;
        }
    }

    class Orientation
    {
        private int x;
        private int y;
        private Direction d;

        public Orientation()
        {
            x = 0;
            y = 0;
            d = Direction.U;
        }

        public Orientation clone()
        {
            return new Orientation { d = this.d, x = this.x, y = this.y };
        }

        public override string ToString()
        {
            return "(x:" + x + ",y:" + y + ") d:" + d;
        }

        public Orientation addOrientations(Orientation orientation2)
        {
            Orientation o = this.clone();
            Orientation o2 = orientation2.clone();
            
            if (o.d != Direction.U)
            {
                o2.rotateWholePathToDirection(o.d);
            }

            
            o.x += o2.x;
            o.y += o2.y;
            o.d = o2.d;
            return o;
        }

        public void applyStep()
        {
            switch (d)
            {
                case Direction.U:
                    y++;
                    break;
                case Direction.R:
                    x++;
                    break;
                case Direction.D:
                    y--;
                    break;
                case Direction.L:
                    x--;
                    break;
            }
        }

        public void changeDirection(Rotation r)
        {
            if (r == Rotation.Right)
            {
                switch (d)
                {
                    case Direction.U:
                        d = Direction.R;
                        break;
                    case Direction.R:
                        d = Direction.D;
                        break;
                    case Direction.D:
                        d = Direction.L;
                        break;
                    case Direction.L:
                        d = Direction.U;
                        break;
                }
            }
            else
            {
                switch (d)
                {
                    case Direction.U:
                        d = Direction.L;
                        break;
                    case Direction.R:
                        d = Direction.U;
                        break;
                    case Direction.D:
                        d = Direction.R;
                        break;
                    case Direction.L:
                        d = Direction.D;
                        break;
                }
            }
        }

        private void rotateWholePathToDirection(Direction targetDirection)
        {
            if(targetDirection == Direction.U)
            {
                return;
            }
            switch(targetDirection)
            {
                case Direction.U:
                    break;
                case Direction.L:
                    this.rotateWholeMovementPath(Rotation.Left);
                    break;
                case Direction.R:
                    this.rotateWholeMovementPath(Rotation.Right);
                    break;
                case Direction.D:
                    this.rotateWholeMovementPath(Rotation.Right);
                    this.rotateWholeMovementPath(Rotation.Right);
                    break;
            }
        }

        private void rotateWholeMovementPath(Rotation r)
        {
            int origX = x;
            int origY = y;
            if (r == Rotation.Right)
            {
                x = origY;
                y = -origX;
                switch (d)
                {
                    case Direction.U:
                        d = Direction.R;
                        break;
                    case Direction.R:
                        d = Direction.D;
                        break;
                    case Direction.D:
                        d = Direction.L;
                        break;
                    case Direction.L:
                        d = Direction.U;
                        break;
                }
            }
            else
            {
                x = -origY;
                y = origX;
                switch (d)
                {
                    case Direction.U:
                        d = Direction.L;
                        break;
                    case Direction.R:
                        d = Direction.U;
                        break;
                    case Direction.D:
                        d = Direction.R;
                        break;
                    case Direction.L:
                        d = Direction.D;
                        break;
                }
            }

        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(!obj.GetType().Equals(this.GetType()))
            {
                return false;
            }
            Orientation o2 = (Orientation) obj;
            return (x == o2.x && y == o2.y && d == o2.d);
        }

    }

    enum Direction
    {
        U, D, L, R
    }

    enum Rotation
    {
        Right, Left
    }
}
