namespace SuperZapatos.Core.Services
{
    using Domain;
    using Domain.Repositories;
    using Dtos;
    using IServices;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class StoreService : IStoreService
    {
        #region Private Members
        private readonly IStoreRepository repository;
        #endregion

        #region Construction
        public StoreService(IStoreRepository storeRepository)
        {
            repository = storeRepository;
        }

      
        #endregion

        #region IService Members

        public IEnumerable<Stores> GetAll()
        {
            return  repository.GetAll().Select(x=> AutoMapper.Mapper.Map<Stores>(x)) ;
        }

        public async Task<IEnumerable<Stores>> GetAllAsync()
        {
            return from store in await repository.GetAllAsync() select AutoMapper.Mapper.Map<Stores>(store);
        }


        public void Add(Stores entity)
        {
            repository.Add(AutoMapper.Mapper.Map<Store>(entity));
        }

        public void Delete(long Id)
        {
            repository.Delete(Id);
        }

        public void Delete(Stores entity)
        {
            repository.Delete(AutoMapper.Mapper.Map<Store>(entity));
        }

        public Stores FindById(long id)
        {
            return AutoMapper.Mapper.Map<Stores>( repository.FindById(id));
        }
        #endregion






    }
}
