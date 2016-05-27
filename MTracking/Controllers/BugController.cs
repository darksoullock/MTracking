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

        public ActionResult Create()
        {
            return View();
        }
    }
}