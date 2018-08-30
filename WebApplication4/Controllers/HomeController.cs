using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        //       public string Index(string id,string name)
        //        {
        //            return "Entered Id is :" + id+" "+name;
        ////            return View();
        //        }
        public ActionResult Index()
        {
            ViewBag.countries = new List<string>()
            {
                "India",
                "america",
                "africa",
                "mongolia",
                "kenya",
                "seyrra leone"
            };
            TempData["countries"] = new List<string>()
            {
                "India",
                "america",
                "africa",
                "mongolia",
                "kenya",
                "seyrra leone"
            };
            //ViewData["Massage"] = "this massage is drown from index action method";
            //ViewBag.Massage = "this is drown from the action method";
            return View();
        }

        //public ActionResult Index1()
        //{
        //    //TempData["cuntries"] = new List<string>()
        //    //{
        //    //    "India",
        //    //    "america",
        //    //    "africa",
        //    //    "mongolia",
        //    //    "kenya",
        //    //    "seyrra leone"
        //    //};
        //    if (TempData["countries"] != null)
        //    {
        //        ViewBag.countries =(List<string>) TempData["countries"];
        //    }
        //    else
        //    {
        //        Response.Write("tempdata is empty");
        //    }
        //    return View();
        //}

        public ActionResult Index2()
        {
            if (TempData["countries"] != null)
            {
                ViewBag.countries = (List<string>)TempData["countries"];
            }
            else
            {
                Response.Write("temp data is empty");
            }
            return View();
        }
    }
    
}