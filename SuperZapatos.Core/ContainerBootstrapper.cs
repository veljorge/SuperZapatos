namespace SuperZapatos.Core
{
    using Core.IServices;
    using Core.Services;
    using Data;
    using Data.Repositories;
    using Domain;
    using Domain.Repositories;
    using Dtos;
    using Microsoft.Practices.Unity;
    public sealed class ContainerBootstrapper
    {
        private static IUnityContainer container;

        private ContainerBootstrapper()
        {

        }


        public static void RegisterTypes(IUnityContainer unityContainer , LifetimeManager lifeTimeManager)
        {

            container = unityContainer;

            var manager = lifeTimeManager == null ? new PerResolveLifetimeManager() : lifeTimeManager;

            container.RegisterType(typeof(SuperZapatosContext), manager);

            RegisterRepositories();

            RegisterServices();

            RegisterMappings();


            
        }

        private static void RegisterMappings()
        {
            
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Article, Articles>();
                cfg.CreateMap<Store, Stores>();//.ForMember(x=> x.Articles , opt=> opt.Ignore());
                cfg.CreateMap<Articles, Article>();
                cfg.CreateMap<Stores, Store>();//.ForMember(x=> x.Articles, opt=> opt.Ignore());
            });
        }

        private static void RegisterRepositories()
        {
            container.RegisterType<IArticleRepository, ArticleRepository>(
                new InjectionFactory((c, t, s) => new ArticleRepository(container.Resolve<SuperZapatosContext>())));

            container.RegisterType<IStoreRepository, StoreRepository>(
                new InjectionFactory((c, t, s) => new StoreRepository(container.Resolve<SuperZapatosContext>())));

        }


        private static void RegisterServices()
        {

            container.RegisterType<IStoreService, StoreService>(
                new InjectionFactory((c, t, s) => new StoreService(container.Resolve<IStoreRepository>())));

            container.RegisterType<IArticleService, ArticleService>(
               new InjectionFactory((c, t, s) => new ArticleService(container.Resolve<IArticleRepository>())));

        }

        public static T GetType<T>()
        {
            return container.Resolve<T>();
        }
    }
}
