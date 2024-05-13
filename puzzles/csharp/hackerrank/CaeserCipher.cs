using System;
using System.IO;
using practice_exercises.HackerRank.Models;

namespace practice_exercises.HackerRank.Exercises
{
    public class CaeserCipher : Exercise
    {
        public override void SolveTestCases()
        {
            using (StreamReader sr = new StreamReader(InputPath))
            {
                int n = int.Parse(sr.ReadLine());
                char[] s = sr.ReadLine().ToCharArray();
                int k = int.Parse(sr.ReadLine());

                for (int i = 0; i < s.Length; i++)
                {
                    s[i] = s[i].Rotate(k);
                }

                Solutions.Add(String.Join("", s));
            }
        }
    }

    public static class CaeserCipherExtensions
    {
        public static char Rotate(this Char c, int n)
        {
            // A 65
            // Z 90
            // a 97
            // z 122
            int val = c;
            n = n % 26;

            if (c.IsAlphabetical() == false)
            {
                return c;
            }
            else
            {
                if (c.IsUppercase())
                {
                    val += n;
                    if (val > 90)
                    {
                        val = val - 90 + 65 - 1;
                    }
                }
                else
                {
                    val += n;

                    if (val > 122)
                    {
                        val = val - 122 + 97 - 1;
                    }

                }
            }

            return (char)val;
        }

        public static bool IsUppercase(this Char c)
        {
            return ((int)c < 91 && (int)c > 64);
        }

        public static bool IsAlphabetical(this Char c)
        {
            return ((int)c < 65 || ((int)c > 90 && (int)c < 97) || (int)c > 122) == false;
        }
    }
}
