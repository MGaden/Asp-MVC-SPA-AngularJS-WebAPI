using DataAccessLayer;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebClient.ViewModel;

namespace WebClient.Controllers.Api
{
    [RoutePrefix("api/language")]
    public class LanguageController : BaseApiController
    {
        [Route("GetLanguages")]
        [HttpGet]
        public List<LanguageViewModel> GetLanguages()
        {
            try
            {
                LanguageManager mn = new LanguageManager();
                return Converter.ToViewModel(mn.GetLanguage());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("SetCulture/{CultureName}")]
        [HttpGet]
        public IHttpActionResult SetCulture(string CultureName)
        {

            try
            {
                HttpCookie cookie = new HttpCookie("_culture", CultureName);

                cookie.Value = CultureName;
                cookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(cookie);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("GetSelectedCulture")]
        [HttpGet]
        public LanguageViewModel GetSelectedLanguage()
        {
            try
            {
                LanguageManager mn = new LanguageManager();
                return Converter.ToViewModel(mn.GetLanguageByCultureName(CultureHelper.GetCurrentCulture()));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}