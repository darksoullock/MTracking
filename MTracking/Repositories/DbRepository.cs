using MTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTracking.Repositories
{
    public class DbRepository
    {
        protected MContext _db = new MContext();

        public IQueryable<Project> GetUserProjectsAsQueryable(int userId)
        {
            return _db.Projects.Where(i => i.OwnerId == userId || i.Users.Select(u => u.Id).Contains(userId));
        }

        public IQueryable<Company> GetCompaniesAsQueryable()
        {
            return _db.Companies;
        }

        public IQueryable<dic_Countries> GetCountriesAsQueryable()
        {
            return _db.Countries;
        }

        public IQueryable<dic_Statuses> GetStatusesAsQueryable()
        {
            return _db.Statuses;
        }

        public void AddBug(Bug bug)
        {
            _db.Bugs.Add(bug);
            _db.SaveChanges();
        }

        public IQueryable<dic_BugStatuses> GetBugStatusesAsQueryable()
        {
            return _db.BugStatuses;
        }

        public void AddProject(Project project)
        {
            _db.Projects.Add(project);
            var owner = _db.Users.FirstOrDefault(i => i.Id == project.OwnerId);
            project.Users = new List<User>();
            project.Users.Add(owner);
            _db.SaveChanges();
        }

        public Project GetProjectById(int id)
        {
            return _db.Projects.FirstOrDefault(i => i.Id == id);
        }

        public void AddUserToProject(int userId, int projectId)
        {
            var user = _db.Users.FirstOrDefault(i => i.Id == userId);
            if (user==null)
            { 
                return;
            }

            _db.Projects.FirstOrDefault(i => i.Id == projectId)?.Users?.Add(user);
            _db.SaveChanges();
        }

        public IEnumerable<Bug> GetProjectBugs(int projectId)
        {
            return _db.Bugs.Where(i=>i.ProjectId==projectId);
        }

        public Project GetProjectByBugId(int id)
        {
            return _db.Bugs.FirstOrDefault(i => i.Id == id).Project;
        }

        internal void ChangeBugStatus(int bugId, int statusId)
        {
            _db.Bugs.FirstOrDefault(i => i.Id == bugId).BugStatusId = statusId;
            _db.SaveChanges();
        }

        public Bug GetBugById(int id)
        {
            return _db.Bugs.FirstOrDefault(i => i.Id == id);
        }

        public void RemoveProject(int id)
        {
            var project = _db.Projects.FirstOrDefault(i => i.Id == id);
            _db.Projects.Remove(project);
            _db.SaveChanges();
        }

        public IEnumerable<User> GetProjectUsersById(int id)
        {
            var project = _db.Projects.FirstOrDefault(i => i.Id == id);
            var users = project.Users;
            return users;
        }

        public void ChangeBugUser(int bugId, int userId)
        {
            _db.Bugs.FirstOrDefault(i => i.Id == bugId).UserId = userId;
            _db.SaveChanges();
        }

        public void LeaveProject(int id, int userId)
        {
            var project = _db.Projects.FirstOrDefault(i => i.Id == id);
            var user = project.Users.FirstOrDefault(i => i.Id == userId);
            if (user != null)
            {
                project.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        public void AddComment(int userId, string text, int bugId)
        {

            var comment = new Comment()
            {
                BugId = bugId,
                Content = text,
                DateAdded = DateTime.Now,
                UserId = userId
            };

            _db.Comments.Add(comment);
            _db.SaveChanges();
        }

        public IEnumerable<Comment> GetComments(int bugId)
        {
            return _db.Comments.Where(i => i.BugId == bugId);
        }
    }
}