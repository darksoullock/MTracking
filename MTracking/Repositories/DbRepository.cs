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
    }
}