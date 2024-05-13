using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace practice_exercises.Google_Code_Jam_2016.Counting_Sheep
{
    public static class CountingSheep
    {
        public static void Solve()
        {
            StreamReader sr = new StreamReader(FilePaths.CountingSheepBigInput);
            int t = Convert.ToInt32(sr.ReadLine());
            List<string> output = new List<string>();

            for (int i = 0; i < t; i++)
            {
                string n = sr.ReadLine();
                List<string> counted = new List<string>();
                string solution = CountSheep(n, 1, ref counted);
                output.Add(solution);
            }

            sr.Close();

            StreamWriter sw = new StreamWriter(FilePaths.CountingSheepBigOutput);
            for (int i = 1; i <= output.Count(); i++)
            {
                sw.WriteLine("Case #{0}: " + output.ElementAt(i - 1), i.ToString());
            }

            sw.Close();
        }

        public static string CountSheep(string n, int m, ref List<string> counted)
        {
            string currentNumber = (Convert.ToInt32(n) * m).ToString();

            if (currentNumber == "0")
            {
                return "INSOMNIA";
            }
            else
            {
                char[] numbers = currentNumber.ToCharArray();
                foreach (char c in numbers)
                {
                    if (!counted.Contains(c.ToString()))
                    {
                        counted.Add(c.ToString());
                    }
                }

                if (counted.Count == 10)
                {
                    return currentNumber;
                }
                else
                {
                    m += 1;
                    return CountSheep(n, m, ref counted);
                }
            }
        }
    }
}
