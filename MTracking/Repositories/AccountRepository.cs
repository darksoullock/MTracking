using MTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTracking.Repositories
{
    public class AccountRepository : DbRepository
    {
        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(i => i.Email == email);
        }

        public User GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(i => i.Id == id);
        }
    }
}