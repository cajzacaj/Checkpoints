using System;

namespace Level1
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
                allProducts.Add(input);
            } while (input != "exit");

            Console.WriteLine();
            Console.WriteLine("Du angav följade produkter:");
            for (int i = 0; i < allProducts.Count - 1; i++)
            {
                Console.WriteLine("* " + allProducts[i]);
            }
        }
    }
}
