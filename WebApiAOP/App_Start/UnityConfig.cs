using System;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Lifetime;
using Unity.log4net;
using WebApiAOP.Helper;
using WebApiAOP.Repositories.Interface;
using WebApiAOP.Repositories;
using System.Collections.Generic;

namespace WebApiAOP.App_Start
{
    public static class UnityConfig
    {
        static IUnityContainer GetContainer()
        {
            var newContainer = new UnityContainer()
                .AddNewExtension<LogCreation>()
                .AddNewExtension<Log4NetExtension>()
                .AddNewExtension<Interception>();

            return newContainer;
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        //static Lazy<IUnityContainer> container { get; set; }

        //private static Lazy<IUnityContainer>
        //container = new Lazy<IUnityContainer>(() =>
        //{
        //    var container = new UnityContainer();
        //    RegisterTypes(container);
        //    return container;
        //});


        private static Lazy<IUnityContainer>
        container = new Lazy<IUnityContainer>(() =>
        {
            var inContainer = new UnityContainer();
            RegisterComponents();
            return inContainer;
        });

        public static void RegisterComponents()
        {
            container = new Lazy<IUnityContainer>(GetContainer);

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.Value.RegisterType<ITestService, TestService>();
            //            container.Value.RegisterType<IRepository<>, Repository<>>(new HierarchicalLifetimeManager()
            //, new Interceptor<InterfaceInterceptor>() //Interception technique
            //, new InterceptionBehavior<ProfilingInterceptionBehavior>());

            container.Value.RegisterType(typeof(IRepository<>), typeof(Repository<>)
                , new HierarchicalLifetimeManager()
                , new Interceptor<InterfaceInterceptor>() //Interception technique
                , new InterceptionBehavior<ProfilingInterceptionBehavior>());

        }
    }

   
}