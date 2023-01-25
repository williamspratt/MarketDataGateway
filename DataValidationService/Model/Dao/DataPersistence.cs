﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidationService.Model.Dao
{
    internal class DataPersistence : IRepository<IMarketDataFx>
    {
        List<IMarketDataFx> _data;
        
        public DataPersistence()
        {
            this._data = new List<IMarketDataFx>();
        }

        IMarketDataFx IRepository<IMarketDataFx>.Create(IMarketDataFx data)
        {
            _data.Add(data);
            return data;
        }

        IEnumerable<IMarketDataFx> IRepository<IMarketDataFx>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IMarketDataFx> IRepository<IMarketDataFx>.GetAll()
        {
            return _data;
        }
    }
}