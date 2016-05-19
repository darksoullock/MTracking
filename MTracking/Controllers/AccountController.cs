using MTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTracking.Controllers
{
    public class AccountController : Controller
    {
        MContext _db = new MContext();

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Companies = _db.Companies;
            ViewBag.Countries = _db.Countries;
            ViewBag.Statuses = _db.Statuses;
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            return View();
        }
    }
}