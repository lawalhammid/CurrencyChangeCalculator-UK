using BusinessLogic.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CurrencyCoinHighWeightService : ICurrencyCoinHighWeight
    {
        public async Task<IEnumerable<CurrencyCoinsHighWeight>> AllCurrencyCoinsHighWeight()
        {
            List<CurrencyCoinsHighWeight> products = new List<CurrencyCoinsHighWeight>();
      
            products.Add(new CurrencyCoinsHighWeight { Id = 1, CoinName = "£1", Amount = 1, HasHighWeight = true });
            products.Add(new CurrencyCoinsHighWeight { Id = 2, CoinName = "£2", Amount = 2, HasHighWeight = true });

            return products;
        }       
    }
}
