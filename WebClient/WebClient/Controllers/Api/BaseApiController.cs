using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace WebClient.Controllers.Api
{
    public class BaseApiController : ApiController
    {
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            string cultureName = controllerContext.RouteData.Values["culture"] as string;
            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = System.Web.HttpContext.Current.Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                //  need to obtain default culture  from web.config
                cultureName = "en-US";
            // Validate culture name
            //cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;


            base.Initialize(controllerContext);
        }
    }
}
