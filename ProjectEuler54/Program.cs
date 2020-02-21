using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler54
{
    class Program
    {
        enum Suit
        {
            Heart, Club, Diamond, Spade
        }
        enum HandType
        {
            HighCard = 0, OnePair = 1, TwoPairs = 2, ThreeOfAKind = 3, Straight = 4, Flush = 5, FullHouse = 6, FourOfAKind = 7, StraightFlush = 8, RoyalFlush = 9
        }


        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("poker.txt");
            int count = 0;
            int wrongCount = 0;


            Hand test1 = new Hand("2D 9C AS AH AC");
            Hand test2 = new Hand("3D 6D 7D TD QD");
            test1.ClassifyHand();
            test2.ClassifyHand();

            if(test1.doesBeat(test2))
            {
                Console.WriteLine("TEST 1");
            }
            else
            {
                Console.WriteLine("TEST 2");
            }
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string firstHand = line.Substring(0, 15).Trim();
                string secondHand = line.Substring(15).Trim();

                Hand p1 = new Hand(firstHand);
                Hand p2 = new Hand(secondHand);

                p1.ClassifyHand();
                p2.ClassifyHand();

                if (p1.doesBeat(p2))
                {
                    count++;
                }
                else
                {
                    wrongCount++;
                }
            }
            Console.WriteLine("ANSWER: " + count);
        }

        class Hand
        {
            public List<Card> hand;
            public HandType handType;
            public List<Card> orderedListOfHighCard;

            public Hand(string str)
            {
                hand = new List<Card>(5);
                string[] split = str.Split(' ');
                for (int i = 0; i < 5; i++)
                {
                    Card temp = new Card(split[i][0], split[i][1]);
                    hand.Add(temp);
                }
                orderedListOfHighCard = new List<Card>(5);
            }

            public bool isThisHandWinningATie(Hand h2)
            {
                for (int i = 0; i < orderedListOfHighCard.Count; i++)
                {
                    if (this.orderedListOfHighCard[i].value > h2.orderedListOfHighCard[i].value)
                    {
                        return true;
                    }
                    if (this.orderedListOfHighCard[i].value < h2.orderedListOfHighCard[i].value)
                    {
                        return false;
                    }
                }
                throw new Exception("NO TIE BROKEN!");
            }

            public void ClassifyHand()
            {
                sort();
               if(isRoyalFlush())
               {
                   return;
               }
               if (isStraigFlush())
               {
                   return;
               }
               if (isFourOfAKind())
               {
                   return;
               }
               if (isFullHouse())
               {
                   return;
               }
               if (isFlush())
               {
                   return;
               }
               if (isStraight())
               {
                   return;
               }
               if (isThreeOfAKind())
               {
                   return;
               }
               if (isTwoPairs())
               {
                   return;
               }
               if (isOnePair())
               {
                   return;
               }
               if(isHighCard())
               {
                   return;
               }
            }

            public bool doesBeat(Hand h2)
            {
                if (this.handType > h2.handType)
                {
                    return true;
                }
                if (this.handType < h2.handType)
                {
                    return false;
                }
                return this.isThisHandWinningATie(h2);

            }

            public void sort()
            {
                List<Card> sortedByValue = new List<Card>();
                foreach (Card c in hand)
                {
                    sortedByValue.Add(c);
                }
                sortedByValue.Sort((a, b) => a.value.CompareTo(b.value));
                sortedByValue.Reverse();//Ace first, 2 last

                hand = sortedByValue;
            }

            public bool isRoyalFlush()
            {
                if(detectFlush())
                {
                    if(hand[0].value == 14 && hand[1].value == 13 && hand[2].value == 13 && hand[3].value == 13 && hand[4].value == 13)
                    {
                        handType = HandType.RoyalFlush;
                        return true;
                    }
                }
                return false;
            }

            public bool isStraigFlush()
            {
                if (detectFlush())
                {
                    if (hand[0].value == hand[1].value+1 && hand[1].value == hand[2].value+1 && hand[2].value == hand[3].value+1 && hand[3].value == hand[4].value+1)
                    {
                        handType = HandType.StraightFlush;
                        orderedListOfHighCard.Add(hand[0]);
                        return true;
                    }
                }
                return false;
            }

            public bool isFourOfAKind()
            {
                if ((hand[0].value == hand[1].value && hand[1].value == hand[2].value && hand[2].value == hand[3].value))
                {
                    handType = HandType.FourOfAKind;
                    orderedListOfHighCard.Add(hand[0]);
                    orderedListOfHighCard.Add(hand[4]);
                    return true;
                }
                if ((hand[1].value == hand[2].value && hand[2].value == hand[3].value && hand[3].value == hand[4].value))
                {
                    handType = HandType.FourOfAKind;
                    orderedListOfHighCard.Add(hand[1]);
                    orderedListOfHighCard.Add(hand[0]);
                    return true;
                }
                return false;
            }

            public bool isFullHouse()
            {
                if ((hand[0].value == hand[1].value && hand[1].value == hand[2].value && hand[3].value == hand[4].value))
                {
                    handType = HandType.FullHouse;
                    orderedListOfHighCard.Add(hand[0]);
                    orderedListOfHighCard.Add(hand[3]);
                    return true;
                }
                if ((hand[2].value == hand[3].value && hand[3].value == hand[4].value && hand[0].value == hand[1].value))
                {
                    handType = HandType.FullHouse;
                    orderedListOfHighCard.Add(hand[2]);
                    orderedListOfHighCard.Add(hand[0]);
                    return true;
                }
                return false;
            }

            public bool isFlush()
            {
                if(detectFlush())
                {
                    orderedListOfHighCard.Add(hand[0]);
                    orderedListOfHighCard.Add(hand[1]);
                    orderedListOfHighCard.Add(hand[2]);
                    orderedListOfHighCard.Add(hand[3]);
                    orderedListOfHighCard.Add(hand[4]);
                    handType = HandType.Flush;
                    return true;

                }
                return false;
            }

            private bool detectFlush()
            {
                HashSet<Suit> suits = new HashSet<Suit>();
                foreach (Card c in hand)
                {
                    suits.Add(c.suit);
                }
                return suits.Count == 1;
            }

            public bool isStraight()
            {
                if (hand[0].value == hand[1].value + 1 && hand[1].value == hand[2].value + 1 && hand[2].value == hand[3].value + 1 && hand[3].value == hand[4].value + 1)
                {
                    handType = HandType.Straight;
                    orderedListOfHighCard.Add(hand[0]);
                    return true;
                }
                return false;
            }

            public bool isThreeOfAKind()
            {
                if (hand[0].value == hand[1].value && hand[1].value == hand[2].value)
                {
                    handType = HandType.ThreeOfAKind;
                    orderedListOfHighCard.Add(hand[0]);
                    orderedListOfHighCard.Add(hand[3]);
                    orderedListOfHighCard.Add(hand[4]);
                    return true;
                }
                if (hand[1].value == hand[2].value && hand[2].value == hand[3].value)
                {
                    handType = HandType.ThreeOfAKind;
                    orderedListOfHighCard.Add(hand[1]);
                    orderedListOfHighCard.Add(hand[0]);
                    orderedListOfHighCard.Add(hand[4]);
                    return true;
                }
                if (hand[2].value == hand[3].value && hand[3].value == hand[4].value)
                {
                    handType = HandType.ThreeOfAKind;
                    orderedListOfHighCard.Add(hand[2]);
                    orderedListOfHighCard.Add(hand[0]);
                    orderedListOfHighCard.Add(hand[1]);
                    return true;
                }
                return false;
            }

            public bool isTwoPairs()
            {
                if (hand[0].value == hand[1].value)
                {
                    if(hand[2].value == hand[3].value)
                    {
                        handType = HandType.TwoPairs;
                        orderedListOfHighCard.Add(hand[0]);
                        orderedListOfHighCard.Add(hand[2]);
                        orderedListOfHighCard.Add(hand[4]);
                        return true;
                    }
                    if (hand[3].value == hand[4].value)
                    {
                        handType = HandType.TwoPairs;
                        orderedListOfHighCard.Add(hand[0]);
                        orderedListOfHighCard.Add(hand[3]);
                        orderedListOfHighCard.Add(hand[2]);
                        return true;
                    }
                }
                if (hand[1].value == hand[2].value)
                {
                    if (hand[3].value == hand[4].value)
                    {
                        handType = HandType.TwoPairs;
                        orderedListOfHighCard.Add(hand[1]);
                        orderedListOfHighCard.Add(hand[3]);
                        orderedListOfHighCard.Add(hand[0]);
                        return true;
                    }
                }
                return false;
            }

            public bool isOnePair()
            {
                if (hand[0].value == hand[1].value)
                {
                    handType = HandType.OnePair;
                    orderedListOfHighCard.Add(hand[0]);
                    orderedListOfHighCard.Add(hand[2]);
                    orderedListOfHighCard.Add(hand[3]);
                    orderedListOfHighCard.Add(hand[4]);
                    return true;
                }
                if (hand[1].value == hand[2].value)
                {
                    handType = HandType.OnePair;
                    orderedListOfHighCard.Add(hand[1]);
                    orderedListOfHighCard.Add(hand[0]);
                    orderedListOfHighCard.Add(hand[3]);
                    orderedListOfHighCard.Add(hand[4]);
                    return true;
                }
                if (hand[2].value == hand[3].value)
                {
                    handType = HandType.OnePair;
                    orderedListOfHighCard.Add(hand[2]);
                    orderedListOfHighCard.Add(hand[0]);
                    orderedListOfHighCard.Add(hand[1]);
                    orderedListOfHighCard.Add(hand[4]);
                    return true;
                }
                if (hand[3].value == hand[4].value)
                {
                    handType = HandType.OnePair;
                    orderedListOfHighCard.Add(hand[3]);
                    orderedListOfHighCard.Add(hand[0]);
                    orderedListOfHighCard.Add(hand[1]);
                    orderedListOfHighCard.Add(hand[2]);
                    return true;
                }
                return false;
            }

            public bool isHighCard()
            {
                handType = HandType.HighCard;
                orderedListOfHighCard.Add(hand[0]);
                orderedListOfHighCard.Add(hand[1]);
                orderedListOfHighCard.Add(hand[2]);
                orderedListOfHighCard.Add(hand[3]);
                orderedListOfHighCard.Add(hand[4]);
                return true;
            }

            public override string ToString()
            {
                string str = "[";
                foreach (Card c in hand)
                {
                    str += c;
                    str += " ";
                }

                return str.TrimEnd() + "]";
            }
        }

        class Card
        {
            public Suit suit;
            public int value;
            public Card(char v, char s)
            {
                suit = toSuit(s);
                value = toValue(v);
            }

            private Suit toSuit(char s)
            {
                switch (s)
                {
                    case 'C':
                        return Suit.Club;
                    case 'S':
                        return Suit.Spade;
                    case 'D':
                        return Suit.Diamond;
                    case 'H':
                        return Suit.Heart;
                    default:
                        throw new Exception("unexpected suit");
                }
            }

            private int toValue(char v)
            {
                switch (v)
                {
                    case '2':
                        return 2;
                    case '3':
                        return 3;
                    case '4':
                        return 4;
                    case '5':
                        return 5;
                    case '6':
                        return 6;
                    case '7':
                        return 7;
                    case '8':
                        return 8;
                    case '9':
                        return 9;
                    case 'T':
                        return 10;
                    case 'J':
                        return 11;
                    case 'Q':
                        return 12;
                    case 'K':
                        return 13;
                    case 'A':
                        return 14;
                    default:
                        throw new Exception("Unexpected value");
                }
            }

            public override string ToString()
            {
                return "" + value + suit;
            }

        }
    }
}
