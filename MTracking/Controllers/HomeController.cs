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

            return Redirect("/Project/Projects");
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
    }
}