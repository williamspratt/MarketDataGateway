using DataValidationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidationService.Services
{
    public interface IValidationService
    {
        bool ValidateMarketDataFx(IMarketDataFx marketDataFx, out string errorDescription);
    }
}
