using System;
using System.Collections.Generic;
using System.Linq;

namespace ListMegaPrimeNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            startProcessing();
        }

        private static void startProcessing()
        {
            bool bktop = true;
            List<uint> megaPrimeNumbers;
            MegaPrimeNumbers lmegaprimenumbersObj;

            do
            {
                Console.Write("Enter a number to find all mega primes below that: ");
                uint max;
                string input = Console.ReadLine();

                if (!uint.TryParse(input, out max))
                {
                    Console.WriteLine($"'{input}' is an invalid input, please try again : ");
                }
                else
                {
                    megaPrimeNumbers = new List<uint>();
                    lmegaprimenumbersObj = new MegaPrimeNumbers();

                    //megaPrimeNumbers = lmegaprimenumbersObj.FindMegaPrimeNumbersV1(max).ToList();
                    megaPrimeNumbers = lmegaprimenumbersObj.FindMegaPrimeNumbersV2(max).ToList();

                    Console.WriteLine($"Mega primes\r\n[{String.Join(",", megaPrimeNumbers.FindAll(x => (x != 0)).ToList())}]\r\n");
                    Console.Write("do you want to run another test? (Y/N) :");
                    string option = Console.ReadLine();

                    if (option.ToUpper() != "Y")
                    {
                        bktop = false;
                    }
                }

            } while (bktop);
        }


    }
}
