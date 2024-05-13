using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace practice_exercises.Project_Euler.Models.Miscellaneous
{
    public class Hand
    {
        public List<Card> Cards = new List<Card>();
        public Enums.Enums.HandType Type { get; set; }
        public Enums.Enums.Rank Strength { get; set; }
        public List<Enums.Enums.Rank> Kickers = new List<Enums.Enums.Rank>();

        public List<dynamic> PairCount
        {
            get
            {
                return (from card in Cards
                        group card by card.Rank into g
                        let count = g.Count()
                        orderby count descending
                        select new { Rank = g.Key, Count = count }).ToList<dynamic>();
            }
            set
            {
                PairCount = value;
            }


        }

        public bool HasStraight { get; set; }

        public bool HasFlush
        {
            get
            {
                var suits = Cards.DistinctBy(x => x.Suit).ToList();
                return suits.Count == 1;
            }
            set
            {
                HasFlush = value;
            }
        }

        public bool HasAce
        {
            get
            {
                return Cards.Any(x => x.Rank == Enums.Enums.Rank.Ace);
            }
            set
            {
                HasAce = value;
            }
        }

        public bool HasKing
        {
            get
            {
                return Cards.Any(x => x.Rank == Enums.Enums.Rank.King);
            }
            set
            {
                HasAce = value;
            }
        }
    }
}
