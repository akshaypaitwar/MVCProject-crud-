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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employees)
        {
            SqlDataHelper db = new SqlDataHelper();
            db.InsertEmployee(employees);
            return View();
        }
    }
}