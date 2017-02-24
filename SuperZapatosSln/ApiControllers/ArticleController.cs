
namespace SuperZapatosSln.ApiControllers
{
    using App_Start;
    using SuperZapatos.Core;
    using SuperZapatos.Core.IServices;
    using SuperZapatos.Dtos;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Web.Http;

    [BasicAuthenticationAttribute]
    [RoutePrefix("services")]
    public class ArticleController : ApiController
    {
        #region Private Members
        private IArticleService articleService;
        #endregion

        #region Construction
        public ArticleController()
        {
            articleService = ContainerBootstrapper.GetType<IArticleService>();
        }

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }
        #endregion

        #region Api Controller Members

        [Route("articlesSync")]
        [HttpGet]
        public IHttpActionResult GetAllStores()
        {
            try
            {
                var article = articleService.GetAll();
                return Ok(article);
            }
            catch (Exception)
            {
                return Ok(new ErrorResponse("Server Error", 500, false));
            }
        }

        [Route("articles")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllStoresAsync()
        {
            try
            {
                var articles = await articleService.GetAllAsync();

                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("Articles", articles);
                dict.Add("Success", true);
                dict.Add("Count", articles.Count());
                return Ok(dict);
            }
            catch (Exception)
            {
                return Ok(new ErrorResponse("Server Error", 500, false));
            }
        }

        [Route("articles/stores/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetArticlesFromStoreAsync(string id)
        {
            try
            {
                long number;
                if (long.TryParse(id, out number) == true)
                {
                    var articles = await articleService.GetArticlesFromStoreAsync(number);

                    if (articles.Count() > 0)
                    {
                        Dictionary<string, object> dict = new Dictionary<string, object>();
                        dict.Add("Articles", articles);
                        dict.Add("Success", true);
                        dict.Add("Count", articles.Count());
                        return Ok(dict);
                    }
                    else
                    {

                        return Ok(new ErrorResponse("Record Not Found", 400, false));
                    }

                }
                else
                {
                    return Ok(new ErrorResponse("Bad Request", 404, false));
                }
            }
            catch (Exception)
            {

                return Ok(new ErrorResponse("Server Error", 500, false));
            }
        }
        #endregion


    }
}
