namespace practice_exercises.Project_Euler.Enums
{
    public static class Enums
    {
        public enum Suit
        {
            None = 0, Hearts, Spades, Clubs, Diamonds
        }

        public enum HandType
        {
            HighCard = 1, OnePair, TwoPair, Trips, Straight, Flush, FullHouse, Quads, StraightFlush, RoyalFlush
        }

        public enum Rank
        {
            None = 0, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
        }
    }
}
