using System;
using _01_BOL;
using _00_DAL;
using System.Linq;
using System.Collections.Generic;

namespace _02_BLL
{
    internal class validateCarAvailable
    {
        internal static bool IsAvailable(BOLOrder order)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                Order dbOrder = ef.Orders.FirstOrDefault(u => u.VehiclesID == order.VehiclesID && u.ActualReturnDate == null &&
                u.ReturnDate > order.StartDate && u.ReturnDate < order.StartDate);
                if (dbOrder == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }
    }
}
