using System;
using System.IO;
using System.Text;
using practice_exercises.HackerRank.Models;

namespace practice_exercises.HackerRank.Exercises
{
    public class Encryption : Exercise
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
                string plainText = TestCases[i];
                string cipherText = String.Empty;
                StringBuilder sb = new StringBuilder();

                plainText = plainText.Replace(" ", "");

                double plainTextLength = Math.Sqrt(plainText.Length);

                int rows = (int)Math.Floor(plainTextLength);
                int columns = (int)Math.Ceiling(plainTextLength);

                if (rows * columns < plainText.Length)
                {
                    rows++;
                }

                string[,] plaintextArray = new string[rows, columns];

                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < columns; k++)
                    {
                        int index = k + (columns * j);
                        if (index >= plainText.Length == false)
                        {
                            plaintextArray[j, k] = plainText[index].ToString();
                        }   else
                        {
                            plaintextArray[j, k] = "";
                        }
                    }
                }

                for (int j = 0; j < columns; j++)
                {
                    for (int k = 0; k < rows; k++)
                    {
                        sb.Append(plaintextArray[k, j]);
                    }

                    cipherText += sb.ToString() + " ";
                    sb.Clear();
                }

                Solutions.Add(cipherText);
            }
        }
    }
}
