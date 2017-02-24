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
    public class StoreController : ApiController
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

        #region Api Controller Members

        [Route("storesSync")]
        [HttpGet]
        public IHttpActionResult GetAllStores()
        {
            try
            {
                var stores = storeService.GetAll();
                return Ok(stores);
            }
            catch (Exception)
            {
                return Ok(new ErrorResponse("Server Error", 500, false));
            }
        }

        [Route("stores")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllStoresAsync()
        {
            try
            {
                var stores = await storeService.GetAllAsync();

                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("stores", stores);
                dict.Add("success", true);
                dict.Add("count", stores.Count());


                return Ok(dict);
            }
            catch (Exception)
            {

                return Ok(new ErrorResponse("Server Error", 500, false));
            }
        }
        #endregion

    }
}

