using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Helpers
{
    public static class FieldsValidation
    {
        public static string FormattedAmount(decimal amount)
        {
            return amount.ToString("N2", CultureInfo.InvariantCulture);
        }
        public static string FormatToDateYearMonthDay(string Param)
        {
            DateTime decChck = DateTime.Now;
            try
            {
                string con = string.Empty;
                DateTime val = Param == null ? decChck : DateTime.TryParse(Param, out decChck) ? decChck : decChck;
                if (val != null)
                {

                    con = string.Format("{0: yyyy-MM-dd}", val);
                }

                return con;
            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
                return string.Empty;
            }
        }
        public static string FormatTransDate(DateTime? dt)
        {
            if (dt != null)
            {
                return string.Format("{0:dd-MMM-yyyy}", dt);
            }
            return null;
        }

        public static string FormatTransDateWithTime(DateTime? dt)
        {
            if (dt != null)
            {
                return string.Format("{0:dd-MMM-yyyy HH:mm:ss tt}", dt);
            }
            return dt.ToString();
        }
        public static string RemoveLast(string txt)
        {
            if (!string.IsNullOrWhiteSpace(txt))
            {
                var getLast = txt.Substring(txt.Length - 1);
                if (getLast != null)
                {
                    if (getLast == ",")
                    {
                        var rem = txt.Substring(0, txt.Length - 1);
                        return rem;
                    }
                }
            }


            return txt;
        }

        public static int ValIntergers(string Param)
        {
            try
            {
                int intChck = 0;
                int val = Param == null ? 0 : int.TryParse(Param, out intChck) ? intChck : intChck;

                return val;
            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
                return 0;
            }
        }
        public static int ValShort(string Param)
        {
            try
            {
                // short intChck = 0;
                short val = Convert.ToInt16(Param);// == null ? 0 : short.TryParse(Param, out intChck) ? intChck : intChck;

                return val;
            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
                return 0;
            }
        }

        public static bool ValBool(string Param)
        {
            try
            {
                bool intChck = false;
                bool val = Param == null ? false : bool.TryParse(Param, out intChck) ? intChck : intChck;

                return val;
            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
                return false;
            }
        }

        public static decimal ValDecimal(string Param)
        {
            try
            {
                decimal decChck = 0;
                decimal val = Param == null ? 0 : decimal.TryParse(Param, out decChck) ? decChck : decChck;

                return val;
            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
                return 0;
            }
        }

        public static long ValLong(string Param)
        {
            try
            {
                long decChck = 0;
                long val = Param == null ? 0 : long.TryParse(Param, out decChck) ? decChck : decChck;

                return val;
            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
                return 0;
            }
        }

        public static DateTime ValidateDate(string Param)
        {
            DateTime decChck = DateTime.Now;
            try
            {

                DateTime val = Param == null ? decChck : DateTime.TryParse(Param, out decChck) ? decChck : decChck;

                return val;
            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
                return decChck;
            }
        }

        public static string ValidateDateReturnString(string Param)
        {
            DateTime decChck = DateTime.Now;
            try
            {

                DateTime val = Param == null ? decChck : DateTime.TryParse(Param, out decChck) ? decChck : decChck;
                return string.Format("{0:yyyyMMdd}", val);

            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
                return null;
            }
        }



        public static DateTime? ValidateDateReturnNull(string Param)
        {

            try
            {
                DateTime val = Convert.ToDateTime(Param);
                return val;
            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
                return null;
            }
        }

        public static string ReturnNull(string valValue)
        {
            if (string.IsNullOrWhiteSpace(valValue))
            {
                return null;
            }

            return valValue;
        }

        public static string ReturnValidActtno(string acctno, string BranchCode)
        {
            if (!string.IsNullOrWhiteSpace(acctno))
            {
                if (acctno.Contains("***"))
                {
                    string act = acctno.Replace("***", BranchCode);
                    acctno = act;
                    return acctno;
                }

            }

            return acctno;
        }

        public static string GetfirstValue(string value)
        {
            if (value != null)
            {
                return value.Substring(0, 1);
            }
            else
            {
                return value;
            }
        }

        public static string FormatDateCurrProcessing(DateTime? dt)
        {
            if (dt != null)
            {
                return string.Format("{0:yyyy-MM-dd }", dt);
            }
            return null;
        }


        public static string AddComma(string value)
        {
            string val = string.Empty;
            val += value + ",";
            value = val;

            return value;
        }


        public static string SubstringReturn(string text, int lenghtToCheck, int totalToTake)
        {
            try
            {
                if (text.Length > lenghtToCheck)
                {

                    return text.Substring(lenghtToCheck, totalToTake);
                }

                return text;
            }
            catch (Exception ex)
            {
                return text;
            }

        }
    }


}
