using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMicroService.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Http404()
        {
            return View();
        }
    }
}
