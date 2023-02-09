using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ListMegaPrimeNumbers
{
    public class MegaPrimeNumbers
    {
        #region Prime number processing V1

        /// <summary>
        /// Collects Mega prime numbers less than the given max number
        /// </summary>
        /// <param name="max">upper limit for the calculation</param>
        /// <returns>List of Mega Prime numbers</returns>
        public IEnumerable<uint> FindMegaPrimeNumbersV1(uint max)
        {
            List<uint> megaPrimeNumbers = new List<uint>();
            try
            {
                List<uint> primeNumbersToWorkOn = GetRange(max).Select(num => IsPrime(num) ? num : 0).ToList();

                /// To reduce the number of iterations
                /// working only with odd numbers and avoiding all the even numbers. 
                /// So adding 2 by default
                if (max > 1) { 
                    megaPrimeNumbers.Add(2);
                }

                megaPrimeNumbers.AddRange(primeNumbersToWorkOn.Select(pnums =>
                                                GetDigits(pnums).All(d => IsPrime(d)) ? pnums : 0).ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during Mega Prime Numbers identification - {ex.Message}");
            }
            return megaPrimeNumbers;
        }

        /// <summary>
        /// Will get the range of number to be considered for calculation
        /// </summary>
        /// <param name="max">upper limit for the calculation</param>
        /// <returns>list of all numbers to be calculated - even numbers</returns>
        public IEnumerable<uint> GetRange(uint max)
        {
            List<uint> numbersTobeChecked = new List<uint>();
            for (uint ui = 3; ui <= max; ui += 2)
            {
                numbersTobeChecked.Add(ui);
            }
            return numbersTobeChecked;
        }

        /// <summary>
        /// Will split the prime number into each digit, to match for Mega Prime
        /// </summary>
        /// <param name="source">prime number</param>
        /// <returns>list of digits in given prime number</returns>
        public IEnumerable<uint> GetDigits(uint source)
        {
            List<uint> allDigits = new List<uint>();
            while (source > 0)
            {
                var digit = source % 10;
                source /= 10;
                allDigits.Add(digit);
            }

            return allDigits;
        }

        /// <summary>
        /// Metohd will calculate if the given number is prime or not
        /// </summary>
        /// <param name="num">number to be verified</param>
        /// <returns>True if the given number is Prime</returns>
        public Boolean IsPrime(uint num)
        {
            for (uint i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;

        }

        #endregion

        #region Prime number processing V2
        /// <summary>
        /// Collects Mega prime numbers less than the given max number
        /// </summary>
        /// <param name="max">upper limit for the calculation</param>
        /// <returns>List of Mega Prime numbers</returns>
        public IEnumerable<uint> FindMegaPrimeNumbersV2(uint max)
        {
            List<uint> megaPrimeNumbers = new List<uint>();

            try
            {

                megaPrimeNumbers.AddRange(GeneratePrimesFromSieveOfEratosthenes(max).Select(pnums =>
                                            Regex.IsMatch(Convert.ToString(pnums), @"^[2357]+$") ? pnums : 0).ToList());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error occured during Mega Prime Numbers identification - {ex.Message}");
            }
            return megaPrimeNumbers;
        }

        /// <summary>
        /// Generate the list of prime numbers using sieve of eratosthenes algorithm
        /// In this, the multiples of prime numbers will be marked as invalid to find the list of prime numbers 
        /// </summary>
        /// <param name="n">upper limit</param>
        /// <returns>list of prime numbers</returns>
        public IEnumerable<uint> GeneratePrimesFromSieveOfEratosthenes(uint n)
        {
            List<uint> primeNumbers = new List<uint>();

            try
            {
                ///Step-1: 
                ///Defining a boolean collection, all as true
                ///assuming all the numbers are prime to start with
                Dictionary<uint, bool> isPrime = new Dictionary<uint, bool>();
                for (uint i = 2; i <= n; i++)
                {
                    isPrime[i] = true;
                }

                ///Step-2
                ///marking the multiple of prime numbers as false
                ///so by the end of looping we end up with list of 
                ///numbers which are not multiple of prime numbers
                for (uint p = 2; p * p < n; p++)
                {
                    if (isPrime[p])
                    {
                        for (uint i = p * p; i < n; i += p)
                        {
                            isPrime[i] = false;
                        }
                    }
                }

                ///Listing done the remaining numbers marked as true in the collection
                for (uint i = 2; i <= n; i++)
                {
                    if (isPrime[i])
                    {
                        primeNumbers.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return primeNumbers;
        }
        #endregion
    }
}
