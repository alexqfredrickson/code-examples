using System;
using System.Collections.Generic;
using System.IO;
using practice_exercises.HackerRank.Models;

namespace practice_exercises.HackerRank.Exercises
{
    public class ManasaAndStones : Exercise
    {
        public override void SolveTestCases()
        {
            using (StreamReader sr = new StreamReader(InputPath))
            {
                int t = int.Parse(sr.ReadLine());

                for (int i = 0; i < t; i++)
                {
                    int n = int.Parse(sr.ReadLine());
                    int a = int.Parse(sr.ReadLine());
                    int b = int.Parse(sr.ReadLine());

                    HashSet<int> solutions = new HashSet<int>();
                    List<int> intSolutions = new List<int>();

                    GetNextStep(0, 1, ref a, ref b, ref n, ref solutions);

                    foreach (int x in solutions)
                    {
                        intSolutions.Add(x);
                    }

                    intSolutions.Sort();

                    string s = String.Empty;

                    for (int j = 0; j < intSolutions.Count; j++)
                    {
                        s += intSolutions[j] + " ";
                    }

                    s = s.Substring(0, s.Length - 1);
                    Solutions.Add(s);
                }
            }
        }

        static void GetNextStep(int count, int stepCount, ref int a, ref int b, ref int n, ref HashSet<int> solutions)
        {
            if (stepCount == n)
            {
                solutions.Add(count);
            }
            else
            {
                GetNextStep(count + a, stepCount + 1, ref a, ref b, ref n, ref solutions);
                GetNextStep(count + b, stepCount + 1, ref a, ref b, ref n, ref solutions);
            }
        }
    }
}
