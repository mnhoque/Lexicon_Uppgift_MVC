using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lexicon_Uppgift_MVC.Models
{
    public class Employee
    {
        public string EmpName { get; set; }
        public int PhoneNumber { get; set; }
        public string City { get; set; }

         //List<Employee> listOfPeople = new List<Employee>();
        public static List<Employee> EmpList = new List<Employee>
                                 {new Employee{EmpName="Nazmul",PhoneNumber=087231,City="Göteborg"},
                                 new Employee{EmpName="Philip",PhoneNumber=0869813,City="Stockholm"},
                                 new Employee{EmpName="Sara",PhoneNumber=0875678,City="Malmö"}};

    }
}
