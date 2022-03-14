using System;
using System.Collections.Generic;
using System.Text;

namespace UKCurrencyCalculatorChange.DTO
{
    public class ReturnedChange
    {
        public string DenominationOrCoin { get; set; }
        public decimal? Change { get; set; }    
    }
}
