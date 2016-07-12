using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IConfigurationSection config;
        private IOptions<MyOptions> options;

        public HomeController(IConfigurationSection config, IOptions<MyOptions> options)
        {
            this.config = config;
            this.options = options;
        }

        public IActionResult Index()
        {
            ViewBag.Cheese = config["Cheese"];
            ViewBag.Ham = options.Value.Ham;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
