using BusinessLogic.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CurrencyCoinService : ICurrencyCoin
    {
        /*
        I used async here in order to use await
        whenever I change it to fetch data from database 
       */
        public async Task<IEnumerable<CurrencyCoins>> AllCurrencyCoins()
        {
            List<CurrencyCoins> products = new List<CurrencyCoins>();
            products.Add(new CurrencyCoins { Id = 1, CoinName = "1p", Amount = 1, HasHighWeight = false });
            products.Add(new CurrencyCoins { Id = 2, CoinName = "2p", Amount = 2, HasHighWeight = false });
            products.Add(new CurrencyCoins { Id = 3, CoinName = "5p", Amount = 5 });
            products.Add(new CurrencyCoins { Id = 4, CoinName = "10p", Amount = 10 });
            products.Add(new CurrencyCoins { Id = 5, CoinName = "20p", Amount = 20 });
            products.Add(new CurrencyCoins { Id = 6, CoinName = "50p", Amount = 50 });

            return products;
        }       
    }
}
