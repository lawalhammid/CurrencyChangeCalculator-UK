using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UKCurrencyCalculatorChange.HelperClasses
{
    internal static class AmountApproximation
    {
        public static string ConvertTodecimal(decimal Param)
        {
            try
            {
                return string.Format("{0:0.00}", Param);

                
            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
                return "0.00";
            }
        }

    }
}
