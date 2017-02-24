
namespace SuperZapatos.Data.Repositories
{
    using Domain;
    using Domain.Repositories;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;
    using System;

    public class ArticleRepository :  IArticleRepository
    {

        #region Private Members
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Construction
        public ArticleRepository(IUnitOfWork superZapatosContext)
        {
            unitOfWork = superZapatosContext;
        }
        #endregion

        #region IRepository Members



        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await unitOfWork.GetSet<Article>()
                .OrderBy(e => e.Name).ToListAsync();
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public void Add(Article entity)
        {
            if (entity != null)
            {
                var article = unitOfWork.GetSet<Article>();
                article.AddOrUpdate(e => e.Id, entity);
                unitOfWork.Commit();
            }
        }

        public void Delete(Article entity)
        {
            if (entity != null)
            {
                unitOfWork.GetSet<Article>().Remove(entity);
                unitOfWork.Commit();
            }
        }

        public void Delete(long id)
        {
            var article = FindById(id);
            if (article != null)
            {
                Delete(article);
            }
        }

        public void Dispose()
        {
            this.unitOfWork.Dispose();
        }

        public Article FindById(long id)
        {
            return this.unitOfWork.GetSet<Article>().Find(id);
        }

        public Task<Article> FindByIdAsync(long id)
        {
            return unitOfWork.GetSet<Article>().FindAsync(id);
        }

        public IEnumerable<Article> GetAll()
        {
            return unitOfWork.GetSet<Article>();
        }

        public async Task<IEnumerable<Article>> GetArticlesFromStoreAsync(long id)
        {
            return await unitOfWork.GetSet<Article>().Where(x => x.Store_Id == id).ToListAsync();
        }
        #endregion

    }
}
