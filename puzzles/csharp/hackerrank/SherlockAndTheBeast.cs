using System.IO;
using System.Linq;
using System.Text;
using practice_exercises.HackerRank.Models;

namespace practice_exercises.HackerRank.Exercises
{
    public class SherlockAndTheBeast : Exercise
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
                int testCase = int.Parse(TestCases[i]);
                int temp = testCase;

                StringBuilder sb = new StringBuilder();

                while (temp != 0)
                {
                    if (temp % 3 == 0)
                    {
                        for (int j = 0; j < temp / 3; j++)
                        {
                            sb.Append("555");
                        }

                        break;
                    }
                    else
                    {
                        temp -= 5;

                        if (temp < 0)
                        {
                            sb.Clear();
                            sb.Append("-1");
                            break;
                        }
                        else
                        {
                            sb.Append("33333");
                        }
                    }
                }

                if (sb.ToString() == "-1")
                {
                    Solutions.Add("-1");
                }
                else
                {
                    Solutions.Add(new string(sb.ToString().Reverse().ToArray()));
                }
            }
        }
    }
}
