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
        private MovieInputContext _MovieInputContext { get; set; }


        public HomeController(MovieInputContext name)
        {
            _MovieInputContext = name;
        }

        // Returns Index
        public IActionResult Index()
        {
            return View();
        }

        // Returs Podcast Page
        public IActionResult Podcast()
        {
            return View();
        }

        // Returns Index
        public IActionResult Table()
        {
            var applications =_MovieInputContext.responses.ToList();
            return View(applications);
        }


        //Returns Input Movie Page
        [HttpGet]
        public IActionResult Input()
        {
            return View();
        }

        // Uploads to Database
        [HttpPost]
        public IActionResult Input(InputResponse ir)
        {
            if (ModelState.IsValid)
            {
                _MovieInputContext.Add(ir);
                _MovieInputContext.SaveChanges();

                return View("Confirmation", ir);
            }
            else
            {
                return View(ir);
            }
           

            
        }

    }
}
