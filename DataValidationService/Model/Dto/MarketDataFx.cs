using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidationService.Model.Dto
{
    // public record MarketDataFx(int id, DateTime timeStamp, bool isBid, string currencyPair, decimal fxRate, double volume) : IMarketDataFx;

    public class MarketDataFx : IMarketDataFx
    {

        public int id { get ; set ; }
        public DateTime timeStamp { get; set; }
        public bool isBid { get; init; }
        public string currencyPair { get; init; }
        public decimal fxRate { get; init; }
        public double volume { get; init; }


        public MarketDataFx(bool isBid, string currencyPair, decimal fxRate, double volume)
        {
            this.isBid = isBid;
            this.currencyPair = currencyPair;
            this.fxRate = fxRate;
            this.volume = volume;
        }

    }
}
