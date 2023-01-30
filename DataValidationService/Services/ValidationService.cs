using DataValidationService.Config;
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

        bool IValidationService.ValidateMarketDataFx(IMarketDataFx marketDataFx, IEnumerable<IMarketDataFx> allData, out string errorDescription)
        {
            
            // null or 0 checks
            if (marketDataFx == null) {
                errorDescription = $"Null data cannot be inserted";
                return false; }
            if (marketDataFx.volume <= 0) {
                errorDescription = $"Traded volume must be non zero";
                return false; }
            if (marketDataFx.fxRate <= 0) {
                errorDescription = $"Fx must be non zero";
                return false; }

            // future date check
            if (marketDataFx.timeStamp > DateTime.Now) {
                errorDescription = $"Timestamp cannot be in future";
                return false; }
            

            // duplicated id?
            if (allData.Where(d => d.id.Equals(marketDataFx.id)).FirstOrDefault() != null) {
                errorDescription = $"Id already present '{marketDataFx.id}'";
                return false; }

            // ccy format check
            if (!IsCurrencyPairCorrect(marketDataFx.currencyPair)) { 
                errorDescription = $"Unrecognised currency pair '{marketDataFx.currencyPair}'"; 
                return false; }

            // correct
            errorDescription = string.Empty;
            return true;
        }

        private bool IsCurrencyPairCorrect(string ccy)
        {
            // length checks
            if (String.IsNullOrEmpty(ccy)) { return false; }
            if (ccy.Length != 6) { return false; }

            // recognise in list?
            if (!Currencies.IsAKnownCurrency(ccy.Substring(0, 3))) { return false; }
            if (!Currencies.IsAKnownCurrency(ccy.Substring(3, 3))) { return false; }

            // correct
            return true;
        }


    }
}
