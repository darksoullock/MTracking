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

        public void AddProject(Project project)
        {
            _db.Projects.Add(project);
            var owner = _db.Users.FirstOrDefault(i => i.Id == project.OwnerId);
            project.Users.Add(owner);
            _db.SaveChanges();
        }

        public Project GetProjectById(int id)
        {
            return _db.Projects.FirstOrDefault(i => i.Id == id);
        }
    }
}