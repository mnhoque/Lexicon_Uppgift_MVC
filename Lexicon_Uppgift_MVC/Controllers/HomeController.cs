using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lexicon_Uppgift_MVC.Models;

namespace Lexicon_Uppgift_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult CheckFever(string fname)
        //{
        //    double GetFrom = double.Parse(fname);
        //    Temparature Human = new Temparature();
        //    Human.HumanTemparature = 98.3;
        //    ViewBag.name = GetFrom;
        //    return View();
        //}
        public IActionResult CheckFever()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckFever(string fname)
        {
            double GetFrom = double.Parse(fname);
            //Temparature.MyProperty=98.3;
            Temparature.MyProperty = Temparature.Check(GetFrom);
            ViewBag.name = Temparature.MyProperty;
            return View();
        }
        int RandomNumber = 0;
        public IActionResult GenarateNumber()
        {
            Random rand = new Random();
            RandomNumber = rand.Next(1, 100);
            ViewBag.number = RandomNumber;
            return View();
        }
        [HttpPost]
        public IActionResult GenarateNumber(int fname)
        {
            //double GetFrom = double.Parse(fname);
            Temparature Human = new Temparature();
            //Human.HumanTemparature = 98.3;
            ViewBag.name = fname;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
