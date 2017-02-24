

namespace SuperZapatosSln.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using SuperZapatos.Dtos;
    using SuperZapatos.Core.IServices;
    using SuperZapatos.Core;
    using ApiControllers;
    public class ArticleController : Controller
    {

        #region Private Members
        private IArticleService articleService;
        private IStoreService storeService;
        #endregion

        #region Construction
        public ArticleController()
        {
            articleService = ContainerBootstrapper.GetType<IArticleService>();
            storeService = ContainerBootstrapper.GetType<IStoreService>();
        }

        public ArticleController(IArticleService articleService, IStoreService storeService)
        {
            this.articleService = articleService;
            this.storeService = storeService;
        }
        #endregion

        #region Controller Members
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            var stores = storeService.GetAll().Select(x=> new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.stores = stores;
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(Articles collection)
        {
            try
            {
                // TODO: Add insert logic here
                articleService.Add(collection);
                return RedirectToAction("Index", "Article");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            var stores = storeService.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.stores = stores;
            var article = articleService.FindById(id);
            return View(article);
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Articles collection)
        {
            try
            {
                articleService.Add(collection);
                return RedirectToAction("Index", "Article");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            var article = articleService.FindById(id);
            return View(article);
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Articles collection)
        {
            try
            {
                articleService.Delete(id);
                return RedirectToAction("Index", "Article");
            }
            catch
            {
                return View();
            }
        }
        #endregion

    }
}
