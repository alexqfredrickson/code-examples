using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace practice_exercises.Project_Euler.Helpers
{
    public static class IntHelper
    {
        /// <summary>
        /// Gets all prime numbers up to a specified maximum.
        /// </summary>
        /// <param name="maxNumber">The highest number to check against.</param>
        /// <returns></returns>
        public static List<int> getPrimeNumbersTo(int maxNumber)
        {
            List<int> primeNumbers = new List<int>();

            primeNumbers.Add(2);

            int nextNumber = 3;

            while (primeNumbers.Last() < maxNumber)
            {
                if (LongHelper.checkIsPrimeViaTrialDivision(nextNumber))
                {
                    primeNumbers.Add(nextNumber);
                }

                nextNumber += 2;
            }
            return primeNumbers;
        }

        /// <summary>
        /// Gets all primes numbers up to a maximum integer using the Sieve of Eratosthenes, 
        /// but shouldn't be used for egregiously high numbers, as this will cause a System.OutOfMemoryException error.
        /// </summary>
        /// <param name="maxNumber"></param>
        /// <returns></returns>
        public static HashSet<int> getPrimeNumbersViaEratosthenesSieve(int maxNumber)
        {
            Dictionary<int, bool> sieve = new Dictionary<int, bool>();

            for (int i = 2; i < maxNumber; i++)
            {
                sieve.Add(i, true);
            }

            var sqrtMax = Math.Sqrt(maxNumber);

            for (int i = 2; i < sqrtMax; i++)
            {
                // e.g. if 2 -> true, all multiples of 2 (exceeding 2 itself) -> false
                if (sieve[i] == true)
                {
                    int squared_i = (int)Math.Pow(i, 2);

                    for (int j = squared_i; j < maxNumber; j += i)
                    {
                        sieve[j] = false;
                    }
                }

            }

            return sieve.Where(x => x.Value == true).Select(x => x.Key).ToHashSet();
        }

        public static HashSet<int> getReallyBigPrimeNumbersViaEratosthenesSieve(int maxNumber)
        {
            List<int> sieveKeys = new List<int>();

            List<bool> sieveValues = new List<bool>();

            for (int i = 2; i < maxNumber; i++)
            {
                sieveKeys.Add(i);
                sieveValues.Add(true);
            }

            var sqrtMax = Math.Sqrt(maxNumber);

            for (int i = 2; i < sqrtMax; i++)
            {
                if (sieveValues[i - 2] == true)
                {
                    int squared_i = (int)Math.Pow(i, 2);

                    for (int j = squared_i; j < maxNumber; j += i)
                    {
                        sieveValues[i - 2] = false;
                    }
                }

            }

            return sieveKeys.Where(x => sieveValues[sieveKeys.ElementAt(x) - 2] == true).Select(x => x).ToHashSet();
        }


        public static int GetTriangleNumberByIndex(int n)
        {
            return (n * (n + 1)) / 2;
        }

        public static bool isBouncy(int n)
        {
            bool nIncreases = false;
            bool nDecreases = false;

            while (n > 9)
            {

                int lastDigit = n % 10;
                n /= 10;

                int nextToLastDigit = n % 10;

                if (lastDigit < nextToLastDigit)
                {
                    nDecreases = true;
                }
                else if (lastDigit > nextToLastDigit)
                {
                    nIncreases = true;
                }

                if (nIncreases && nDecreases) return true;
            }

            return nIncreases && nDecreases;
        }

        public static bool isPrime(int n)
        {
            if (n < 2)
            {
                return false;
            }
            else if (n % 2 == 0)
            {
                return false;
            }
            else
            {
                for (int i = 1; i < Math.Sqrt(n); i++)
                {
                    if (n % i == 0) return false;
                }
                return true;
            }
        }

        public static bool DictionaryContainsOnlyPrimeNumbers(Dictionary<int, int> d)
        {
            bool DictionaryContainsOnlyPrimeNumbers = true;

            if (d.Keys.Count == 0)
            {
                // because the dictionary doesnt contain anything
                return false;
            }
            else
            {
                foreach (var k in d.Keys)
                {
                    if (!IntHelper.isPrime(k))
                    {
                        DictionaryContainsOnlyPrimeNumbers = false;
                    }
                }
            }

            return DictionaryContainsOnlyPrimeNumbers;
        }

        /// <summary>
        /// Returns all amicable numbers less than a given number.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static HashSet<int> getAmicableNumbersUnderN(int n)
        {
            Dictionary<int, int> sumProperDivisors = new Dictionary<int, int>();

            for (int i = 1; i < n; i++)
            {
                List<int> properDivisors = GetProperDivisors(i);
                sumProperDivisors.Add(i, properDivisors.Sum());
            }

            HashSet<int> amicableNumbers = new HashSet<int>();

            foreach (var testInt in sumProperDivisors)
            {
                int key1 = testInt.Key;
                int value1 = testInt.Value;

                if (sumProperDivisors.ContainsKey(value1))
                {
                    if (sumProperDivisors.Where(k2 => k2.Key == value1).Select(k2 => k2.Value).Single() == key1)
                    {
                        if (key1 != value1)
                        {
                            amicableNumbers.Add(key1);
                            amicableNumbers.Add(value1);
                        }
                    }
                }
            }

            return amicableNumbers;
        }

        public static List<int> GetProperDivisors(int n)
        {
            List<int> properDivisors = new List<int>();

            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    properDivisors.Add(i);
                }
            }

            return properDivisors;
        }

    }
}
