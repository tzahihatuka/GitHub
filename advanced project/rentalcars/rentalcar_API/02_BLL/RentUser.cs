using _01_BOL;
using _00_DAL;
using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_BLL
{
    public class RentUser
    {

        public static BOLUserInfo GetLoginUserFrom_db(string UserIdNumber)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    BOLUserInfo UsersInfo = new BOLUserInfo();

                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserIdNumber == UserIdNumber);
                    if (dbUser != null)
                    {
                        UsersInfo.FullUserName = dbUser.FullUserName;
                        UsersInfo.UserIdNumber = dbUser.UserIdNumber;
                        UsersInfo.UserName = dbUser.UserName;
                        UsersInfo.Password = dbUser.Password;
                        UsersInfo.BirthDay = dbUser.BirthDay;
                        UsersInfo.Sex = dbUser.Sex;
                        UsersInfo.UserRole = dbUser.UserRole;
                        UsersInfo.UserPic = dbUser.UserPic;
                        UsersInfo.Email = dbUser.Email;

                        return UsersInfo;
                    }
                }
            }
            catch { return null; }
            return null;

        }

        public static string GetUserName(int userID)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                BOLUserInfo UsersInfo = new BOLUserInfo();

                UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserID == userID);
                if (dbUser != null)
                {
                    return dbUser.UserName;
                }
                else {
                    return null;
                }
            }
        }

        public static int GetLogin(string userName,string password)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                UserTable user = ef.UserTables.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            int UserRole= user.UserRole;
                return UserRole;
            }
        
        }

        public static void AddUserTo_db(BOLUserInfo userInfo)
        {
            try
            {
                
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    
                   
                    ValidateUserInput.CheckUnique(userInfo.UserName, userInfo.UserIdNumber);

                    ef.UserTables.Add(new UserTable
                    {
                        FullUserName = userInfo.FullUserName,
                        UserIdNumber = userInfo.UserIdNumber,
                        UserName = userInfo.UserName,
                        Password = userInfo.Password,
                        BirthDay = userInfo.BirthDay,
                        Sex = userInfo.Sex,
                        UserRole =0,
                        UserPic = userInfo.UserPic,
                        Email = userInfo.Email
                    });
                    ef.SaveChanges();
                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.ToString());
            }
        }



        public static void UpDataTo_db(string id, BOLUserInfo userInfo)
        {
            try
            {
                if (userInfo.UserRole != 0)
                {
                    ValidateUserInput.CheckRole(userInfo.UserRole);
                }
                ValidateUserInput.IsThisUserexists(id);

                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserIdNumber == id);
                    
                        dbUser.FullUserName = userInfo.FullUserName;
                        dbUser.UserIdNumber = userInfo.UserIdNumber;
                        dbUser.UserName = userInfo.UserName;
                        dbUser.Password = userInfo.Password;
                        dbUser.BirthDay = userInfo.BirthDay;
                        dbUser.Sex = userInfo.Sex;
                        dbUser.UserRole = userInfo.UserRole;
                        dbUser.UserPic = userInfo.UserPic;
                        dbUser.Email = userInfo.Email;

                        ef.SaveChanges();
                   
                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.ToString());
            }
        }


        public static void deleteFrom_db(string id)
        {
            try
            {
                ValidateUserInput.IsThisUserexists(id);

                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserIdNumber == id);

                    ef.UserTables.Remove(ef.UserTables.FirstOrDefault(u => u.UserIdNumber == id));
                        ef.SaveChanges();
                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.ToString());
            }
        }

        public static int GetUserid(string userName)
        {
            try
            {      
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserName == userName);

                    if (dbUser != null)
                    {
                        return dbUser.UserID;
                    }
                    else
                    {
                        throw new InvalidOperationException($"this user is not exist please change  the values and try again");
                    }
                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.ToString());
            }
        }


        public static string GetUserIdNumber(string UserName)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserName == UserName);

                    if (dbUser != null)
                    {
                        return dbUser.UserIdNumber;
                    }
                    else
                    {
                        throw new InvalidOperationException($"this user is not exist please change  the values and try again");
                    }
                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.ToString());
            }
        }
        public static string GetUserNume(string userid)
        {
            try
            {
              //  BOLUserInfo a = new BOLUserInfo();
              //  a.UserIdNumber = userid;
              //  userid = a.UserIdNumber;

                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserIdNumber == userid);

                    if (dbUser != null)
                    {
                        return dbUser.UserName;
                    }
                    else
                    {
                        throw new InvalidOperationException($"this user is not exist please change  the values and try again");
                    }
                }
            }
            catch (Exception EX)
            {
               throw new Exception(EX.ToString());
            }
        }
    }

}


