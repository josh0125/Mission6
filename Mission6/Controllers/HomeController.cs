using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieInputContext _MovieInputContext { get; set; }


        public HomeController(ILogger<HomeController> logger, MovieInputContext name)
        {
            _logger = logger;
            _MovieInputContext = name;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Input()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Input(InputResponse ir)
        {
            if (ModelState.IsValid)
            {
                _MovieInputContext.Add(ir);
                _MovieInputContext.SaveChanges();

                return View();
            }
            else
            {
                return View(ir);
            }
           

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
