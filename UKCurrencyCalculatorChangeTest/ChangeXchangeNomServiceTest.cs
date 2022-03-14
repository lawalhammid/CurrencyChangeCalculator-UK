using NUnit.Framework;
using BusinessLogic.Helpers;
using BusinessLogic.Services;
using BusinessLogic.ViewModel;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BusinessLogic.Contracts;

namespace UKCurrencyCalculatorChangeTest
{
    public class ChangeXchangeNomServiceTest
    {
        private  Mock<ICurrencyCoin> _iICurrencyCoin;
        private  ChangeXchangeNomService _changeXchangeNomService;

        [SetUp]
        public void Setup() {

            _iICurrencyCoin = new Mock<ICurrencyCoin>();

            _iICurrencyCoin.Setup(x => x.AllCurrencyCoins())
                .Returns(TestAllCurrencyCoins());

            _changeXchangeNomService = new ChangeXchangeNomService(_iICurrencyCoin.Object);
        }

        [Test]
        public void TestReturnXChangeForCoin()
        {
            var retX = _changeXchangeNomService.ReturnXChangeForCoin(50).Result;

            Assert.IsNotNull(retX);

            Assert.IsTrue(retX.Count > 0 && retX.Count == 1);

            Assert.AreEqual("1 x 50p", retX[0].Decription);
            
        }
        public async Task<IEnumerable<CurrencyCoins>> TestAllCurrencyCoins()
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