using Nito.AsyncEx;
using System;

/// <summary>
/// The code struture explained below
///---- Model  project is where i defined all the entities 
///---- Business project logic is where I defined my contracts(interfaces) and services(Implementations)
/// I have two classes for coins. CurrencyCoins(i.e for penny) and CurrencyCoinsHighWeight(for pounds. i.e they are coins too but they have heigher weights or values)
/// IChangeXchangeDenomService interface returns Denomination change and higher coins(i.e 1 and 2 pounds)
/// IChangeXchangeNomService interface returns Coins(i.e only penny change)
/// The view model is the class i used to display changes to console enviromnent
/// CountNoOfItems class in Helpers folder was used to track/control the number of currency to be added to ReturnedChange class. Once a particular change is found twice or more than once in CountNoOfItems it increases the number of currency to display  
///---- UKCurrencyCalculatorChange Project is the main project. i.e Where Business logic was referenced
///---- UKCurrencyCalculatorChangeTest project is the test project where the project requirements was tested
/// </summary>

namespace UKCurrencyCalculatorChange
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AsyncContext.Run(() => MainProgram.MainAsync(args));
        }
    }
}
