using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KouTrashCollector.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace KouTrashCollector.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us";

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }


    }
}