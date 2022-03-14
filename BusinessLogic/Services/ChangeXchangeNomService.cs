using BusinessLogic.Helpers;
using BusinessLogic.Contracts;
using BusinessLogic.ViewModel;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ChangeXchangeNomService : IChangeXchangeNomService
    {
        private readonly ICurrencyCoin _ICurrencyCoin;
        private const string NumberOfDemOrCoin = "x";
        public ChangeXchangeNomService(ICurrencyCoin ICurrencyCoin)
        {
            _ICurrencyCoin = ICurrencyCoin;
        }

        public async Task<List<ReturnedChange>> ReturnXChangeForCoin(decimal DenominatorAmount)
        {
            var queue = new List<ReturnedChange>();

            var loadCoins = await _ICurrencyCoin.AllCurrencyCoins();

            List<CountNoOfItems> countNoOfItems = new List<CountNoOfItems>();

            loadCoins = loadCoins.ToList();

            foreach (var b in loadCoins)
            {
                decimal getNearestMin = 0;

                //loop for the one that is close to amount passed not greater than that number
                foreach (var b1 in loadCoins)
                {
                    if (DenominatorAmount > b1.Amount || DenominatorAmount == b1.Amount)
                    {
                        getNearestMin = b1.Amount;
                    }
                }

                var nearestAmountVal = loadCoins.Where(c => c.Amount == getNearestMin).FirstOrDefault();

                if (nearestAmountVal != null)
                {
                    countNoOfItems.Add(new CountNoOfItems
                    {
                        CurrencyName = nearestAmountVal.CoinName
                    });

                    var getHowManyHighCoinOccured = countNoOfItems.Where(c => c.CurrencyName == nearestAmountVal.CoinName).Count();

                    string appendToQueue = $"{ getHowManyHighCoinOccured } {NumberOfDemOrCoin} {nearestAmountVal.CoinName}";

                   
                    int count = getHowManyHighCoinOccured - 1;
                    string checkappendToQueue = $"{ count } {NumberOfDemOrCoin} {nearestAmountVal.CoinName}";
                    //Condition to remove from Queue if above i.e checkappendToQueue already exist in queue
                    queue = queue.Where(c => c.Decription == checkappendToQueue).FirstOrDefault() != null ? queue.Where(c => c.Decription != checkappendToQueue).ToList() : queue;

                    queue.Add(new ReturnedChange { Decription = appendToQueue });


                    decimal deduct = DenominatorAmount - nearestAmountVal.Amount;

                    DenominatorAmount = deduct;
                } 
            }

            return queue;
        }
    }
}