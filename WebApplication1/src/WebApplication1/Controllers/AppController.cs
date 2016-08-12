using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Helpers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class AppController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string ua = Request.Headers["User-Agent"];
            string ip = HttpContext.Connection.RemoteIpAddress.ToString();
            var now = GMT.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Register([Bind("Name","Email","OptIn","AgreeTerms")]Entry entry)
        {
            if (ModelState.IsValid)
            {
                string ua = Request.Headers["UserAgent"];
                string ip = HttpContext.Connection.RemoteIpAddress.ToString();

                return Json(new { status = "ok" });
            }
            else
            {
                return Json(new { status = "error", message = ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage) });
            }
        }

    }
}
