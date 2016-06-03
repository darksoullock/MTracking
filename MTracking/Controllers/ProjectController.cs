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
        [HttpGet]
        public ActionResult Projects()
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/Account/Login");
            }

            var repositiory = new DbRepository();
            var projects = repositiory.GetUserProjectsAsQueryable(user.Id);
            return View(projects.OrderBy(i => i.Name));
        }

        [HttpPost]
        public ActionResult Projects(string query)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/Account/Login");
            }

            var repositiory = new DbRepository();
            var projects = repositiory.GetUserProjectsAsQueryable(user.Id).ToArray().Where(i => i.Name.ToUpper().Contains(query.ToUpper()));
            return View(projects.OrderBy(i => i.Name));
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

        public ActionResult Details(int id, string tab = "/Project/InfoPartial")
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/Account/Login");
            }

            ViewBag.Tab = tab;
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

        public ActionResult AddTeamToProject(int userId, int projectId)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return null;
            }

            var db = new DbRepository();
            if (db.GetProjectById(projectId).Owner.Id != user.Id)
            {
                return null;
            }

            db.AddUserToProject(userId, projectId);

            return Redirect("/Project/Details/" + projectId + "?tab=/Project/TeamPartial");
        }

        public ActionResult Delete(int id)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return null;
            }

            var db = new DbRepository();
            if (db.GetProjectById(id).OwnerId == user.Id)
            {
                db.RemoveProject(id);
            }

            return Redirect("/Project/Projects");
        }

        public ActionResult Leave(int id)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return null;
            }

            var db = new DbRepository();
            db.LeaveProject(id, user.Id);

            return Redirect("/Project/Projects");
        }
    }
}