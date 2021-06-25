using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse
{
    public static class StringExtensions
    {
        public static DateTime StringToDate(this string str)
        {
            string[] arrDate = str.Split("/");

            DateTime.TryParse($"{arrDate[1]}/{arrDate[0]}/{arrDate[2]}", out DateTime dtPay);
            return dtPay;
        }
    }
}
