using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Localization;

namespace ApiMicroService.Controllers
{
    [Route("api/findme")]
    public class HeaderController : Controller
    {
        //Regex for getting out the OS information from Request.Headers
        public Regex regex { get; set; } = new Regex("[(](.*?)[)]");

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            string os = Request.Headers["User-Agent"].ToString();

            Match match = regex.Match(os);
            os = match.Value;

            os = os.Replace('(', ' ');
            os = os.Replace(')', ' ').Trim();

            string ip = Request.HttpContext.Connection.RemoteIpAddress.ScopeId.ToString();

            string language = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.ToString();

            return Json(new { Ipaddress = ip, Software = os, Language = language });
        }
    }
}
