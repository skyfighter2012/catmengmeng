using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatMM.Web
{
    public class MyActionFilterAttribute : FilterAttribute, IActionFilter, IResultFilter, IExceptionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(String.Format("OnActionExcuted:{0}<br />", DateTime.Now.ToString("HH:mm:ss")));
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write(String.Format("OnActionExecuting:{0}<br />", DateTime.Now.ToString("HH:mm:ss")));
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(String.Format("OnResultExecuted:{0}<br />", DateTime.Now.ToString("HH:mm:ss")));
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write(String.Format("OnResultExecuting:{0}<br />", DateTime.Now.ToString("HH:mm:ss")));
        }

        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Write(String.Format("OnException:{0}<br />", DateTime.Now.ToString("HH:mm:ss")));
            filterContext.ExceptionHandled = true;
        }
    }
}