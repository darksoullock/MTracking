﻿using MTracking.Models;
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
            ViewBag.Users = db.GetProjectUsersById(id);
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

        // функция вызывается ajax запросом со страницы BugDetails
        public void ChangeStatus(int statusId, int bugId)
        {
            // получаем пользователя из сессии
            var user = Session["user"] as User;
            // если в сессии нет пользователя, значит он не залогинен.
            if (user == null)
            {
                //ничего не делаем, выходим
                return;
            }

            var db = new DbRepository();
            // получаем проект, к которому относится баг
            var project = db.GetProjectByBugId(bugId);
            // Если пользователь не относится к проекту, то выходим
            if (project.Owner.Id != user.Id && project.Users.FirstOrDefault(i => i.Id == user.Id) == null)
            {
                return;
            }

            // меняем статус
            db.ChangeBugStatus(bugId, statusId);
        }

        public void ChangeAssignedUser(int userId, int bugId)
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

            db.ChangeBugUser(bugId, userId);
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
            var projectId = db.GetProjectByBugId(id).Id;
            ViewBag.Users = db.GetProjectUsersById(projectId);
            ViewBag.Comments = db.GetComments(id);
            return View(db.GetBugById(id));
        }

        public ActionResult AddComment(int bugId, string text)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return Redirect("/");
            }

            var db = new DbRepository();
            db.AddComment(user.Id, text, bugId);
            return Redirect("/Bug/Details/"+bugId);
        }
    }
}