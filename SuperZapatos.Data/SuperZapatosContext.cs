

namespace SuperZapatos.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Configurations;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using Domain;

    public class SuperZapatosContext : DbContext , IUnitOfWork
    {
        #region Constants
        private const string schema = "dbo";
        private const string connectionStringName = "name=SuperZapatosConnection";
        #endregion

        #region Constructor
        public SuperZapatosContext() : base(connectionStringName)
        {
            Database.SetInitializer<SuperZapatosContext>(null);
            Database.Initialize(false);

            var x = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }
        #endregion

        #region Overrides
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.HasDefaultSchema(schema);
            modelBuilder.Configurations.Add(new StoreConfiguration());
            modelBuilder.Configurations.Add(new ArticleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region IQueryableUnitOfWork Members



        public DbSet<TEntity> GetSet<TEntity>() where TEntity: Entity
        {
            DbSet<TEntity> result = null;
            try
            {
                result = Set<TEntity>();
            }
            catch 
            {
                throw;
            }
            return result;
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch 
            {
                throw;
            }
            
        }

        public async Task CommitAsync()
        {
            try
            {
                await SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }
            catch (Exception)
            {
                throw;
            }
        }

       

        #endregion

    }
}
