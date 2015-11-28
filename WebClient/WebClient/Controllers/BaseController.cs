
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebClient.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = RouteData.Values["culture"] as string;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                //  need to obtain default culture it from web.config
                cultureName = "en-US";
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }

        protected internal ViewResult ViewBasedOnRequest()
        {
            if (Request.AcceptTypes.Contains("application/json"))
            {
                return View();
            }

            return View("~/Views/Home/Index.cshtml");
        }

        protected internal ViewResult ViewBasedOnRequest(object model)
        {
            if (Request.AcceptTypes.Contains("application/json"))
            {
                return View(model);
            }
            return View("~/Views/Home/Index.cshtml", model);
        }

        protected internal ViewResult ViewBasedOnRequest(string viewName)
        {
            if (Request.AcceptTypes.Contains("application/json"))
            {
                return View(viewName);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        protected internal ViewResult ViewBasedOnRequest(string viewName, object model)
        {
            if (Request.AcceptTypes.Contains("application/json"))
            {
                return View(viewName, model);
            }
            return View("~/Views/Home/Index.cshtml", model);
        }

        protected internal ViewResult ViewBasedOnRequest(string viewName, string masterName)
        {
            if (Request.AcceptTypes.Contains("application/json"))
            {
                return View(viewName, masterName);
            }
            return View("~/Views/Home/Index.cshtml", masterName);
        }

        protected internal virtual ViewResult ViewBasedOnRequest(string viewName, string masterName, object model)
        {
            if (Request.AcceptTypes.Contains("application/json"))
            {
                return View(viewName, masterName, model);
            }
            return View("~/Views/Home/Index.cshtml", masterName, model);
        }

        public bool HasJSONAcceptType()
        {
            if (Request.AcceptTypes.Contains("application/json"))
                return true;
            return false;
        }
    }
}