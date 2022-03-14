using BusinessLogic.Helpers;
using BusinessLogic.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UKCurrencyCalculatorChange.Configurations;
using UKCurrencyCalculatorChange.HelperClasses;

namespace UKCurrencyCalculatorChange
{
    public class MainProgram
    {
        public static async void MainAsync(string[] args)
        {
            //setup our DI
            var serviceProvider = DI.RegisterDI();

            //configure console logging
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

            logger.LogInformation($"Application starts at { DateTime.Now }");

            //load products

            var loadProduct = serviceProvider.GetService<IProductList>();
            var load = await loadProduct.GetProduct();

            Console.WriteLine("Id  ProductName   Amount(£) ");
            foreach (var b in load)
            {
                Console.WriteLine($"{b.Id}   {b.ProductName}          {AmountConverter.FormattedAmount(b.Amount)}");
            }

            Console.WriteLine("Start a transaction by entering the product Id and press enter:  ");

            int IdUserEntered;
            if (int.TryParse(Console.ReadLine(), out IdUserEntered))
            {
                var getProductExist = await loadProduct.GetProduct();
                var getExist = getProductExist.ToList().Where(c => c.Id == IdUserEntered).SingleOrDefault();

                if (getExist != null)
                {
                    Console.WriteLine($"You selected {getExist.ProductName} product that cost £{AmountConverter.FormattedAmount(getExist.Amount)}");

                      Console.WriteLine($"Enter the amount the customer pay:  ");
                      decimal UserEnteredAmountPaid;
                    if (decimal.TryParse(Console.ReadLine(), out UserEnteredAmountPaid))
                    {
                        decimal calRemainChange = UserEnteredAmountPaid - getExist.Amount;

                        Console.WriteLine("Wait transaction in progress...");
                        //Print User change below
                        if (calRemainChange > 0)
                        {
                            //Split change to know the Denominator and Coins part
                            string[] splitDenomAndCoin = AmountApproximation.ConvertTodecimal(calRemainChange).Split('.');

                            decimal DenomChange = FieldsValidation.ValDecimal(splitDenomAndCoin[0]);
                            decimal CoinChange = FieldsValidation.ValDecimal(splitDenomAndCoin[1]);

                            //Return the change based on the UK Denominations
                            var changeDenom = serviceProvider.GetService<IChangeXchangeDenomService>();

                            var returnDemChange = await changeDenom.ReturnXChangeForDenominator(DenomChange);

                            

                            Console.WriteLine("Your change is: ");
                            
                            foreach (var obj in returnDemChange)
                            {
                                Console.WriteLine($"{obj.Decription}");
                            }
                            var changeCoin = serviceProvider.GetService<IChangeXchangeNomService>();

                            var returnNomChange = await changeCoin.ReturnXChangeForCoin(CoinChange);

                            foreach (var obj in returnNomChange)
                            {
                                Console.WriteLine($"{obj.Decription}");
                            }
                            Console.Read();
                        }

                        Console.WriteLine("Your transaction was successful with no change!");
                    }
                 }
                else
                {
                    Console.WriteLine("Product not found, enter a valid product number/Id");
                    Console.Read();
                }
            }
            else
            {
                Console.WriteLine("Pease enter a valid number!");
                Console.Read();
            }
        }
    }
}