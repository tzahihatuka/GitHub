using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel
{
    class Hotel: building
    {


        public int NumberOfRooms = GetRandomNumber(90, 100);
        public int NumberOfRoomsOccupied = GetRandomNumber(10, 90);
        public Country country { get; set; }
        public Service[] ServicesoOfferedAtTheHotel =new Service[3];
 


        public Hotel(int numOfStoreys, bool Elevator) : base(numOfStoreys, Elevator)
        {

        }



        public override string GetDetails()
        {
            return ($"Services Offered At The Hotel {ServicesoOfferedAtTheHotel[0]} , {ServicesoOfferedAtTheHotel[1]} , {ServicesoOfferedAtTheHotel[2]}\n Country {country}\n Number Of Rooms Occupied {NumberOfRoomsOccupied}\n Number Of Rooms {NumberOfRooms}\n");
        }


        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) 
            {
                return getrandom.Next(min, max);
            }
        }

        
    }
}
