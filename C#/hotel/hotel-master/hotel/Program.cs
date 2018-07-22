using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel
{
    class Program
    {
        static void Main(string[] args)
        {
             
           building building = new Hotel(1,true);
            building[] build = { new Hotel(3, true), new Hotel(4, false), new Hotel(5, true), new Hotel(7, false), new Hotel(12, true) };

            foreach (building item in build)
            {
                Console.WriteLine(item.GetDetails());
            }

        }
        
    }
}
