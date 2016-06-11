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
            email = email.ToUpper();
            return _db.Users.FirstOrDefault(i => i.Email.ToUpper() == email);
        }

        public User GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(i => i.Id == id);
        }

        public IQueryable<User> GetUsersAsQueryable()
        {
            return _db.Users;
        }

        public string SetToken(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                user.Token = Guid.NewGuid().ToString();
                _db.SaveChanges();
                return user.Token;
            }

            return null;
        }

        public bool IsAuthorized(string email, string token, out int uid)
        {
            var user = GetUserByEmail(email);
            uid = user?.Id ?? -1;
            return user != null && user.Token == token;
        }
    }
}