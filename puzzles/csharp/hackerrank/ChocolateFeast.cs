using System;
using System.IO;
using practice_exercises.HackerRank.Models;

namespace practice_exercises.HackerRank.Exercises
{
    public class ChocolateFeast : Exercise
    {
        public override void SolveTestCases()
        {
            using (StreamReader sr = new StreamReader(InputPath))
            {
                TestCaseCount = int.Parse(sr.ReadLine());

                for (int i = 0; i < TestCaseCount; i++)
                {
                    TestCases.Add(sr.ReadLine());
                }
            }

            for (int i = 0; i < TestCases.Count; i++)
            {
                int[] testCaseData = Array.ConvertAll(TestCases[i].Split(), x => int.Parse(x));
                TestCase tc = new TestCase(testCaseData[0], testCaseData[1], testCaseData[2]);

                /// buy chocolates 
                tc.WrappedChocolates = tc.Money / tc.Price;
                tc.Money = tc.Money % tc.Price;
                
                // unwrap chocolates
                tc.UnwrappedChocolates += tc.WrappedChocolates;
                tc.Wrappers += tc.WrappedChocolates;
                tc.WrappedChocolates = 0;

                // utilize discount if possible
                while (tc.Wrappers >= tc.WrapperDiscount)
                {
                    // buy chocolates with discount if possible
                    tc.WrappedChocolates += tc.Wrappers / tc.WrapperDiscount;
                    tc.Wrappers = tc.Wrappers % tc.WrapperDiscount;

                    // unwrap chocolates
                    tc.UnwrappedChocolates += tc.WrappedChocolates;
                    tc.Wrappers += tc.WrappedChocolates;
                    tc.WrappedChocolates = 0;
                }

                Solutions.Add(tc.UnwrappedChocolates.ToString());
            }
        }

        public class TestCase
        {
            public int Money { get; set; }
            public int Price { get; }
            public int WrappedChocolates { get; set; }
            public int UnwrappedChocolates { get; set; }
            public int Wrappers { get; set; }
            public int WrapperDiscount { get; set; }

            public TestCase(int money, int price, int wrappers)
            {
                Money = money;
                Price = price;
                WrapperDiscount = wrappers;
            }
        }
    }
}
