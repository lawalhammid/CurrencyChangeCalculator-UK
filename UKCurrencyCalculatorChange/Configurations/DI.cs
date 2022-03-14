using BusinessLogic.Contracts;
using BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace UKCurrencyCalculatorChange.Configurations
{
    /// <summary>
    /// This file is for DI registration
    /// </summary>
    public static class DI
    {
        public static ServiceProvider RegisterDI()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                
                .AddSingleton<IProductList, ProductListService>()
                .AddSingleton<IChangeXchangeDenomService, ChangeXchangeDenomService>()
                .AddSingleton<IChangeXchangeNomService, ChangeXchangeNomService>()
                .AddSingleton<ICurrencyCoinHighWeight, CurrencyCoinHighWeightService>()
                .AddSingleton<ICurrencyCoin, CurrencyCoinService>()
                .AddSingleton<IDenomination, DenominationService>()
  
              .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
