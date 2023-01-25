using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidationService.Model.Dto
{
    public record MarketDataFx(string uniqueId, DateTime timeStamp, bool isBid, string currencyPair, decimal fxRate, double volume) : IMarketDataFx;

}
