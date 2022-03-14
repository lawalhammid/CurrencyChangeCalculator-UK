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
    public class ChangeXchangeDenomService : IChangeXchangeDenomService
    {
        private readonly IDenomination _IDenomination;
        private readonly ICurrencyCoinHighWeight _ICurrencyCoinHighWeight;
        private const string NumberOfDemOrCoin = "x";
       
        public ChangeXchangeDenomService(IDenomination IDenomination, ICurrencyCoinHighWeight ICurrencyCoinHighWeight)
        {
            _IDenomination = IDenomination;
            _ICurrencyCoinHighWeight = ICurrencyCoinHighWeight;
        }
        public async Task<List<ReturnedChange>> ReturnXChangeForDenominator(decimal DenominatorAmount)
        {
            var queue = new List<ReturnedChange>();

            var loadDeno = await _IDenomination.AllCurrencyDenomination();
            var loadCoinsHightWeight = await _ICurrencyCoinHighWeight.AllCurrencyCoinsHighWeight();

            List<CountNoOfItems> countNoOfItems = new List<CountNoOfItems>();

            loadDeno = loadDeno.ToList();
            loadCoinsHightWeight = loadCoinsHightWeight.ToList();
            foreach (var b in loadDeno)
            {
                decimal getNearestMin = 0;

                //loop for the one that is close to amount passed not greater than that number
                foreach(var b1 in loadDeno)
                {
                    if(DenominatorAmount > b1.Amount || DenominatorAmount == b.Amount)
                    {
                        getNearestMin = b1.Amount;
                    }
                }

                var nearestAmountVal = loadDeno.Where(c => c.Amount == getNearestMin).FirstOrDefault();

                if (nearestAmountVal != null)
                {
                        countNoOfItems.Add(new CountNoOfItems
                        {
                            CurrencyName = nearestAmountVal.DenominationName
                        });

                        var getHowManyHighCoinOccured = countNoOfItems.Where(c => c.CurrencyName == nearestAmountVal.DenominationName).Count();

                        string appendToQueue = $"{ getHowManyHighCoinOccured } {NumberOfDemOrCoin} {nearestAmountVal.DenominationName}";

                        //Condition to remove from Queue if already exist
                        int count = getHowManyHighCoinOccured - 1;
                        string checkappendToQueue = $"{ count } {NumberOfDemOrCoin} {nearestAmountVal.DenominationName}";
                        var getExistAndRemove = queue.Where(c => c.Decription == checkappendToQueue).FirstOrDefault();

                        if (getExistAndRemove != null)
                        {
                            queue = queue.Where(c => c.Decription != checkappendToQueue).ToList();

                        }
                        queue.Add(new ReturnedChange { Decription = appendToQueue });


                        decimal deduct = DenominatorAmount - nearestAmountVal.Amount;

                        DenominatorAmount = deduct;
                }

                else //get from Coin where weight is high
                {                    
                    var getNearestRealValfromCoinsList = loadCoinsHightWeight.Where(c=> c.HasHighWeight == true).OrderBy(x => Math.Abs((decimal)x.Amount - DenominatorAmount)).First();

                    if (getNearestRealValfromCoinsList != null && DenominatorAmount != 0)
                    {
                        countNoOfItems.Add(new CountNoOfItems
                        {
                            CurrencyName = getNearestRealValfromCoinsList.CoinName
                        });

                        var getHowManyHighCoinOccured = countNoOfItems.Where(c => c.CurrencyName == getNearestRealValfromCoinsList.CoinName).Count();

                        string appendToQueue = $"{ getHowManyHighCoinOccured } {NumberOfDemOrCoin} {getNearestRealValfromCoinsList.CoinName}";

                       
                        int count = getHowManyHighCoinOccured - 1;
                       
                        string checkappendToQueue = $"{ count } {NumberOfDemOrCoin} {getNearestRealValfromCoinsList.CoinName}";
                        //Condition to remove from Queue if above i.e checkappendToQueue already exist in queue
                        queue = queue.Where(c => c.Decription == checkappendToQueue).FirstOrDefault() != null ? queue.Where(c => c.Decription != checkappendToQueue).ToList() : queue;
                        
                        queue.Add(new ReturnedChange { Decription = appendToQueue });


                        decimal deduct = DenominatorAmount - getNearestRealValfromCoinsList.Amount;

                        DenominatorAmount = deduct;
                    } 
                }
            }

            return queue;
        }
    }
}