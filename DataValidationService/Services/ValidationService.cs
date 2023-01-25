using DataValidationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidationService.Services
{
    public class ValidationService : IValidationService
    {
        public ValidationService() { }

        bool IValidationService.ValidateMarketDataFx(IMarketDataFx marketDataFx, out string errorDescription)
        {
            //throw new NotImplementedException();
            errorDescription = string.Empty;
            return true;
        }


        /**
         * Tests
         * currencyPair (length = 6), can recognise currency from list known
         * fxRate (rate > 0)
         * volume (size > 0)
         */
    }
}
