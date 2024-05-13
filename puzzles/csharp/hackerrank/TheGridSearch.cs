using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using practice_exercises.HackerRank.Models;

namespace practice_exercises.HackerRank.Exercises
{
    public class TheGridSearch : Exercise
    {
        public override void SolveTestCases()
        {
            List<TestCase> testCases = new List<TestCase>();

            using (StreamReader sr = new StreamReader(InputPath))
            {
                TestCaseCount = int.Parse(sr.ReadLine());

                for (int i = 0; i < TestCaseCount; i++)
                {
                    TestCase tc = new TestCase();

                    int[] mainGridDimensions = Array.ConvertAll(sr.ReadLine().Split(' '), x => int.Parse(x));
                    tc.MainGridRowCount = mainGridDimensions[0];
                    tc.MainGridColumnCount = mainGridDimensions[1];

                    for (int j = 0; j < tc.MainGridRowCount; j++)
                    {
                        tc.MainGridRows.Add(sr.ReadLine());
                    }

                    int[] subGridDimensions = Array.ConvertAll(sr.ReadLine().Split(' '), x => int.Parse(x));
                    tc.SubGridRowCount = subGridDimensions[0];
                    tc.SubGridColumnCount = subGridDimensions[1];

                    for (int j = 0; j < tc.SubGridRowCount; j++)
                    {
                        tc.SubGridRows.Add(sr.ReadLine());
                    }

                    testCases.Add(tc);
                }
            }

            foreach (var tc in testCases)
            {
                string row = tc.SubGridRows[0];
                List<string> foundOccurences = new List<string>();

                int columnIterations = tc.MainGridColumnCount - tc.SubGridColumnCount + 1;
                int rowIterations = tc.MainGridRowCount - tc.SubGridRowCount + 1;

                for (int k = 0; k < columnIterations; k++)
                {
                    for (int j = 0; j < rowIterations; j++)
                    {
                        string testRow = tc.MainGridRows[j].Substring(k, tc.SubGridColumnCount);
                        if (testRow == row)
                        {
                            foundOccurences.Add(j.ToString() + "," + k.ToString());
                        }
                    }
                }

                bool foundSubGrid = false;

                foreach (string coord in foundOccurences)
                {
                    int[] keyVals = Array.ConvertAll(coord.Split(',').ToArray<string>(), x => int.Parse(x));

                    int key = keyVals[0];
                    var val = keyVals[1];

                    bool foundThisOccurence = true;

                    for (int i = 0; i < tc.SubGridRowCount; i++)
                    {
                        string mainGridSubstring = tc.MainGridRows[key + i].Substring(val, tc.SubGridColumnCount);
                        string subGridSubstring = tc.SubGridRows[i];

                        if (mainGridSubstring != subGridSubstring)
                        {
                            foundThisOccurence = false;
                        }
                    }

                    if (foundThisOccurence)
                    {
                        foundSubGrid = true;
                        break;
                    }
                }
                if (foundSubGrid)
                {
                    Solutions.Add("YES");
                }
                else
                {
                    Solutions.Add("NO");
                }
            }
        }

        public class TestCase
        {
            public int MainGridRowCount { get; set; }
            public int MainGridColumnCount { get; set; }
            public List<string> MainGridRows { get; set; }

            public int SubGridRowCount { get; set; }
            public int SubGridColumnCount { get; set; }
            public List<string> SubGridRows { get; set; }

            public TestCase()
            {
                MainGridRows = new List<string>();
                SubGridRows = new List<string>();
            }
        }

    }
}

