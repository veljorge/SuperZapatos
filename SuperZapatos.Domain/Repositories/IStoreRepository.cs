using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.Domain.Repositories
{
    public interface IStoreRepository : IRepository<long,Store>
    {
        Task<IEnumerable<Store>> GetAllAsync();
    }
}
