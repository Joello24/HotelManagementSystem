using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager
{
    internal class RoomManager
    {
        public static Dictionary<int, Guest> UserList = new Dictionary<int, Guest>();
        private static Guest value;
        private static bool[] rooms = new bool[10];
        private static Room[] roomss = new Room[100];
        private static int ID_LIST;
        private static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }

        public static void Run()
        {
            string input;
            do
            {
                instructions();
                input = Console.ReadLine();
                 Console.ResetColor();
                if (input == "q")
                {
                    break;
                }
                else
                {
                    ParseInput(input);
                }

            } while (input != "q");
        }

        public static void instructions()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nINSTRUCTIONS");
            Console.WriteLine("--------------------------");
            Console.ResetColor();
            Console.WriteLine("Add Guest - touch");
            Console.WriteLine("Manage Guest - cd id | name");
            Console.WriteLine("List Guests - ls");
            Console.WriteLine("Exit Hotel Manager - q");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("~ ");
        }

        public static void ParseInput(String input)
        {
            String[] command = input.Split(" ");
            switch (command[0])
            {
                case "q":
                    break;
                case "cd":
                    UserList.TryGetValue(int.Parse(command[1]), out Guest value);
                    ManageGuest(value);
                    break;
                case "touch":
                    CreateGuest(command);
                    break;
                case "ls":
                    ListGuests();
                    break;
            }
        }

        private static void ListGuests()
        {
            foreach (KeyValuePair<int, Guest> user in UserList)
            {
                if (user.Value != null)
                {
                    Console.ForegroundColor = GetRandomConsoleColor();
                    user.Value.WriteGuest();
                }
            }
            Console.ResetColor();
        }
        private static void CreateGuest(string[] commands)
        {
            int roomNumber;
            DateTime checkInTime, checkOutTime;
            String name, input;
            string firstName, lastName;
            if (commands.Length > 1)
            {
                firstName = commands[1];
                if (commands.Length > 2)
                {
                    firstName += " ";
                    firstName += commands[2];
                }
            }
            else 
            {
                Console.Write("Guest Name: ");
                firstName = Console.ReadLine();
            }
            Console.WriteLine("Enter Guest Information");
            Console.Write("Would you like to add guest room information? (y/n): ");
            input = Console.ReadLine();
            if (input == "y" | input == "Y")
            {
                PrintRooms();
                Console.WriteLine("Enter a room number: ");
                int temp = int.Parse(Console.ReadLine());
                if (temp >= 0 && temp < 11 && rooms[temp] == false)
                {
                    roomss[temp].Guest = value;
                    roomss[temp].Booked = true;
                    roomNumber = temp;
                    Guest guest = new Guest(ID_LIST, roomNumber, firstName);
                    UserList.Add(ID_LIST, guest);
                    PrintGuest(ID_LIST);
                }
            }
            else
            {
                Guest guest = new Guest(ID_LIST, firstName);
                UserList.Add(ID_LIST, guest);
                PrintGuest(ID_LIST);
            }
            ID_LIST++;
        }
        private static void PrintRooms()
        {
            int count = 0;
            foreach (bool r in rooms)
            {
                String temp = (r == true ? "Occupied" : "Open");
                Console.WriteLine($"Room {count++}: {temp}");
            }
        }
        private static void ManageGuest(Guest value)
        {
            string input;
            String[] command;
            do
            {
                ManageGuestInstructions(value);
                input = Console.ReadLine();
                Console.ResetColor();
                if (input == "q")
                {
                    break;
                }
                else
                {
                    switch (input)
                    {
                        case "1":
                            if (value.roomNumber >= 0 && value.roomNumber <= 10)
                            {
                                value.checkedIn = true;
                                rooms[value.roomNumber] = true;
                            }
                            else
                            {
                                Console.WriteLine("You must select a room before checking in");
                            }
                            break;
                        case "2":
                            value.checkedIn = false;
                            rooms[value.roomNumber] = false;
                            value.roomNumber = -1;
                            break;
                        case "3":
                            PrintRooms();
                            Console.WriteLine("Enter a new room number");
                            int temp = int.Parse(Console.ReadLine());
                            if (rooms[temp] == false)
                            {
                                if(value.roomNumber != -1)
                                    Console.WriteLine("Please checkout before assigning a new room.");
                                else
                                    value.roomNumber = temp;
                            }
                            else
                            {
                                Console.WriteLine("That room is occupied, please select a different room!");
                            }
                            break;
                        case "q":
                            break;
                    }
                }
            } while (input != "q");
            value.name = "Jimmy";
        }
        private static void ManageGuestInstructions(Guest guest)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nManaging Guest:");
            Console.ForegroundColor = ConsoleColor.Blue;
            guest.WriteGuest();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------");
            Console.ResetColor();
            Console.WriteLine("1 - Check In");
            Console.WriteLine("2 - Check Out");
            Console.WriteLine("3 - Set Room Number");
            Console.WriteLine("q - Back to Main Menu");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"~ {guest.name}: ");
        }
        private static void PrintGuest(int id)
        {
            UserList.TryGetValue(id, out Guest value);
            value.ToString();
        }
        private static Guest GetGuest(int id)
        {
            UserList.TryGetValue(id, out Guest value);
            return value;
        }

        private static void BookRoom()
        {
            
        }
        
    }
}
