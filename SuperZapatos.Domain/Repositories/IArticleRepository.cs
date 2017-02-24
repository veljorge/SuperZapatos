using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.Domain.Repositories
{
    public interface IArticleRepository : IRepository<long, Article>
    {

        Task<IEnumerable<Article>> GetAllAsync();

        Task<IEnumerable<Article>> GetArticlesFromStoreAsync(long id);
    }
}
