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
        
        public int id { get { return _id; } set { this._id = value; } }
        private int _id;
        public DateTime timeStamp { get { return _timestamp; } set { this._timestamp = value; } }
        private DateTime _timestamp;
        public bool isBid { get; init; }
        public string currencyPair { get; init; }
        public decimal fxRate { get; init; }
        public double volume { get; init; }

        public MarketDataFx()
        {

        }
        public MarketDataFx(bool isBid, string currencyPair, decimal fxRate, double volume)
        {
            this.id = GetUniqueId();
            this.timeStamp = DateTime.Now;
            this.isBid = isBid;
            this.currencyPair = currencyPair;
            this.fxRate = fxRate;
            this.volume = volume;
        }

        private static int GetUniqueId()
        {
            Random rnd = new Random();
            int copy = rnd.Next(1000, 9999);
            return copy; // random nums which are 4 digits long
        }
    }
}
