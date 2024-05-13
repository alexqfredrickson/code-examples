using System;
using System.Linq;
using MoreLinq;
using practice_exercises.Project_Euler.Models.Miscellaneous;

namespace practice_exercises.Project_Euler.Helpers
{
    public static class CardHelper
    {
        public static Hand DetermineHandStrength(Hand h)
        {
            if (h.Cards.Any(c => c.Rank == Enums.Enums.Rank.Ace)
              && h.Cards.Any(c => c.Rank == Enums.Enums.Rank.Two)
              && h.Cards.Any(c => c.Rank == Enums.Enums.Rank.Three)
              && h.Cards.Any(c => c.Rank == Enums.Enums.Rank.Four)
              && h.Cards.Any(c => c.Rank == Enums.Enums.Rank.Five))
            {
                h.HasStraight = true;
            }
            else
            {
                h.Cards = h.Cards.OrderByDescending(x => x.Rank).ToList();
                h.HasStraight = (h.Cards[0].Rank == h.Cards[1].Rank + 1
                    && h.Cards[1].Rank == h.Cards[2].Rank + 1
                    && h.Cards[2].Rank == h.Cards[3].Rank + 1
                    && h.Cards[3].Rank == h.Cards[4].Rank + 1);
            }

            if (h.HasAce && h.HasKing && h.HasStraight && h.HasFlush)
            {
                h.Type = Enums.Enums.HandType.RoyalFlush;
                h.Strength = Enums.Enums.Rank.Ace;
            }
            else if (h.HasStraight && h.HasFlush && h.HasAce == false)
            {
                h.Type = Enums.Enums.HandType.StraightFlush;
                h.Strength = h.Cards.OrderByDescending(c => c.Rank).First().Rank;
            }
            else if (h.PairCount.Any(x => x.Count == 4))
            {
                h.Type = Enums.Enums.HandType.Quads;
                h.Strength = (Enums.Enums.Rank)Enum.Parse(typeof(Enums.Enums.Rank), h.PairCount.Where(x => x.Count == 4).Select(x => x.Rank).Single().ToString());
            }
            else if (h.PairCount.Any(x => x.Count == 3) && h.PairCount.Any(x => x.Count == 2))
            {
                h.Type = Enums.Enums.HandType.FullHouse;
                h.Strength = (Enums.Enums.Rank)Enum.Parse(typeof(Enums.Enums.Rank), h.PairCount.Where(x => x.Count == 3).Select(x => x.Rank).Single().ToString());
            }
            else if (h.HasFlush)
            {
                h.Type = Enums.Enums.HandType.Flush;
                h.Strength = h.Cards.OrderByDescending(c => c.Rank).First().Rank;
                h.Kickers = h.Cards.OrderByDescending(c => c.Rank).Select(c => c.Rank).Cast<Enums.Enums.Rank>().ToList();
            }
            else if (h.HasStraight)
            {
                h.Type = Enums.Enums.HandType.Straight;
                h.Strength = h.Cards.OrderByDescending(c => c.Rank).First().Rank;
            }
            // trips
            else if (h.PairCount.Any(x => x.Count == 3))
            {
                h.Type = Enums.Enums.HandType.Trips;
                h.Strength = (Enums.Enums.Rank)Enum.Parse(typeof(Enums.Enums.Rank), h.PairCount.Where(x => x.Count == 3).Select(x => x.Rank).Single().ToString());
                h.Kickers = h.PairCount.Where(x => x.Count == 1).Select(x => x.Rank).Cast<Enums.Enums.Rank>().ToList();
                h.Kickers.Sort();
                h.Kickers.Reverse();

            }
            else if (h.PairCount.Count(x => x.Count == 2) == 2)
            {
                h.Type = Enums.Enums.HandType.TwoPair;
                h.Strength = (Enums.Enums.Rank)Enum.Parse(typeof(Enums.Enums.Rank), h.PairCount.Where(x => x.Count == 2).Select(x => x.Rank).First().ToString());
                h.Kickers = h.PairCount.Where(x => x.Count == 2).Select(x => x.Rank).Cast<Enums.Enums.Rank>().ToList();
                h.Kickers.Sort();
                h.Kickers.Reverse();
                h.Kickers.Add(h.PairCount.Where(x => x.Count == 1).Select(x => x.Rank).Single());
            }
            else if (h.PairCount.Count(x => x.Count == 2) == 1)
            {
                h.Cards.OrderByDescending(c => c.Rank);
                h.Type = Enums.Enums.HandType.OnePair;
                h.Strength = (Enums.Enums.Rank)Enum.Parse(typeof(Enums.Enums.Rank), h.PairCount.Where(x => x.Count == 2).Select(x => x.Rank).First().ToString());
                h.Kickers = h.PairCount.Where(x => x.Count == 1).Select(x => x.Rank).Cast<Enums.Enums.Rank>().ToList();
                h.Kickers.Sort();
                h.Kickers.Reverse();
            }
            else
            {
                h.Type = Enums.Enums.HandType.HighCard;
                h.Strength = h.Cards.MaxBy(x => x.Rank).Rank;
                h.Kickers = h.Cards.Select(x => x.Rank).Cast<Enums.Enums.Rank>().ToList();
                h.Kickers.Sort();
                h.Kickers.Reverse();
            }

            return h;
        }

        public static string DetermineStrongerHand(Hand HandOne, Hand HandTwo)
        {
            string winner = "Tie";

            if (HandOne.Type > HandTwo.Type)
            {
                winner = "Player 1";
            }
            else if (HandOne.Type < HandTwo.Type)
            {
                winner = "Player 2";
            }
            else
            {
                // types are equal
                if (HandOne.Type == Enums.Enums.HandType.StraightFlush || HandOne.Type == Enums.Enums.HandType.Straight || HandOne.Type == Enums.Enums.HandType.FullHouse || HandOne.Type == Enums.Enums.HandType.HighCard)
                {
                    winner = (HandOne.Strength > HandTwo.Strength) ? "Player 1" : "Player 2";
                }
                else if (HandOne.Type == Enums.Enums.HandType.Flush || HandOne.Type == Enums.Enums.HandType.TwoPair)
                {
                    for (int i = 0; i < HandOne.Kickers.Count; i++)
                    {
                        if (HandOne.Kickers[i] != HandTwo.Kickers[i])
                        {
                            winner = (HandOne.Kickers[i] > HandTwo.Kickers[i] ? "Player 1" : "Player 2");
                            break;
                        }
                    }
                }
                else if (HandOne.Type == Enums.Enums.HandType.OnePair)
                {
                    if (HandOne.Strength > HandTwo.Strength)
                    {
                        winner = "Player 1";
                    }
                    else if (HandOne.Strength < HandTwo.Strength)
                    {
                        winner = "Player 2";
                    }
                    else
                    {
                        for (int i = 0; i < HandOne.Kickers.Count; i++)
                        {
                            if (HandOne.Kickers[i] != HandTwo.Kickers[i])
                            {
                                winner = (HandOne.Kickers[i] > HandTwo.Kickers[i] ? "Player 1" : "Player 2");
                                break;
                            }
                        }
                    }
                }
            }

            return winner;
        }
    }
}
