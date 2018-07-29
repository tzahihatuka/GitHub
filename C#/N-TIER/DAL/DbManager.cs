using BOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class DbManager
    {
        public static List<product> connection(List<product> products)
        {
            string connectionString= @"Data Source=DESKTOP-5ONLK3G\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
            try
            {
                using (SqlConnection sql =new SqlConnection(connectionString)) {

                    sql.Open();

                    SqlCommand sendComment = new SqlCommand("SELECT * FROM [dbo].Products AS P JOIN [dbo].Categories AS C ON C.CategoryID=P.CategoryID", sql);

                    SqlDataReader reader = sendComment.ExecuteReader();
               
                    products=new List<product>();
                    while (reader.Read())
                    {
                        products.Add(new product
                        {

                            ProductID = ((int)reader[0]),
                            ProductName = (string)reader[1],
                            SupplierID = (Nullable<int>)Convert.ToInt16(reader[2]),
                            CategoryID = (Nullable<int>)Convert.ToInt16(reader[3]),
                            QuantityPerUnit = (string)reader[4],
                            UnitPrice = (Nullable<decimal>)Convert.ToInt16(reader[5]),
                            UnitsInStock = (Nullable<int>)Convert.ToInt16(reader[6]),
                            UnitsOnOrder = (Nullable<int>)Convert.ToInt16(reader[7]),
                            ReorderLevel = (Nullable<int>)Convert.ToInt16(reader[8]),
                            Discontinued = (Nullable<bool>)Convert.ToBoolean(reader[9]),
                            CategoryName = (string)reader[11],
                        });
                    }
                    return products;
                   
                }
            }
            catch(Exception a)
            {
                Console.WriteLine(a.Message);
                return products;
            }
        }

       
    }
}
