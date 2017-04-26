using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMicroService.Controllers
{
    [Route("api/[controller]")]
    public class TimeStampController : Controller
    {

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { Unix = (string)null, Natural = (string)null });
        }

        // GET api/values/5
        [HttpGet("{date}")]
        public IActionResult Get(string date)
        {
            long unixStamp = 0;
            DateTime natural = default(DateTime);
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            if (long.TryParse(date, out unixStamp))
            {
                natural = epoch.AddSeconds(unixStamp).ToLocalTime();
                return Json(new { Unix = unixStamp, Natural = natural.ToString("MMMM dd, yyyy") });
            }
            else
            {
                try
                {
                    natural = DateTime.Parse(date).ToUniversalTime();
                }
                catch (FormatException)
                {
                    return Json(new { Unix = (string)null, Natural = (string)null });
                }

                unixStamp = (long)Math.Round(natural.Subtract(epoch).TotalSeconds);


                return Json(new { Unix = unixStamp, Natural = natural.ToString("MMMM dd, yyyy") });
            }
        }
    }
}
