using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager
{
    internal class Room
    {
        private Guest guest;
        private int number;
        private bool booked;
        private bool occupied;

        public bool Booked 
        {
            get { return booked; }
            set { booked = value; }
        }
        public bool Occupied
        { 
            get { return occupied; } 
            set { occupied = value; } 
        }
        public Guest Guest 
        {
            get { return guest; }
            set { guest = value; }
        }

    }
}
