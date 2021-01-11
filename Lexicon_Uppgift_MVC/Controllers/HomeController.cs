using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lexicon_Uppgift_MVC.Models;
using Microsoft.AspNetCore.Http;

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
        GuessingGame game = new GuessingGame();
        int count ;
        List<int> numberList = new List<int>();
        //List<int> numbers2 = new List<int>();
        public IActionResult GenarateNumber()
        {
            RandomNumber = game.GenerateRandomNumber();
            HttpContext.Session.SetInt32("RandomNumber", RandomNumber);
            count = 0;
            HttpContext.Session.SetInt32("GuessCount",count);
            HttpContext.Session.Set<List<int>>("ComplexObject", numberList);
            ViewBag.number= HttpContext.Session.GetInt32("RandomNumber");
            return View();
        }


        //public object Session { get; private set; }
        
        [HttpPost]
        public IActionResult GenarateNumber(int fname, int? n1)
        {
            if (fname != 0)
            {
                
                int y = (int)HttpContext.Session.GetInt32("GuessCount") + 1;
                n1 = HttpContext.Session.GetInt32("RandomNumber");
                string x = game.EnterList(fname, n1);
                if(x== "You have not win because submitted number did not match with random number ")
                {
                    var new_numberList = HttpContext.Session.Get<List<int>>("ComplexObject") as List<int>;
                    new_numberList.Add(fname);
                    HttpContext.Session.Set<List<int>>("ComplexObject", new_numberList);
                    ViewBag.numbers = HttpContext.Session.Get<List<int>>("ComplexObject");
                }
                HttpContext.Session.SetString("SessionKeyName", x);

                var name = HttpContext.Session.GetString("SessionKeyName");
                
                HttpContext.Session.SetInt32("GuessCount", y);
                HttpContext.Session.GetInt32("GuessCount");
                //HttpContext.Session.Get<List<int>>("ComplexObject");
                
                
                ViewBag.name = name + " and tries " + HttpContext.Session.GetInt32("GuessCount") + " times";

                if (name == "You have win ")
                {
                    HttpContext.Session.Clear();
                    //return RedirectToAction("Close",ViewBag.name);
                    return View("Close", ViewBag.name);
                }

                
            }
            else
            {
                ViewBag.name = "There is a error message";
            }
            return View();

        }
        [HttpGet]
        public IActionResult Close()
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
