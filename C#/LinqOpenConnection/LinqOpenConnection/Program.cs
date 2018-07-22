using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOpenConnection
{
   
    class Program
    {
        
        static void Main(string[] args)
        {
           
            try
            {
                // SqlConnection open = new SqlConnection();

                CustomerData a = new CustomerData();
                a.s();




            }
            catch (Exception e)
            {
                Console.WriteLine($"Can not open connection! \n{ e}");;
            }
        }
    }
    class CustomerData : DataSet2
    {


        CustomersDataTable db = new CustomersDataTable();
        public  void s() {
             Console.WriteLine(db.);

        }
    }


}
