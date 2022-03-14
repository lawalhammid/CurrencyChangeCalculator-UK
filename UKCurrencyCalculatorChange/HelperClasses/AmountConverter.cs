using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UKCurrencyCalculatorChange.HelperClasses
{
    internal static class AmountConverter
    {
        public static string FormattedAmount(decimal amount)
        {
            return amount.ToString("N2", CultureInfo.InvariantCulture);
        }       
    }
}
