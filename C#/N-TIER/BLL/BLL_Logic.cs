using BOL;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public delegate void getItemHandler(string oneItem);
    public class BLL_Logic
    {

        public static event getItemHandler print;
           public static void Logic() {
            ProductList getlist = new ProductList();

          List<product> getlistproducts= DbManager.connection(getlist.products);

            var a = getlistproducts.Where(p => p.ProductName.Count() == p.CategoryName.Count());

            foreach (var item in a)
            {
                print?.Invoke($"Product Name: {item.ProductName}" );
            }
        }
}
}
