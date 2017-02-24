using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperZapatos.Dtos;
using SuperZapatos.Core.IServices;
using SuperZapatos.Core;
namespace SuperZapatosSln.Controllers
{
    public class StoreController : Controller
    {

        #region Private Members
        private IStoreService storeService;
        #endregion

        #region Construction
        public StoreController()
        {
            storeService = ContainerBootstrapper.GetType<IStoreService>();
        }
        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }
        #endregion

        #region Controller Members 
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(Stores collection)
        {
            try
            {
                storeService.Add(collection);
                return RedirectToAction("Index", "Store");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            var store = storeService.FindById(id);
            return View(store);
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Stores collection)
        {
            try
            {
                storeService.Add(collection);
                return RedirectToAction("Index", "Store");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            var store = storeService.FindById(id);
            return View(store);
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Stores collection)
        {
            try
            {
                storeService.Delete(id);
                return RedirectToAction("Index", "Store");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        #endregion
        
    
    }
}
