using System;
using System.Collections.Generic;

namespace CheckPoint01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write command: ");
            string input = Console.ReadLine();

            List<char> typeOfTriangle = ParseInputToType(input);
            List<int> sizeOfTriangle = ParseInputToSize(input);

            for (int i = 0; i < sizeOfTriangle.Count; i++)
            {
                PrintTriangle(typeOfTriangle[i], sizeOfTriangle[i]);
                Console.WriteLine();
            }

        }

        private static void PrintTriangle(char typeOfTriangle, int sizeOfTriangle)
        {
            if (typeOfTriangle == 'A')
            {
                for (int x = 0; x < sizeOfTriangle; x++)
                {
                    for (int y = 0; y <= x; y++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            else if (typeOfTriangle == 'B')
            {
                for (int x = sizeOfTriangle; x > 0; x--)
                {
                    for (int y = 0; y < x; y++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }
        private static List<char> ParseInputToType(string input)
        {
            string[] splittedInput = input.Split('-');

            var typeOfTriangle = new List<char>();

            foreach (string letter in splittedInput)
            {
                typeOfTriangle.Add(letter[0]);
            }

            return typeOfTriangle;
        }

        private static List<int> ParseInputToSize(string input)
        {
            string[] splittedInput = input.Split('-');

            var sizeOfTriangle = new List<int>();

            foreach (string number in splittedInput)
            {
                sizeOfTriangle.Add(int.Parse(number.Remove(0, 1)));
            }

            return sizeOfTriangle;
        }
    }
}
