using System;
using System.Collections.Generic;

namespace Level2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var allProducts = new List<string>();
            Console.WriteLine("Skriv in produkter. Avsluta med att skriva exit.");


            do
            {
                input = Console.ReadLine();
                if (input.Trim().ToLower() != "exit")
                    allProducts.Add(input);
            } while (input.Trim().ToLower() != "exit");

            allProducts.Sort();

            Console.WriteLine();
            Console.WriteLine("Du angav följade produkter:");

            foreach (string product in allProducts)
            {
                Console.WriteLine("* " + product);
            }
        }
    }
}
