using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.DataAccess.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        ICollection<T> FindAll();
        T FindById(string id);
        bool Delete(string item);
        bool Add(T item);
        bool Update(T item);
        bool Save();
        bool IsExists(string id);

    }
}
