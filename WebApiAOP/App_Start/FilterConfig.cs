﻿using System.Web.Http;
using System.Web.Mvc;
using WebApiAOP.App_Start;
using System.Linq;
using System.Web.Http.Filters;

namespace WebApiAOP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            RegisterFilterProviders();
        }

        private static void RegisterFilterProviders()
        {
            var providers =
                GlobalConfiguration.Configuration.Services.GetFilterProviders().ToList();

            GlobalConfiguration.Configuration.Services.Add(
                typeof(System.Web.Http.Filters.IFilterProvider),
                new UnityActionFilterProvider(UnityConfig.GetConfiguredContainer()));

            var defaultprovider = providers.First(p => p is ActionDescriptorFilterProvider);

            GlobalConfiguration.Configuration.Services.Remove(
                typeof(System.Web.Http.Filters.IFilterProvider),
                defaultprovider);
        }
    }
}
