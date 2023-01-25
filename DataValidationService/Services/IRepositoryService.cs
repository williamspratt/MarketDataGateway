using DataValidationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidationService.Services
{
    public interface IRepositoryService<T>
    {
        IEnumerable<T> GetAllMarketData();
        T? GetMarketData(int id);
        T? CreateMarketData(T data, out string errorDescription);
    }
}
