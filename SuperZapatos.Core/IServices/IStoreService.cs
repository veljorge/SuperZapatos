
namespace SuperZapatos.Core.IServices
{
    using Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IStoreService
    {
        IEnumerable<Stores> GetAll();

        Task<IEnumerable<Stores>> GetAllAsync();

        void Add(Stores entity);

        void Delete(long id);

        void Delete(Stores entity);

        Stores FindById(long id);
    }
}
