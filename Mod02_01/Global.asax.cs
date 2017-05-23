using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Mod02_01.DAL;
using System.Data.Entity;

namespace Mod02_01
{
    public class MvcApplication : System.Web.HttpApplication
    {  
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Lab2_4啟用種子資料建立
            Database.SetInitializer<OperaContext>(new OperaInitializer());
            //LAB 3_9 啟動所有的Action的Log。global的log要作在這裡
            GlobalFilters.Filters.Add(new LogActionFilter());
        }
    }
}
