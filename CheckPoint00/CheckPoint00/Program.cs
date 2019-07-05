using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CheckPoint00
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
                {
                    if (ValidatePN(input) == true)
                        allProducts.Add(input);
                }

                Console.ResetColor();

            } while (input.Trim().ToLower() != "exit");

            allProducts.Sort();

            Console.WriteLine();
            Console.WriteLine("Du angav följade produkter (sorterade):");

            foreach (string product in allProducts)
            {
                Console.WriteLine("* " + product);
            }
        }
        static bool ValidatePN(string input)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+-\d{3}$", RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                int num = int.Parse(input.Substring(input.Length - 3));

                if (num >= 200 && num <= 500)
                {
                    return true;
                }
                else if (num < 200 || num > 500)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Den numeriska delen måste vara mellan 200 och 500");
                    return false;
                }
                return false;
            }
            else if (input == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du får inte ange ett tomt värde");
                return false;
            }
            else if (!input.Contains("-"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Produktnumret måste innehålla ett bindestreck");
                return false;
            }
            else if (input.Length < 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Produktnumret måste vara minst 5 tecken");
                return false;
            }
            else if (input.Contains("-"))
            {
                string left = input.Substring(0, input.IndexOf("-"));
                string right = input.Substring(input.IndexOf("-") + 1);
                if (!left.All(Char.IsLetter))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felaktigt format på vänstra delen av produktnumret");
                    return false;
                }
                else if (!right.All(Char.IsDigit))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felaktigt format på högra delen av produktnumret");
                    return false;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Felaktigt produktnummer");
                return false;
            }
           
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktigt produktnummer");
            return false;
        }
    }
}
