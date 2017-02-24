namespace SuperZapatos.Core.IServices
{
    using SuperZapatos.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        IEnumerable<Articles> GetAll();

        Task<IEnumerable<Articles>> GetAllAsync();

        Task<IEnumerable<Articles>> GetArticlesFromStoreAsync(long id);

        void Add(Articles entity);

        void Delete(long id);

        void Delete(Articles entity);

        Articles FindById(long id);
    }
}
