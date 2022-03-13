using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager
{
    internal class Guest
    {

        private int id { get; set; }
        public string name { get; set; }
        public bool checkedIn { get; set; }
        public DateTime checkInTime { get; set; }
        public DateTime checkOutTime { get; set; }
        public int roomNumber { get; set; }

        public Guest() { }

        public Guest(int id, int roomNumber, DateTime checkInTime, DateTime checkOutTime, String name)
        {
            this.id = id;
            this.name = name;
            this.roomNumber = roomNumber;
            this.checkInTime = checkInTime;
            this.checkOutTime = checkOutTime;
            this.checkedIn = false;
        }

        public Guest(int id, int roomNumber, string name)
        {
            this.id = id;
            this.roomNumber = roomNumber;
            this.name = name;
            this.checkedIn = false;
        }

        public Guest(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.checkedIn = false;
        }
        public void WriteGuest()
        {
            String checker = this.checkedIn ? "Yes" : "No";
            String returner = this.name;
            Console.WriteLine($"\nGuest number: {this.id}\n" +
                $"Name: {this.name}\n" +
                $"Room Number: {this.roomNumber}\n" +
                $"Check In: {this.checkInTime}\n" +
                $"Check Out: {this.checkOutTime}\n" +
                $"Checked In: {checker}");
        }
    }
}
