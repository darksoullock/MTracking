using MTracking.Models;
using MTracking.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTracking.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            DbRepository repository = new DbRepository();
            ViewBag.Companies = repository.GetCompaniesAsQueryable();
            ViewBag.Countries = repository.GetCountriesAsQueryable();
            ViewBag.Statuses = repository.GetStatusesAsQueryable();
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user, HttpPostedFileBase avatar,  string password2)
        {
            DbRepository repository = new DbRepository();
            ViewBag.Companies = repository.GetCompaniesAsQueryable();
            ViewBag.Countries = repository.GetCountriesAsQueryable();
            ViewBag.Statuses = repository.GetStatusesAsQueryable();

            if (user.Password != password2)
            {
                ViewBag.Error = "Passwords mismatch";
                return View(user);
            }

            var avatarsPath = Server.MapPath("~/Avatars");
            if (!Directory.Exists(avatarsPath))
            {
                Directory.CreateDirectory(avatarsPath);
            }

            if (avatar != null)
            {
                string filename = System.IO.Path.GetRandomFileName();
                var fullname = Path.Combine(avatarsPath, filename);
                user.Picture = filename;
                avatar.SaveAs(fullname);
            }

            AccountRepository accountRepository = new AccountRepository();
            accountRepository.AddUser(user);
            Session["user"] = user;
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            AccountRepository accountRepository = new AccountRepository();
            var user = accountRepository.GetUserByEmail(email);
            if (user?.Password == password)
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

        public ActionResult MyProfile()
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/Account/Login");
            }

            //var db = new AccountRepository();
            //user = db.GetUserById(user.Id);

            return View(user);
        }

        public FileResult Avatar(string name)
        {
            var path = Server.MapPath("~/Avatars/");
            var filename = Path.Combine(path, name);
            if (!System.IO.File.Exists(filename)||Path.GetDirectoryName(filename)!=Path.GetDirectoryName(path))
            {
                return null;
            }

            return File(System.IO.File.ReadAllBytes(filename),"image");
        }
    }
}