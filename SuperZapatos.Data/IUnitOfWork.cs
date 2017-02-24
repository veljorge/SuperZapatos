namespace SuperZapatos.Data
{
    using Domain;
    using System;
    using System.Data.Entity;

    public  interface IUnitOfWork : IDisposable
    {

        DbSet<TEntity> GetSet<TEntity>() where TEntity : Entity;

        void Commit();
    }
}
