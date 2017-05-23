using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Diagnostics;
using System.Web.Routing;


namespace Mod02_01
{
        public class LogActionFilter:ActionFilterAttribute
        {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //Debug.WriteLine("This Event Fired: OnActionExecuting");
            Log("OnActionExecuting", filterContext.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            //Debug.WriteLine("This Event Fired: OnActionExecuted");
            Log("OnActionExecuted", filterContext.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            //Debug.WriteLine("This Event Fired: OnResultExecuting");
            Log("OnResultExecuting", filterContext.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            //Debug.WriteLine("This Event Fired: OnResultExecuted");
            Log("OnResultExecuted", filterContext.RouteData);
        }
        
        //製作Log函式，並且限定只能在這個class用
        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format("{0} controler: {1}, action: {2}", methodName, controllerName, actionName);
            Debug.WriteLine(message);
        }
    }

}
