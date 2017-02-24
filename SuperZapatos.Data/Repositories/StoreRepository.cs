namespace SuperZapatos.Data.Repositories
{
    using Domain;
    using Domain.Repositories;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    public class StoreRepository : IStoreRepository
    {
        #region Private Members
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Construction
        public StoreRepository(IUnitOfWork superZapatosContext)
        {
            unitOfWork = superZapatosContext;
        }
        #endregion

        #region IRepository Members
        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            return await unitOfWork.GetSet<Store>()
                .OrderBy(e => e.Name).ToListAsync();
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public void Add(Store entity)
        {
            if (entity != null)
            {
                var store = unitOfWork.GetSet<Store>();
                store.AddOrUpdate(e => e.Id, entity);
                unitOfWork.Commit();
            }
        }

        public void Delete(Store entity)
        {
            if (entity != null)
            {
                unitOfWork.GetSet<Store>().Remove(entity);
                unitOfWork.Commit();
            }
        }

        public void Delete(long id)
        {
            var store = FindById(id);
            if (store != null)
            {
                Delete(store);
                unitOfWork.Commit();
            }
        }

        public void Dispose()
        {
            this.unitOfWork.Dispose();
        }

        public Store FindById(long id)
        {
            return this.unitOfWork.GetSet<Store>().Find(id);
        }

        public Task<Store> FindByIdAsync(long id)
        {
            return unitOfWork.GetSet<Store>().FindAsync(id);
        }

        public IEnumerable<Store> GetAll()
        {
            var stores= unitOfWork.GetSet<Store>();
            return stores.ToList();
        }
        #endregion

    }
}
