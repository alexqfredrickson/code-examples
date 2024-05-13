using System;
using System.IO;
using practice_exercises.HackerRank.Models;

namespace practice_exercises.HackerRank.Exercises
{
    public class TaumAndBday : Exercise
    {
        long BlackGiftCost { get; set; }
        long WhiteGiftCost { get; set; }
        long ConversionCost { get; set;}
        long BlackGiftsNeeded { get; set; }
        long WhiteGiftsNeeded { get; set; }

        public override void SolveTestCases()
        {
            using (StreamReader sr = new StreamReader(InputPath))
            {
                int t = Convert.ToInt32(sr.ReadLine());

                for (int a0 = 0; a0 < t; a0++)
                {
                    string[] tokens_b = sr.ReadLine().Split(' ');
                    BlackGiftsNeeded = Convert.ToInt64(tokens_b[0]);
                    WhiteGiftsNeeded = Convert.ToInt64(tokens_b[1]);
                    string[] tokens_x = sr.ReadLine().Split(' ');
                    BlackGiftCost = Convert.ToInt64(tokens_x[0]);
                    WhiteGiftCost = Convert.ToInt64(tokens_x[1]);
                    ConversionCost = Convert.ToInt64(tokens_x[2]);

                    long cost = 0;

                    if (WhiteGiftCost + ConversionCost < BlackGiftCost)
                    {
                        cost += BlackGiftsNeeded * (WhiteGiftCost + ConversionCost);
                    }
                    else
                    {
                        cost += BlackGiftsNeeded * BlackGiftCost;
                    }

                    if (BlackGiftCost + ConversionCost < WhiteGiftCost)
                    {
                        cost += WhiteGiftsNeeded * (BlackGiftCost + ConversionCost);
                    }
                    else
                    {
                        cost += WhiteGiftsNeeded * WhiteGiftCost;
                    }

                    Solutions.Add(cost.ToString());
                }
            }
        }
    }
}
