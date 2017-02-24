//using Microsoft.Practices.Unity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SuperZapatos.Infrastructure
//{
//    public static class DependencyFactory
//    {

//        private static IUnityContainer container;

//        public static IUnityContainer Container
//        {
//            get
//            {
//                return container;
//            }
//            private set
//            {
//                container = value;
//            }
//        }

       


//        public static void RegisterTypes(IUnityContainer unityContainer, LifetimeManager lifeTimeManager)
//        {

//            container = unityContainer;

//            var manager = lifeTimeManager == null ? new PerResolveLifetimeManager() : lifeTimeManager;

//            container.RegisterType(typeof(SuperZapatosContext), manager);

//            RegisterRepositories();

//            RegisterServices();

//            RegisterMappings();



//        }

//        private static void RegisterMappings()
//        {
//            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Article, ArticleDto>());
//            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Store, StoreDto>());
//            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<ArticleDto, Article>());
//            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<StoreDto, Store>());
//        }

//        private static void RegisterRepositories()
//        {
//            container.RegisterType<IArticleRepository, ArticleRepository>(
//                new InjectionFactory((c, t, s) => new ArticleRepository(container.Resolve<SuperZapatosContext>())));

//            container.RegisterType<IStoreRepository, StoreRepository>(
//                new InjectionFactory((c, t, s) => new StoreRepository(container.Resolve<SuperZapatosContext>())));

//        }


//        private static void RegisterServices()
//        {

//            container.RegisterType<IStoreService, StoreService>(
//                new InjectionFactory((c, t, s) => new StoreService(container.Resolve<IStoreRepository>())));

//            container.RegisterType<IArticleService, ArticleService>(
//               new InjectionFactory((c, t, s) => new ArticleService(container.Resolve<IArticleRepository>())));

//        }

//        public static T GetType<T>()
//        {
//            return container.Resolve<T>();
//        }

//    }
//}
