using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler84
{

    class Program
    {
        public static int diceSize = 6;
        static List<Square> board;
        public static Random r = new Random();

        static void Main(string[] args)
        {
            List<int> diceValues = new List<int>();
            for (int i = 1; i <= diceSize; i++)
            {
                diceValues.Add(i);
            }
            Dictionary<int, double> rollableValuesToProb = getRollValueToProbabilityMap(diceValues);

            #region Board Setup
            board = new List<Square>();
            for (int i = 0; i < 40; i++)
            {
                board.Add(new NormalSquare(i));
            }

            Square go = board[0];
            Square jail = board[10];
            Square C1 = board[11];
            Square E3 = board[24];
            Square H2 = board[39];

            board[30] = new GTJSquare(jail);

            board[5] = new RailRoadSquare(5);//R1
            Square R1 = board[5];
            board[15] = new RailRoadSquare(15);//R2
            board[25] = new RailRoadSquare(25);//R3
            board[35] = new RailRoadSquare(35);//R4

            board[12] = new UtilitySquare(12);
            board[28] = new UtilitySquare(28);

            CommunityChestSquare.Go = go;
            CommunityChestSquare.Jail = jail;
            board[2] = new CommunityChestSquare(2);
            board[17] = new CommunityChestSquare(17);
            board[33] = new CommunityChestSquare(33);

            ChanceSquare.staticTargetSquares = new List<Square>() { go, jail, C1, E3, H2, R1 };
            ChanceSquare temp = new ChanceSquare(7);
            temp.addTargetSquare(getNextRailRoadFromSquare(temp));
            temp.addTargetSquare(getNextRailRoadFromSquare(temp));
            temp.addTargetSquare(getNextUtilityFromSquare(temp));
            temp.addTargetSquare(board[temp.getId() - 3]);
            board[7] = temp;

            temp = new ChanceSquare(22);
            temp.addTargetSquare(getNextRailRoadFromSquare(temp));
            temp.addTargetSquare(getNextRailRoadFromSquare(temp));
            temp.addTargetSquare(getNextUtilityFromSquare(temp));
            temp.addTargetSquare(board[temp.getId() - 3]);
            board[22] = temp;

            temp = new ChanceSquare(36);
            temp.addTargetSquare(getNextRailRoadFromSquare(temp));
            temp.addTargetSquare(getNextRailRoadFromSquare(temp));
            temp.addTargetSquare(getNextUtilityFromSquare(temp));
            temp.addTargetSquare(board[temp.getId() - 3]);
            board[36] = temp;


            #endregion

            int count = 10000000;
            Square current = go;
            bool firstDouble = false;
            bool secondDouble = false;
            for (int i = 0; i < count; i++)
            {
                int firstDice = roll();
                int secondDice = roll();
                if (firstDice == secondDice)
                {
                    if (firstDouble)
                    {
                        if (secondDouble)
                        {
                            current = jail;
                            current.visit();
                            firstDouble = false;
                            secondDouble = false;
                            continue;
                        }
                        else
                        {
                            secondDouble = true;
                        }
                    }
                    else
                    {
                        firstDouble = true;
                    }
                }
                else
                {
                    firstDouble = false;
                    secondDouble = false;
                }
                current = board[(current.getId() + firstDice + secondDice) % 40].getNextSquare();
                current.visit();
            }

            List<Square> sorted = new List<Square>();
            sorted.AddRange(board);
            sorted.Sort((a, b) => a.getVisitCount().CompareTo(b.getVisitCount()));
            sorted.Reverse();

            int index = 1;
            foreach (Square s in sorted)
            {
                Console.WriteLine(index++ + ": " + s.getId() + " ~ " + s.getVisitCount());
            }

            Console.WriteLine("ANSWER: " + sorted[0].getId() + "" + sorted[1].getId() + "" + sorted[2].getId());



        }

        static Square getNextRailRoadFromSquare(Square s)
        {
            int startAt = s.getId();
            while (board[startAt].GetType() != typeof(RailRoadSquare))
            {
                startAt += 1;
                startAt = startAt % 40;
            }
            return board[startAt];
        }

        static Square getNextUtilityFromSquare(Square s)
        {
            int startAt = s.getId();
            int count = 0;
            while (board[startAt].GetType() != typeof(UtilitySquare))
            {
                startAt += 1;
                startAt = startAt % 40;
                count++;
                if (count > 40)
                {
                    throw new Exception("BORK!");
                }
            }
            return board[startAt];
        }

        static Dictionary<int, double> getRollValueToProbabilityMap(List<int> diceValues)
        {
            Dictionary<int, double> dict = new Dictionary<int, double>();
            int lengthSquared = diceValues.Count * diceValues.Count;
            double prob = (1.0 / lengthSquared);
            foreach (int d1 in diceValues)
            {
                foreach (int d2 in diceValues)
                {
                    if (dict.ContainsKey(d1 + d2))
                    {
                        dict[d1 + d2] += prob;
                    }
                    else
                    {
                        dict.Add(d1 + d2, prob);
                    }
                }
            }
            return dict;

        }

        public static int roll()
        {
            return r.Next(1, diceSize + 1);
        }

    }



    abstract class Square
    {
        int visitCount = 0;
        public void visit()
        {
            visitCount++;
        }
        public int getVisitCount() { return visitCount; }
        public abstract int getId();
        public abstract Square getNextSquare();
    }

    class NormalSquare : Square
    {
        int idNumber;
        public NormalSquare(int id)
        {
            idNumber = id;
        }

        public override int getId() { return idNumber; }

        public override Square getNextSquare()
        {
            return this;
        }

        public override string ToString()
        {
            return "S:" + idNumber;
        }


    }

    class CommunityChestSquare : Square
    {
        int idNumber;
        public static Square Go;
        public static Square Jail;
        public CommunityChestSquare(int id)
        {
            idNumber = id;
        }
        public override int getId() { return idNumber; }

        public override Square getNextSquare()
        {
            int r = Program.r.Next(1, 17);
            if (r == 16)
            {
                return Go;
            }
            if (r == 15) { return Jail; }

            return this;
        }
    }

    class ChanceSquare : Square
    {
        int idNumber;
        List<Square> targetSquares;
        public static List<Square> staticTargetSquares;
        private List<Square> ordered;
        public ChanceSquare(int id)
        {
            idNumber = id;
            targetSquares = new List<Square>();
        }

        public void addTargetSquare(Square s)
        {
            targetSquares.Add(s);
        }


        public override int getId() { return idNumber; }


        public override Square getNextSquare()
        {
            if (ordered == null)
            {
                ordered = new List<Square>();
                ordered.AddRange(staticTargetSquares);
                ordered.AddRange(targetSquares);
            }
            int r = Program.r.Next(0, 16);
            if (r < ordered.Count)
            {
                return ordered[r];
            }

            return this;
        }
    }

    class GTJSquare : Square
    {
        public static int hits = 0;
        Square jailSquare;
        public GTJSquare(Square jail)
        {
            jailSquare = jail;
        }

        public override int getId() { return 30; }

        public override Square getNextSquare()
        {
            return jailSquare;
        }
    }

    class RailRoadSquare : Square
    {
        int idNumber;
        public RailRoadSquare(int id)
        {
            idNumber = id;

        }

        public override int getId() { return idNumber; }

        public override Square getNextSquare()
        {
            return this;
        }
    }

    class UtilitySquare : Square
    {
        int idNumber;
        public UtilitySquare(int id)
        {
            idNumber = id;
        }

        public override int getId() { return idNumber; }

        public override Square getNextSquare()
        {
            return this;
        }
    }



}


