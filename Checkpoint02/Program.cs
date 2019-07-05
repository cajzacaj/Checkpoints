using System;
using System.Collections.Generic;

namespace Checkpoint02
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n-------------------------------------------------------\n");

                    List<Room> roomsFromUser = BuildRoomsList();
                    DisplayRooms(roomsFromUser);
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
                
            }
            
        }

        private static List<Room> BuildRoomsList()
        {
            var listOfRooms = new List<Room>();

            Console.WriteLine("Ange rum i lägenheten:");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("invalid input");

            string[] allRooms = input.Split('|');

            foreach (string room in allRooms)
            {
                var newRoom = new Room();
                string[] oneRoom = room.Trim().Split(' ');

                newRoom.Name = oneRoom[0];

                if (int.TryParse(oneRoom[1].Remove(oneRoom[1].Length - 2, 2), out int size))
                    newRoom.SizeInM2 = size;
                else
                    throw new ArgumentException("invalid input");

                if (oneRoom[2].ToLower() == "on")
                    newRoom.LightsOn = true;
                else if (oneRoom[2].ToLower() == "off")
                    newRoom.LightsOn = false;
                else
                    throw new ArgumentException("invalid input");

                listOfRooms.Add(newRoom);
            }

            return listOfRooms;
        }

        private static void DisplayRooms(List<Room> roomsFromUser)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();

            var roomsWithLightsOn = new List<Room>();

            foreach (var room in roomsFromUser)
            {
                if (room.LightsOn == true)
                    roomsWithLightsOn.Add(room);
            }

            if (roomsWithLightsOn.Count == 0)
                Console.WriteLine("Inget rum är tänt");
            else if (roomsWithLightsOn.Count == 1)
                Console.WriteLine($"Ljuset är tänt i {roomsWithLightsOn[0].Name}");
            else if (roomsWithLightsOn.Count > 1)
            {
                Console.Write("Ljuset är tänt i ");
                for (int i = 0; i < roomsWithLightsOn.Count; i++)
                {
                    if (i == 0)
                        Console.Write(roomsWithLightsOn[i].Name);
                    else
                        Console.Write($" och {roomsWithLightsOn[i].Name}");
                }
                Console.WriteLine();
            }

            var largestRoom = new Room();

            for (int i = 0; i < roomsFromUser.Count; i++)
            {
                if (i == 0)
                    largestRoom = roomsFromUser[i];
                else if (roomsFromUser[i].SizeInM2 > largestRoom.SizeInM2)
                    largestRoom = roomsFromUser[i];
            }
            Console.WriteLine($"Det största rummet är {largestRoom.Name}, på {largestRoom.SizeInM2}m2");
            Console.WriteLine($"Lägenheten består av {roomsFromUser.Count} rum");
            Console.ResetColor();
        }
    }
}
