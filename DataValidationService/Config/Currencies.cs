using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidationService.Config
{
    public class Currencies
    {


        public static IEnumerable<string> currencies = new List<string>()
        {
            "AUD",
            "CAD",
            "CHF",
            "CZK",
            "DKK",
            "EUR",
            "GBP",
            "HUF",
            "JPY",
            "NOK",
            "PLN",
            "RON",
            "RUB",
            "SEK",
            "TRY",
            "USD",
            "ZAR"
        };

        public static bool IsAKnownCurrency(string str)
        {
            return currencies.Where(c => c.Equals(str.ToUpper())).FirstOrDefault() != null;
        }
    }
}
