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
            bool isSettingRoom = true;
            Console.WriteLine("Guest Check In");
            Console.WriteLine("===============");
            Console.Write("Guest Name: ");
            string guestName = Console.ReadLine();

            while (isSettingRoom)
            {
                int newRoom = GetIntInput(rooms);

                if (string.IsNullOrEmpty(rooms[newRoom]))
                {
                    Console.WriteLine("Success :) ");
                    Console.WriteLine($"{guestName} is booked in room #{newRoom}.");
                    rooms[newRoom] = guestName;
                    isSettingRoom = false;
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
                int roomNumber = GetIntInput(rooms);

                if (string.IsNullOrEmpty(rooms[roomNumber]))
                {
                    Console.WriteLine($"Room #{roomNumber} is unoccupied.");
                }
                else
                {
                    Console.WriteLine("Success :) ");
                    Console.WriteLine($"{rooms[roomNumber]} checked out of room #{roomNumber}.");
                    rooms[roomNumber] = "";
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
        private static int GetIntInput(string[] rooms)
        {
            int theNumber = -1;
            bool isGettingNumber = true;
            while (isGettingNumber)
            {
                Console.Write($"Room #[0-{rooms.Length}]: ");
                if (int.TryParse(Console.ReadLine(), out theNumber) == true && theNumber >= 0 && theNumber < rooms.Length)
                {
                    isGettingNumber = false;
                }
            }

            return theNumber;

        }
    }
}

