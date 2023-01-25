using DataValidationService.Model;
using DataValidationService.Model.Dao;
using DataValidationService.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataValidationService.Services
{
    public class RepositoryService : IRepositoryService<IMarketDataFx>
    {
        private IRepository<IMarketDataFx> _repository;
        private IValidationService _validationService;

        public RepositoryService()
        {
            this._repository = new DataPersistence();
            this._validationService = new ValidationService();
        }

        IMarketDataFx? IRepositoryService<IMarketDataFx>.CreateMarketData(IMarketDataFx data, out string errorDescription)
        {
            // validate first
            if (this._validationService.ValidateMarketDataFx(data, out errorDescription))
            {
                
                this._repository.Create(data);
                return data;
            }
            else
            {
                return default(MarketDataFx);
            }
        }

        IEnumerable<IMarketDataFx> IRepositoryService<IMarketDataFx>.GetAllMarketData()
        {
            return this._repository.GetAll();
        }

        IMarketDataFx? IRepositoryService<IMarketDataFx>.GetMarketData(int id)
        {
            return this._repository.Get(id);
        }

        
    }
}
