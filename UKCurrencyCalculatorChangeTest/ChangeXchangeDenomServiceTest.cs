using NUnit.Framework;
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
using Moq;
using BusinessLogic.Services;

namespace UKCurrencyCalculatorChangeTest
{
    public class ChangeXchangeDenomServiceTest
    {
        private  Mock<IDenomination> _iDenomination;
        private  Mock<ICurrencyCoinHighWeight> _iCurrencyCoinHighWeight;
        private  ChangeXchangeDenomService _changeXchangeDenomService;

        [SetUp]
        public void Setup()
        {
            _iDenomination = new Mock<IDenomination>();
            _iDenomination.Setup(x => x.AllCurrencyDenomination())
                .Returns(TestCurrencyDenomination());

            _iCurrencyCoinHighWeight = new Mock<ICurrencyCoinHighWeight>();
            _iCurrencyCoinHighWeight.Setup(x => x.AllCurrencyCoinsHighWeight())
                .Returns(TestAllCurrencyCoinsHighWeight());

            _changeXchangeDenomService = new ChangeXchangeDenomService(_iDenomination.Object, _iCurrencyCoinHighWeight.Object);
        }

        [Test]
        public void TestReturnXChangeForDenominator()
        {
            var retX = _changeXchangeDenomService.ReturnXChangeForDenominator(14).Result;

            Assert.IsNotNull(retX);

            Assert.IsTrue(retX.Count > 0 && retX.Count == 2);

            Assert.AreEqual("1 x £10", retX[0].Decription);
            Assert.AreEqual("2 x £2", retX[1].Decription);
            
        }

        public async Task<IEnumerable<CurrencyDenomination>> TestCurrencyDenomination()
        {
            List<CurrencyDenomination> products = new List<CurrencyDenomination>();
            products.Add(new CurrencyDenomination { Id = 1, DenominationName = "£5", Amount = 5 });
            products.Add(new CurrencyDenomination { Id = 2, DenominationName = "£10", Amount = 10 });
            products.Add(new CurrencyDenomination { Id = 3, DenominationName = "£20", Amount = 20 });
            products.Add(new CurrencyDenomination { Id = 4, DenominationName = "£50", Amount = 50 });

            return products;
        }

        public async Task<IEnumerable<CurrencyCoinsHighWeight>> TestAllCurrencyCoinsHighWeight()
        {
            List<CurrencyCoinsHighWeight> products = new List<CurrencyCoinsHighWeight>();

            products.Add(new CurrencyCoinsHighWeight { Id = 1, CoinName = "£1", Amount = 1, HasHighWeight = true });
            products.Add(new CurrencyCoinsHighWeight { Id = 2, CoinName = "£2", Amount = 2, HasHighWeight = true });

            return products;
        }
    
    
    }
}