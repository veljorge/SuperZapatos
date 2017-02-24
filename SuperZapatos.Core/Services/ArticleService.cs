namespace SuperZapatos.Core.Services
{
    using Domain;
    using Domain.Repositories;
    using Dtos;
    using IServices;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System;

    public class ArticleService : IArticleService
    {
        #region Private Members
        private readonly IArticleRepository repository;
        #endregion

        #region Construction
        public ArticleService(IArticleRepository articleRepository)
        {
            repository = articleRepository;
        }


        #endregion

        #region IService Members

        public IEnumerable<Articles> GetAll()
        {
            return repository.GetAll().Select(x => AutoMapper.Mapper.Map<Articles>(x));
        }

        public async Task<IEnumerable<Articles>> GetAllAsync()
        {
            return from article in await repository.GetAllAsync() select AutoMapper.Mapper.Map<Articles>(article);
        }


        public void Add(Articles entity)
        {
            repository.Add(AutoMapper.Mapper.Map<Article>(entity));
        }

        public void Delete(long Id)
        {
            repository.Delete(Id);
        }

        public void Delete(Articles entity)
        {
            repository.Delete(AutoMapper.Mapper.Map<Article>(entity));
        }

        public Articles FindById(long id)
        {
            return AutoMapper.Mapper.Map<Articles>(repository.FindById(id));
        }

        public async Task<IEnumerable<Articles>> GetArticlesFromStoreAsync(long id)
        {
            return from article in await repository.GetArticlesFromStoreAsync(id)
                   select AutoMapper.Mapper.Map<Articles>(article);
        }


        #endregion

    }
}
