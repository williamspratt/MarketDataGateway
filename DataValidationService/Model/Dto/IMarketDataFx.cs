using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidationService.Model
{
    public interface IMarketDataFx
    {
        // will be system generated
        int id { get; set; }
        DateTime timeStamp { get; set; }
        // will be entered
        bool isBid { get; init; }
        string currencyPair { get; init; } // char array 6 would be faster but more hassle
        decimal fxRate { get; init; }
        double volume { get; init; }
    }
}
