using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTracking.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public int StatusId { get; set; }

        public virtual dic_Statuses Status { get; set; }

        public string Picture { get; set; }

        public int CountryId { get; set; }

        public virtual dic_Countries Country { get; set; }

        public string Info { get; set; }
    }
}