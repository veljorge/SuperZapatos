namespace SuperZapatosSln
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using SuperZapatos.Core;
    using Microsoft.Practices.Unity;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterBootstrapper();
        }

        private void RegisterBootstrapper()
        {
            var container = new UnityContainer();
            ContainerBootstrapper.RegisterTypes(container, new HierarchicalLifetimeManager());
        }

    }
}
