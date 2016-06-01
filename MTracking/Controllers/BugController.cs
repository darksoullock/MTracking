using MTracking.Models;
using MTracking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTracking.Controllers
{
    public class BugController : Controller
    {
        public PartialViewResult BugsPartial(int id)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return null;
            }

            var db = new DbRepository();
            return PartialView("_Bugs", db.GetProjectById(id));
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return null;
            }

            var db = new DbRepository();
            ViewBag.Statuses = db.GetBugStatusesAsQueryable();
            return View(new Bug() { ProjectId = id });
        }

        [HttpPost]
        public ActionResult Create(Bug bug)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return null;
            }

            var db = new DbRepository();
            var projects = db.GetProjectById(bug.ProjectId);
            if (projects.Owner.Id != user.Id && projects.Users.FirstOrDefault(i => i.Id == user.Id) == null)
            {
                return null;
            }

            db.AddBug(bug);
            return Redirect("/Project/Details/" + bug.ProjectId + "?tab=/Bug/BugsPartial");
        }

        public void ChangeStatus(int statusId, int bugId)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return;
            }

            var db = new DbRepository();
            var projects = db.GetProjectByBugId(bugId);
            if (projects.Owner.Id != user.Id && projects.Users.FirstOrDefault(i => i.Id == user.Id) == null)
            {
                return;
            }

            db.ChangeBugStatus(bugId, statusId);
        }

        public ActionResult Details(int id)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/");
            }

            var db = new DbRepository();
            ViewBag.Statuses = db.GetBugStatusesAsQueryable();
            return View(db.GetBugById(id));
        }
    }
}