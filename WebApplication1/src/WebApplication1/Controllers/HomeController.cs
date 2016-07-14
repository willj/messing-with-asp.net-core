using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IConfigurationSection config;
        private IOptions<MyOptions> options;
        private IConfigurationRoot root;
        private ICountriesRepository countryDb;

        public HomeController(IConfigurationSection config, IOptions<MyOptions> options, IConfigurationRoot root, ICountriesRepository countryDb)
        {
            this.config = config;
            this.options = options;
            this.root = root;
            this.countryDb = countryDb;
        }

        public IActionResult Index()
        {
            ViewBag.Cheese = config["Cheese"];
            ViewBag.Ham = options.Value.Ham;
            ViewBag.ConnString = root.GetConnectionString("AppDb");
            ViewBag.RootStuff = root["AppSettings:Cheese"];

            var db = new ElephantsRepository(root);

            ViewBag.Elephants = db.GetElephants();

            // injected
            ViewBag.Countries = countryDb.GetCountries();

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

        [HttpGet("api/[controller]/cheese/{id}")]
        public IActionResult GetCheese(int id)
        {
            //return NotFound();
            return new ObjectResult(new { Id = id, Name = "Blah", Type = "BlahBlah" });
        }

        [HttpGet("api/[controller]/cheese")]
        public IActionResult AllCheese()
        {
            return new OkObjectResult(new List<string>()
            {
                "parmesan", "cheddar", "edam"
            });
        }

        [HttpGet("api/[controller]/test")]
        public IActionResult test()
        {
            ModelState.AddModelError("Nope", "Nope said no!");
            ModelState.AddModelError("Nope", "Nope said no again!");
            ModelState.AddModelError("Auth", "Get oot!");

            return new BadRequestObjectResult(ModelState);

            //return new NoContentResult();
        }

    }
}
