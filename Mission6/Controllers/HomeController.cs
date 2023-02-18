using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var applications =_MovieInputContext.responses
                .Include(x => x.Category)
                .ToList();
            return View(applications);
        }


        //Returns Input Movie Page
        [HttpGet]
        public IActionResult Input()
        {


            ViewBag.Categories = _MovieInputContext.categories.ToList();

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
                ViewBag.Categories = _MovieInputContext.categories.ToList();

                return View(ir);
            }
  
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _MovieInputContext.categories.ToList();

            var application = _MovieInputContext.responses
                .Single(x => x.InputID == id);

            return View("Input", application);
        }

        [HttpPost]
        public IActionResult Edit(InputResponse ir)
        {
            _MovieInputContext.responses.Update(ir);

            _MovieInputContext.SaveChanges();

            return RedirectToAction("Table");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var application =_MovieInputContext.responses.Single(x => x.InputID == id);
            return View("Delete", application);
        }

        [HttpPost]
        public IActionResult Delete(InputResponse ir)
        {
            _MovieInputContext.responses.Remove(ir);
            _MovieInputContext.SaveChanges();

            return RedirectToAction("Table");
        }
    }
}
