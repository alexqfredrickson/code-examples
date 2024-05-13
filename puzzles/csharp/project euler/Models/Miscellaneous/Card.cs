namespace practice_exercises.Project_Euler.Models.Miscellaneous
{
    public class Card
    {
        public Enums.Enums.Rank Rank { get; set; }
        public Enums.Enums.Suit Suit { get; set; }

        public Card() { }

        public Card(char rank, char? suit)
        {
            switch (rank)
            {
                case 'A':
                    this.Rank = Enums.Enums.Rank.Ace;
                    break;
                case 'K':
                    this.Rank = Enums.Enums.Rank.King;
                    break;
                case 'Q':
                    this.Rank = Enums.Enums.Rank.Queen;
                    break;
                case 'J':
                    this.Rank = Enums.Enums.Rank.Jack;
                    break;
                case 'T':
                    this.Rank = Enums.Enums.Rank.Ten;
                    break;
                case '9':
                    this.Rank = Enums.Enums.Rank.Nine;
                    break;
                case '8':
                    this.Rank = Enums.Enums.Rank.Eight;
                    break;
                case '7':
                    this.Rank = Enums.Enums.Rank.Seven;
                    break;
                case '6':
                    this.Rank = Enums.Enums.Rank.Six;
                    break;
                case '5':
                    this.Rank = Enums.Enums.Rank.Five;
                    break;
                case '4':
                    this.Rank = Enums.Enums.Rank.Four;
                    break;
                case '3':
                    this.Rank = Enums.Enums.Rank.Three;
                    break;
                case '2':
                    this.Rank = Enums.Enums.Rank.Two;
                    break;
                default:
                    this.Rank = Enums.Enums.Rank.None;
                    break;
            }

            switch (suit)
            {
                case 'H':
                    this.Suit = Enums.Enums.Suit.Hearts;
                    break;
                case 'D':
                    this.Suit = Enums.Enums.Suit.Diamonds;
                    break;
                case 'C':
                    this.Suit = Enums.Enums.Suit.Clubs;
                    break;
                case 'S':
                    this.Suit = Enums.Enums.Suit.Spades;
                    break;
                default:
                    this.Suit = Enums.Enums.Suit.None;
                    break;
            }
        }
    }
}
