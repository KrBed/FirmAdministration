using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using FirmAdministartion.Data.Identity;
using FirmAdministration.Web.App_Start;
using FirmAdministration.Web.Models.ViewModels;

namespace FirmAdministration.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(x => x.CreateMap<ApplicationUser, UserViewModel>());
            Mapper.Initialize(x => x.CreateMap<IList<ApplicationUser>, IList<UserViewModel>>());
            Mapper.Initialize(x => x.CreateMissingTypeMaps = true);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
