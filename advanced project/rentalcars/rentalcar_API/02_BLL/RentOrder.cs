using _00_DAL;
using _01_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BLL
{
    public class RentOrder
    {

        public static List<BOLOrder> GetUserFrom_db()
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    List<BOLOrder> carsBOLOrder = new List<BOLOrder>();
                    foreach (var item in ef.Orders.ToList())
                    {
                        carsBOLOrder.Add(new BOLOrder
                        {
                            StartDate = item.StartDate,
                            ReturnDate = item.ReturnDate,
                            ActualReturnDate = item.ActualReturnDate,
                            UserID = item.UserID,
                            VehiclesID = item.VehiclesID,

                        });
                    }
                    return carsBOLOrder;
                }

            }
            catch (Exception) { }
            return null;
        }

        public static List<BOLOrder> GetUsersOrdesrByUserName(string UserName)
        {
            List<BOLOrder> orderList = new List<BOLOrder>();
            try
            {
                UserTable user;
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    user = ef.UserTables.FirstOrDefault(u => u.UserName == UserName);

                }
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    List<Order> dbOrder = ef.Orders.Where(u => u.ActualReturnDate == null && u.UserID == user.UserID).ToList();

                    foreach (var item in dbOrder)
                    {
                        orderList.Add(new BOLOrder
                        {
                            StartDate = item.StartDate,
                            ReturnDate = item.ReturnDate,
                            ActualReturnDate = item.ActualReturnDate,
                            UserID = item.UserID,
                            VehiclesID = item.VehiclesID,

                        });
                    }
                    return orderList;
                }
            }
            catch
            {
                return null;
            }
        }

        public static BOLOrder UpDataTo_db(BOLOrder retrievedOrder)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                Order getOrder = ef.Orders.FirstOrDefault(u => u.UserID == retrievedOrder.UserID&&u.StartDate==retrievedOrder.StartDate);
                DateTime getCorrentDate =DateTime.Today;
                getOrder.ActualReturnDate = getCorrentDate.Date;
                ef.SaveChanges();
                retrievedOrder.ActualReturnDate = getOrder.ActualReturnDate;
                return retrievedOrder;
            }
        }

        public static List<BOLOrder> GetUsersOrdesrByidNumber(string idNumber)
        {
            List<BOLOrder> orderList = new List<BOLOrder>();
            try
            {
                UserTable user;
                BOLUserInfo a = new BOLUserInfo();
             //   a.UserIdNumber = idNumber;
             //   idNumber = a.UserIdNumber;
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {

                    user = ef.UserTables.FirstOrDefault(u => u.UserIdNumber == idNumber);

                }
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    List<Order> dbOrder = ef.Orders.Where(u => u.ActualReturnDate == null && u.UserID == user.UserID).ToList();

                    foreach (var item in dbOrder)
                    {
                        orderList.Add(new BOLOrder
                        {
                            StartDate = item.StartDate,
                            ReturnDate = item.ReturnDate,
                            ActualReturnDate = item.ActualReturnDate,
                            UserID = item.UserID,
                            VehiclesID = item.VehiclesID,

                        });
                    }
                    return orderList;
                }
            }
            catch
            {
                return null;
            }
        }



        public static List<int> GetListOrderByDate(DateTime start, DateTime end)
        {
            List<int> orderedCars = new List<int>();
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    List<Order> dbOrder = ef.Orders.Where(u => u.ActualReturnDate == null).ToList();
                    if (dbOrder.Count != 0)
                    {
                        foreach (var item in dbOrder)
                        {
                            if (item.ReturnDate >= start && item.StartDate <= end || item.StartDate <= start && item.ReturnDate >= end)
                            {
                                VehicleInventory getCarInfo = ef.VehicleInventories.FirstOrDefault(u => u.VehiclesID == item.VehiclesID);
                                orderedCars.Add(getCarInfo.VehicleNumber);
                            }
                        }
                    }
                }
            }
            catch { }


            return orderedCars;
        }


        public static Boolean AddBranchTo_db(BOLOrder order)
        {
            try
            {
                if (order.StartDate >= DateTime.Now)
                {
                    if (validateCarAvailable.IsAvailable(order))
                    {
                        using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                        {
                            ef.Orders.Add(new Order
                            {
                                StartDate = order.StartDate,
                                ReturnDate = order.ReturnDate,
                                ActualReturnDate = order.ActualReturnDate,
                                UserID = order.UserID,
                                VehiclesID = order.VehiclesID
                            });
                            ef.SaveChanges();
                            return true;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"this car is not Available in this date please select another car");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"You can not select a date before the current date");
                }

            }
            catch (Exception EX)
            {
                return false;
            }
        }



        public static void UpDataTo_db(BOLOrder oldOrder, BOLOrder newOrder)
        {
            try
            {
                if (newOrder.StartDate > DateTime.Now)
                {
                    if (validateCarAvailable.IsAvailable(newOrder))
                    {
                        using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                        {
                            Order order = ef.Orders.FirstOrDefault(u => u.ReturnDate == oldOrder.ReturnDate &&
              u.StartDate == oldOrder.StartDate &&
              u.UserID == oldOrder.UserID && u.VehiclesID == oldOrder.VehiclesID);
                            if (order != null)
                            {
                                order.StartDate = newOrder.StartDate;
                                order.ReturnDate = newOrder.ReturnDate;
                                order.ActualReturnDate = newOrder.ActualReturnDate;
                                order.UserID = newOrder.UserID;
                                order.VehiclesID = newOrder.VehiclesID;

                                ef.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"this car is not Available in this date please select another car");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"You can not select a date before the current date");
                }

            }
            catch (Exception EX)
            {
            }
        }


        public static void deleteFrom_db(BOLOrder retrievedOrder)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    Order order = ef.Orders.FirstOrDefault(u => u.ReturnDate == retrievedOrder.ReturnDate &&
              u.StartDate == retrievedOrder.StartDate &&
              u.UserID == retrievedOrder.UserID && u.VehiclesID == retrievedOrder.VehiclesID);

                    if (order != null)
                    {
                        ef.Orders.Remove(order);
                        ef.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException($"this order is not exist please change the values and try again");

                    }
                }
            }
            catch (Exception EX)
            {
            }
        }

    }
}
