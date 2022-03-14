using BusinessLogic.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class DenominationService : IDenomination
    {
        /*
        I used async here in order to use await
        whenever I change it to fetch data from database 
       */
        public async Task<IEnumerable<CurrencyDenomination>> AllCurrencyDenomination()
        {
            List <CurrencyDenomination> products = new List<CurrencyDenomination>();
            products.Add(new CurrencyDenomination { Id = 1, DenominationName  = "£5", Amount = 5 });
            products.Add(new CurrencyDenomination { Id = 2, DenominationName = "£10", Amount = 10 });
            products.Add(new CurrencyDenomination { Id = 3, DenominationName = "£20", Amount = 20 });
            products.Add(new CurrencyDenomination { Id = 4, DenominationName = "£50", Amount = 50 });

            return products;
        }
    }
}