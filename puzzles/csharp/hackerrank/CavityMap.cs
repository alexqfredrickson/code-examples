using System;
using System.IO;
using practice_exercises.HackerRank.Models;

namespace practice_exercises.HackerRank.Exercises
{
    public class CavityMap : Exercise
    {
        public override void SolveTestCases()
        {
            using (StreamReader sr = new StreamReader(InputPath))
            {
                int n = int.Parse(sr.ReadLine());
                int[,] grid = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    string line = sr.ReadLine();
                    int[] lineArray = Array.ConvertAll(line.ToCharArray(), x => int.Parse(x.ToString()));

                    for (int j = 0; j < n; j++)
                    {
                        grid[i, j] = lineArray[j];
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == 0 || j == 0 || j == n - 1 || i == n - 1)
                        {
                            continue;
                        }
                        else
                        {
                            int up = grid[i - 1, j];
                            int down = grid[i + 1, j];
                            int left = grid[i, j - 1];
                            int right = grid[i, j + 1];
                            int pointer = grid[i, j];

                            if (pointer > down && pointer > up && pointer > left && pointer > right)
                            {
                                grid[i, j] = 10;
                            }
                        }                       
                    }
                }

                string[,] solutionGrid = new string[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (grid[i, j] == 10)
                        {
                            solutionGrid[i, j] = "X";
                        }
                        else
                        {
                            solutionGrid[i, j] = grid[i, j].ToString();
                        }
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    string s = "";

                    for (int j = 0; j < n; j++)
                    {
                        s += solutionGrid[i, j];
                    }

                    Solutions.Add(s);
                }
            }
        }
    }
}
