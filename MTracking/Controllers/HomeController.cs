using MTracking.Models;
using MTracking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MTracking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return Redirect("/Account/Login");
            }

            return Redirect("/Home/Projects");
        }

        public string Users(string q)
        {
            if (Session["user"] == null)
            {
                return null;
            }

            var db = new AccountRepository();
            var jss = new JavaScriptSerializer();
            //var users = db.GetUsersAsQueryable().Select(i => new { value = i.Id, label = i.FirstName + " " + i.LastName }).ToArray().ToDictionary(i => i.label, j => j.value);
            var users = db.GetUsersAsQueryable().Select(i => i.FirstName + " " + i.LastName ).ToArray();
            return jss.Serialize(users);
        }

        public ActionResult Projects()
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/Account/Login");
            }

            var repositiory = new DbRepository();
            var projects = repositiory.GetUserProjectsAsQueryable(user.Id);
            return View(projects);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/Account/Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/Account/Login");
            }

            project.OwnerId = user.Id;
            var repositiory = new DbRepository();
            repositiory.AddProject(project);

            return Redirect("/Home/Projects");
        }

        public ActionResult ProjectDetails(int id)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/Account/Login");
            }

            var db = new DbRepository();
            return View(db.GetProjectById(id));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}