using BusinessLogic.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductListService : IProductList
    {
        /*
         I used async here in order to use await
         whenever I change it to fetch data from database 
        */
        public async  Task<IEnumerable<Products>> GetProduct()
        {
            List<Products> products = new List<Products>();
            products.Add(new Products { Id = 1, ProductName = "Milk", Amount = 5.5M });
            products.Add(new Products { Id = 2, ProductName = "Beed", Amount = 4.5M });

            return products;
        }
    }
}