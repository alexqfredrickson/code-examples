using System.Collections.Generic;
using System.IO;

namespace practice_exercises.HackerRank.Models
{
    /// <summary>
    /// An exercise.
    /// </summary>
    public abstract class Exercise
    {
        public const string InputPath = FilePaths.InputPath;
        public const string OutputPath = FilePaths.OutputPath;

        public List<string> TestCases;
        public int TestCaseCount;

        public List<dynamic> Solutions;

        public void TrimWhitespaceFromInput()
        {
            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader(InputPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line.Trim());
                }
            }

            using (StreamWriter sw = new StreamWriter(InputPath))
            {
                foreach (var line in lines)
                {
                    sw.WriteLine(line);
                }
            }
        }

        public abstract void SolveTestCases();

        public void WriteSolutions(List<dynamic> solutions)
        {
            using (StreamWriter sw = new StreamWriter(OutputPath))
            {
                foreach (var s in solutions)
                {
                    sw.WriteLine(s.ToString());
                }
            }
        }

        public void Solve()
        {
            TrimWhitespaceFromInput();
            SolveTestCases();
            WriteSolutions(Solutions);
        }

        public Exercise()
        {
            Solutions = new List<dynamic>();
        }
    }
}
