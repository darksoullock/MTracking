using MTracking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MTracking.Controllers
{
    public class ApiController : Controller
    {
        public string Login(string email, string password)
        {
            var db = new AccountRepository();
            var user = db.GetUserByEmail(email);
            var jss = new JavaScriptSerializer();
            if (user != null && user.Password == password)
            {
                string token = db.SetToken(user.Id);
                return jss.Serialize(new { status = "ok", token = token });
            }

            return jss.Serialize(new { status = "bad" });
        }

        public string GetUsersProjects(string email, string token)
        {
            var accr = new AccountRepository();
            int uid;
            if (!accr.IsAuthorized(email, token, out uid))
            {
                return null;
            }

            var db = new DbRepository();
            var jss = new JavaScriptSerializer();
            var projects = db.GetUserProjectsAsQueryable(uid).Select(i => new
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description
            });

            return jss.Serialize(projects);
        }

        public string GetProjectBugs(string email, string token, int projectId)
        {
            var accr = new AccountRepository();
            int uid;
            if (!accr.IsAuthorized(email, token, out uid))
            {
                return null;
            }

            var db = new DbRepository();
            var jss = new JavaScriptSerializer();
            var bugs = db.GetProjectBugs(projectId).Select(i => new
            {
                Id = i.Id,
                Description = i.Description
            });

            return jss.Serialize(bugs);
        }

        public string GetBug(string email, string token, int id)
        {
            var accr = new AccountRepository();
            int uid;
            if (!accr.IsAuthorized(email, token, out uid))
            {
                return null;
            }

            var db = new DbRepository();
            var jss = new JavaScriptSerializer();
            var bug = db.GetBugById(id);

            if (bug == null)
            {
                return null;
            }

            var comments = bug?.Comments?.Select(i => new
            {
                Name = i.User?.FirstName + " " + i.User?.LastName,
                DateString = i.DateAdded.ToString(),
                Text = i.Content
            }).ToArray();

            return jss.Serialize(
                new {
                    Id = bug.Id,
                    ActualResult = bug.ActualResult,
                    Description = bug.Description,
                    ReproductionSteps = bug.ReproductionSteps,
                    ExpectedResult = bug.ExpectedResult,
                    Status = bug.BugStatus?.Status,
                    AssignedUser = bug.User?.FirstName+" "+bug.User?.LastName,
                    Comments = comments
                });
        }
    }
}