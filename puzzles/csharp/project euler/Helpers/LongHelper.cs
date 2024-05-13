using System;
using System.Collections.Generic;
using System.Linq;
using practice_exercises.Project_Euler.Models.Miscellaneous;

namespace practice_exercises.Project_Euler.Helpers
{
    public static class LongHelper
    {
        #region primality

        /// <summary>
        /// Checks to see if a number is prime using trial division.
        /// </summary>
        /// <param name="n">The number to be checked.</param>
        /// <returns></returns>
        public static bool checkIsPrimeViaTrialDivision(long n)
        {
            if (n == 0) return false;

            var isPrime = true;

            long sqrtN = (long)Math.Sqrt(n);

            for (long i = 2; i <= sqrtN; i++)
            {
                if (n % i == 0) { isPrime = false; }
            }

            return isPrime;
        }

        /// <summary>
        /// Gets all prime numbers up to a specified maximum.
        /// </summary>
        /// <param name="maxNumber">The highest number to check against.</param>
        /// <returns></returns>
        public static List<long> getPrimeNumbersTo(int maxNumber)
        {
            List<long> primeNumbers = new List<long>();

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
        /// Converts a list of prime factors into a list of powers.
        /// </summary>
        /// <param name="primeFactors">The list of prime factors to be converted.</param>
        /// <returns></returns>
        public static List<Power> ExpressPrimeFactorsAsPowers(List<long> primeFactors)
        {
            List<Power> primeFactorsAsPowers = new List<Power>();
            Dictionary<long, long> primeFactorDict = new Dictionary<long, long>();

            foreach (long factor in primeFactors)
            {
                // then express the prime factors as base/value pairs
                // first, add the factors to the dictionary
                if (primeFactorDict.ContainsKey(factor) == false)
                {
                    primeFactorDict.Add(factor, 1);
                }
                else
                {
                    primeFactorDict[factor] += 1;
                }
            }

            // now all of the factorCount dictionary's factors are prime
            foreach (var primeFactor in primeFactorDict)
            {
                Power primeFactorPower = new Power()
                {
                    Base = primeFactor.Key,
                    Exponent = primeFactor.Value
                };

                primeFactorsAsPowers.Add(primeFactorPower);
            }

            return primeFactorsAsPowers;
        }

        /// <summary>
        /// Returns the prime factorization of a number.
        /// </summary>
        /// <param name="n">The number to be prime-factorized.</param>
        /// <returns></returns>
        public static List<long> GetPrimeFactorization(long n)
        {
            List<long> randFactors = new List<long>();

            while (!checkIsPrimeViaTrialDivision(n))
            {
                long randFactor = PollardsRhoAlgorithm(n);

                if (randFactor == 0)
                {
                    // if rho fails, try something else
                    long randFactor2 = GetFirstPrimeFactorByTrialDivision(n);
                    randFactors.Add(randFactor2);
                    n /= randFactor2;
                }
                else
                {
                    // a non-trivial factor of n has been found
                    randFactors.Add(randFactor);
                    n /= randFactor;
                }
            }

            // after all of this, n must be a prime factor
            randFactors.Add(n);

            // pollards rho returned a shit ton of factors that may or may not be prime
            while (randFactors.Any(x => !checkIsPrimeViaTrialDivision(x)))
            {
                long nonPrimeFactor = randFactors.Find(x => !checkIsPrimeViaTrialDivision(x));
                List<long> newFactors = GetPrimeFactorization(nonPrimeFactor);

                randFactors.Remove(nonPrimeFactor);
                randFactors.AddRange(newFactors);
            }

            return randFactors;
        }

        /// <summary>
        /// Returns a number's first prime factor using trial division.
        /// </summary>
        /// <param name="n">The number whose first prime factor is being sought.</param>
        /// <returns></returns>
        public static long GetFirstPrimeFactorByTrialDivision(long n)
        {
            long sqrtn = (long)Math.Sqrt(n);
            for (long i = 2; i <= sqrtn; i++)
            {
                if (n % i == 0 && checkIsPrimeViaTrialDivision(i))
                {
                    return i;
                }
            }

            // n is prime
            return n;
        }

        #endregion

        #region factorization

        /// <summary>
        /// Returns a count of the number's factors/divisors. 
        /// </summary>
        /// <param name="num">The number to be tested</param>
        /// <returns>The number's factor/divisor count.</returns>
        public static long GetFactorCount(long num)
        {
            if (num == 1) return 1;

            List<Power> primeFactors = ExpressPrimeFactorsAsPowers(LongHelper.GetPrimeFactorization(num));

            // todo: this is a glitch
            primeFactors.RemoveAll(x => x.Base == 1);

            long count = 1;

            foreach (Power primeFactor in primeFactors)
            {
                count *= primeFactor.Exponent + 1;
            }

            return count;
        }

        /// <summary>
        /// Returns a random factor of n.
        /// </summary>
        /// <param name="n">The number to be factored.</param>
        /// <returns>A random factor of n.</returns>
        public static long PollardsRhoAlgorithm(long n)
        {
            Random rng = new Random();
            long x = rng.Next(1, 3);
            long y = rng.Next(1, 3);

            long d = 1;

            int count = 0;
            bool keepTrying = true;

            while (d == 1 && keepTrying) // until d != 1 or keepTrying = false
            {
                // do this
                x = poly(x, n);
                y = poly(poly(y, n), n);
                d = GreatestCommonDivisor(Math.Abs(x - y), n);

                if (count > 500)
                {
                    keepTrying = false;
                    Console.WriteLine("I gave up on " + n.ToString() + ".");
                }
                else
                {
                    count++;
                }
            }

            if (d == n)
            {
                return 0;
            }
            else
            {
                return d;
            }

        }

        /// <summary>
        /// A polynomial function used by the Pollard Rho Algorithm
        /// </summary>
        /// <param name="x">A random number</param>
        /// <param name="n">The number being factorized</param>
        /// <returns></returns>
        public static long poly(long x, long n)
        {
            return ((x * x) - 1) % n;
        }


        #endregion

        #region other
        /// <summary>
        /// Finds the greatest common divisor between two longs.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static long GreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        /// <summary>
        /// Generates a Collatz sequence based off of a number.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<long> GenerateCollatzSequence(long n)
        {
            List<long> collatz = new List<long>();
            collatz.Add(n);

            do
            {
                var next = collatz.Last();

                if (next % 2 == 0)
                {
                    next = next / 2;
                }
                else if (next % 2 == 1)
                {
                    next = next * 3 + 1;
                }

                collatz.Add(next);

            } while (collatz.Last() != 1);

            return collatz;
        }

        #endregion
    }
}
