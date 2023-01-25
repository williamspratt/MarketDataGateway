using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidationService.Model.Dao
{
    internal interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        T Create(T data);
    }
}
