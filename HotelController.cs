using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager
{
    internal class HotelController
    {

        public static void Run()
        {
            int roomNum = 0;
            do
            {
                Console.Write("Enter the number of capsules: ");
                int.TryParse(Console.ReadLine(), out roomNum);
            }
            while (roomNum == 0);

            string[] rooms = new string[roomNum];
            Console.WriteLine($"There are {roomNum} unoccupied rooms ready to be booked.");
            bool going = true;
            while (going)
            {
                switch (MainMenu())
                {
                    case "1":
                        CheckIn(rooms);
                        break;
                    case "2":
                        CheckOut(rooms);
                        break;
                    case "3":
                        ViewGuests(rooms);
                        break;
                    case "4":
                        going = false;
                        break;
                    default:
                        break;
                }
            }

        }

        private static string MainMenu()
        {
            Console.Write(@"Guest Menu
        ==========
        1. Check In
        2. Check Out
        3. View Guests
        4. Exit
        Choose on option [1-4]:");
            return Console.ReadLine();
        }

        private static string[] CheckIn(string[] rooms)
        {
            bool settingRoom = true;
            Console.WriteLine("Guest Check In");
            Console.WriteLine("===============");
            Console.Write("Guest Name: ");
            string guest = Console.ReadLine();

            while (settingRoom)
            {
                Console.Write($"Room #[0-{rooms.Length}]: ");
                string newRoom = Console.ReadLine();
                if (string.IsNullOrEmpty(rooms[int.Parse(newRoom)]))
                {
                    Console.WriteLine("Success :) ");
                    Console.WriteLine($"{guest} is booked in room #{newRoom}.");
                    rooms[int.Parse(newRoom)] = guest;
                    settingRoom = false;
                }
                else
                {
                    Console.WriteLine($"Room #{newRoom} is occupied.");
                }
            }
            return rooms;
        }
        private static string[] CheckOut(string[] rooms)
        {
            bool checkingOut = true;
            Console.WriteLine("Guest Check Out");
            Console.WriteLine("===============");

            while (checkingOut)
            {
                Console.Write($"Room #[0-{rooms.Length}]: ");
                string roomNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(rooms[int.Parse(roomNumber)]))
                {
                    Console.WriteLine($"Room #{roomNumber} is unoccupied.");
                }
                else
                {
                    Console.WriteLine("Success :) ");
                    Console.WriteLine($"{rooms[int.Parse(roomNumber)]} checked out of room #{roomNumber}.");
                    rooms[int.Parse(roomNumber)] = "";
                    checkingOut = false;
                }
            }
            return rooms;
        }
        private static void ViewGuests(string[] rooms)
        {
            Console.WriteLine();
            int index;
            do
            {
                Console.Write($"Room #[0-{rooms.Length}]: ");
                int.TryParse(Console.ReadLine(), out index);
            }
            while (index == 0);
            int lowindex = index - 5;
            int highindex = index + 5;
            if (lowindex < 0) { lowindex = 0; }
            if (highindex > rooms.Length - 1) { highindex = rooms.Length - 1; }
            for (int i = lowindex; i <= highindex; i++)
            {
                string tri = string.IsNullOrEmpty(rooms[i]) == true ? "[Unoccupied]" : rooms[i];
                Console.WriteLine($"{i}: {tri}");
            }
        }
    }
}

