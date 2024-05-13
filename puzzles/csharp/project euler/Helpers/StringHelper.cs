using System;
using System.Collections.Generic;
using System.Linq;

namespace practice_exercises.Project_Euler.Helpers
{
    public static class StringHelper
    {
        public static string toBinary(int i)
        {
            int bin = 524288;
            string result = "";
            while (bin >= 1)
            {
                if (i >= bin)
                {
                    i -= bin;
                    bin /= 2;
                    result += "1";
                }
                else
                {
                    bin /= 2;
                    result += "0";
                }
            }

            if (i == 1) result += "1";

            return result;
        }

        public static string reverse(string b)
        {
            string reverse = "";
            for (int i = b.Length - 1; i >= 0; i--)
            {
                reverse += b.Substring(i, 1);
            }
            return reverse;
        }

        public static bool IsPalindromic(string s)
        {
            //from http://www.dotnetperls.com/palindrome
            int min = 0;
            int max = s.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = s[min];
                char b = s[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static bool ArePermutations(string firstString, string secondString)
        {
            char[] first = firstString.ToCharArray();
            char[] second = secondString.ToCharArray();

            Array.Sort(first);
            Array.Sort(second);

            return first.SequenceEqual(second);
        }
        
        public static void GenerateHeapPermutations(int n, ref string s, List<string> sList)
        {
            if (n == 1)
            {
                sList.Add(s);
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    GenerateHeapPermutations(n - 1, ref s, sList);

                    if (n % 2 == 0)
                    {
                        // swap the positions of two characters
                        var charArray = s.ToCharArray();
                        var temp = charArray[i];
                        charArray[i] = charArray[n - 1];
                        charArray[n - 1] = temp;
                        s = new String(charArray);
                    }
                    else
                    {
                        var charArray = s.ToCharArray();
                        var temp = charArray[0];
                        charArray[0] = charArray[n - 1];
                        charArray[n - 1] = temp;
                        s = new String(charArray);
                    }
                }

                GenerateHeapPermutations(n - 1, ref s, sList);
            }
        }
    }
}
