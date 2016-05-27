using MTracking.Models;
using MTracking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTracking.Controllers
{
    public class ProjectController : Controller
    {
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
        public ActionResult Create()
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/Account/Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/Account/Login");
            }

            project.OwnerId = user.Id;
            var repositiory = new DbRepository();
            repositiory.AddProject(project);

            return Redirect("/Project/Projects");
        }

        public ActionResult Details(int id)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/Account/Login");
            }

            var db = new DbRepository();
            return View(db.GetProjectById(id));
        }

        public PartialViewResult InfoPartial(int id)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return null;
            }

            var db = new DbRepository();
            return PartialView("_Description", db.GetProjectById(id));
        }

        public PartialViewResult TeamPartial(int id)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return null;
            }

            var acc = new AccountRepository();
            ViewBag.Users = acc.GetUsersAsQueryable().Where(i => !i.Projects.Select(j => j.Id).Contains(id));
            var db = new DbRepository();
            return PartialView("_Team", db.GetProjectById(id));
        }
    }
}