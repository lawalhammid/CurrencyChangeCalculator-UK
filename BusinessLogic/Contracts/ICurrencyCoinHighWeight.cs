using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Contracts
{
    public interface ICurrencyCoinHighWeight
    {
        Task<IEnumerable<CurrencyCoinsHighWeight>> AllCurrencyCoinsHighWeight();
    }
}