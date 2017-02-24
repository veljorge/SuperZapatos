

namespace SuperZapatos.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain;
    public interface IRepository<TId, TEntity> : IDisposable 
        where TId : struct
        where TEntity : Entity
    {

        //
        // Summary:
        //     Adds the entity but not commits the transaction.
        //
        // Parameters:
        //   entity:
        //     The entity to add.
        void Add(TEntity entity);
        //
        // Summary:
        //     Removes the entity with the specified ID from the storage without commiting.
        //
        // Parameters:
        //   id:
        //     The ID of the entity to remove.
        void Delete(TId id);
        //
        // Summary:
        //     Removes the entity from the storage without commiting.
        //
        // Parameters:
        //   entity:
        //     The entity to remove.
        void Delete(TEntity entity);
        //
        // Summary:
        //     Returns an entity using its ID.
        //
        // Parameters:
        //   id:
        //     The ID of the entity to find.
        //
        // Returns:
        //     An entity.
        TEntity FindById(TId id);
        //
        // Summary:
        //     Asynchronously returns an entity using its ID.
        //
        // Parameters:
        //   id:
        //     The ID of the entity to find.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     entity.
        Task<TEntity> FindByIdAsync(TId id);
        //
        // Summary:
        //     Returns all the entities from the underlying storage.
        //
        // Returns:
        //     A collection containing all the entities.
        IEnumerable<TEntity> GetAll();

    }
}
