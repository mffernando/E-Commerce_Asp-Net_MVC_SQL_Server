﻿using ECommerce.Class;
using System;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ECommerce
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //automatic migration
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.ECommerceContext, Migrations.Configuration>());
            CheckRolesAndSuperUser();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void CheckRolesAndSuperUser()
        {
            //check permission
            UserHelper.UserHelper.CheckRole("Admin");
            UserHelper.UserHelper.CheckRole("User");
            UserHelper.UserHelper.CheckSuperUser();
        }
    }
}
