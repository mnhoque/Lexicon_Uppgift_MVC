using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lexicon_Uppgift_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lexicon_Uppgift_MVC.Controllers
{
    public class NextController : Controller
    {
        List<Employee> listOfPeople = Employee.EmpList;
        List<Employee> selectedlist = new List<Employee>();

        public IActionResult ShowEmployees()
        {

            foreach (var dir in listOfPeople)
            {
                Employee em = new Employee();
                em.EmpName = dir.EmpName;
                em.PhoneNumber = dir.PhoneNumber;
                em.City = dir.City;
                selectedlist.Add(em);
            }

            ViewBag.sl = selectedlist.Count;

            return View(selectedlist);
            //return View();
        }
        
        public IActionResult Search(string firstletter)
        {
            List<Employee> Individuallist = new List<Employee>();
            foreach (var item in listOfPeople)
            {
                if (item.EmpName[0].ToString() == firstletter)
                {
                    Individuallist.Add(item);
                }

            }
            return View(Individuallist);
        }
        public IActionResult Index()
        {
            return View();
            //return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string fname, int phonenumber, string cname)
        {
            if (fname != null||phonenumber!=0||cname!=null)
            {
                var emp = new Employee();
                emp.EmpName = fname;
                emp.PhoneNumber = phonenumber;
                emp.City = cname;
                Employee.EmpList.Add(emp);
            }
            else
            {
                ViewBag.name = "There is a error message";
            }
            return View("ShowEmployees", Employee.EmpList);
        }
        public IActionResult Delete(string id)
        {
            var model = listOfPeople.Where(x => x.EmpName == id).FirstOrDefault();
            listOfPeople.Remove(model);
            //return View("ShowEmployees",listOfPeople);
            return View(model);
        }
    }

}
