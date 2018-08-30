using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult Index2(int id)
        {
            SqlDataHelper sdh = new SqlDataHelper();
            Employee emp = sdh.GetEmployeeData(id);
            //Employee emp=sdh.GetAllEmployee();
            return View(emp);
        }
        public ActionResult Employees()
        {
            SqlDataHelper sdh = new SqlDataHelper();
            List<Employee> emplo= sdh.GetAllEmployee();
            return View(emplo);
        }
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Employee employees = new Employee();
            //if (formcollection != null && formcollection .Count>0)
            //{
            //    employees.Name = formcollection["Name"];
            //    employees.Gender = formcollection["Gender"];
            //}
            //employees.Name = Name;
            //employees.Gender = Gender;
            // UpdateModel<Employee>(employees);
            if (TryUpdateModel<Employee>(employees))
            {
                SqlDataHelper db = new SqlDataHelper();
                db.InsertEmployee(employees);
                return RedirectToAction("Employees");
            }
            return View();
        }
        public string DisplaystringOnTheString()
        {
            return "Hello Akshay and Welcome to the mvc project";
        }
        public string DisplaystringOnTheString2()
        {
            return "Hello Akshay and Welcome to the mvc project";
        }
    }
}