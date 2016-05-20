using MTracking.Models;
using MTracking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTracking.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository = new AccountRepository();
        DbRepository repository = new DbRepository();

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Companies = repository.GetCompaniesAsQueryable();
            ViewBag.Countries = repository.GetCountriesAsQueryable();
            ViewBag.Statuses = repository.GetStatusesAsQueryable();
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            accountRepository.AddUser(user);
            Session["user"] = user;
            return Redirect("/");

            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = accountRepository.GetUserByEmail(email);
            if (user.Password==password)
            {
                Session["user"] = user;
                return Redirect("/");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["user"] = null;
            return Redirect("/");
        }
    }
}