using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class product
    {
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<int> UnitsInStock { get; set; }
        public Nullable<int> UnitsOnOrder { get; set; }
        public Nullable<int> ReorderLevel { get; set; }
        public Nullable<bool> Discontinued { get; set; }
        public string CategoryName { get; set; }

    }
}
