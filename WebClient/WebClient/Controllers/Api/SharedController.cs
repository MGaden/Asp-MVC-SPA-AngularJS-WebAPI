using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyWebClient.Helpers;
using System.Resources;
using System.Web.Compilation;

namespace WebClient.Controllers.Api
{
    [RoutePrefix("api/shared")]
    public class SharedController : BaseApiController
    {
        [Route("GetResourceStrings")]
        [HttpPost]
        public Dictionary<string, string> GetResourceStrings(string resName, ResourceArray ResDic)
        {
            //  createFolders();
            Dictionary<string, string> resources = new Dictionary<string, string>();
            try
            {
                Type t = BuildManager.GetType("WebClient.Resource." + resName + ",WebClient.Resource", false);
                ResourceManager mn = new ResourceManager(t);

                for (int i = 0; i < ResDic.ResArray.Count; i++)
                {
                    resources.Add(ResDic.ResArray[i], mn.GetString(ResDic.ResArray[i], new System.Globalization.CultureInfo(CultureHelper.GetCurrentCulture())));
                }

            }
            catch (Exception ex)
            {

            }
            return resources;

        }
    }

    public class ResourceArray
    {
        private List<string> resArray = new List<string>();

        public List<string> ResArray
        {
            get { return resArray; }
            set { resArray = value; }
        }


    }
}
